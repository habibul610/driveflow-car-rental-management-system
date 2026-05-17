using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmCustomerChat : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private BookingBLL bookingBLL = new BookingBLL();
        private DiscountCouponBLL couponBLL = new DiscountCouponBLL();
        private CancellationTokenSource? _cts;
        private DataTable _fleet = new DataTable();
        private DataTable _coupons = new DataTable();

        // ── Pending booking state (conversational booking flow) ───────────────────
        private class PendingBooking
        {
            public int CarId; public string CarName = ""; public decimal Rate;
            public string CouponCode = ""; public decimal DiscountAmount = 0;
        }
        private PendingBooking? _pendingBooking;
        private DataRow?        _lastShownCarRow;  // most recent car card — used for 'book this car'

        // ── Session model ─────────────────────────────────────────────────────────
        private class ChatSession
        {
            public string Name { get; set; }
            public List<ChatMessage> History { get; } = new();
            public List<(bool isUser, string text, List<int> carIds)> Log { get; } = new();
            public HashSet<int> ShownCarIds { get; } = new();
            public string Preview => Log.Count > 0 ? Log[^1].text[..Math.Min(50, Log[^1].text.Length)] : "New conversation";
            public ChatSession(string name, string sys) { Name = name; History.Add(new ChatMessage("system", sys)); }
        }

        private readonly List<ChatSession> _sessions = new();
        private ChatSession? _current;
        private int _sessionCounter = 0;
        private bool _suppressSelection = false;

        // Streaming
        private Label? _streamingLabel;
        private Panel? _streamingRow;
        private bool   _firstToken;

        // Style
        private static readonly Color ClrUser = Color.FromArgb(27, 58, 107);
        private static readonly Color ClrUserFg = Color.White;
        private static readonly Color ClrAI = Color.FromArgb(240, 247, 255);
        private static readonly Color ClrAIFg = Color.FromArgb(15, 23, 42);
        private static readonly Color ClrSidebar = Color.FromArgb(248, 250, 252);
        private static readonly Color ClrSidebarSel = Color.FromArgb(219, 234, 254);
        private readonly Font _fntMsg  = new Font("Segoe UI", 10.5f);
        private readonly Font _fntMeta = new Font("Segoe UI", 8f, FontStyle.Italic);
        private readonly Font _fntCard = new Font("Segoe UI", 10f, FontStyle.Bold);
        private readonly Font _fntSub  = new Font("Segoe UI", 8.5f);

        public frmCustomerChat(Form parent) { InitializeComponent(); parentForm = parent; }

        private async void frmCustomerChat_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnSend, "primary");
            try { _fleet = carBLL.GetAvailableCars(); } catch { _fleet = new DataTable(); }
            try { _coupons = couponBLL.GetAllCoupons(); } catch { _coupons = new DataTable(); }
            bool ok = await OllamaService.IsAvailableAsync();
            lblStatus.Text = ok ? "✅  AI ready · qwen2.5:0.5b" : "⚠  Ollama not reachable";
            lblStatus.ForeColor = ok ? Color.FromArgb(22, 163, 74) : Color.FromArgb(217, 119, 6);
            CreateNewSession();
        }

        // ── Sessions ──────────────────────────────────────────────────────────────

        private void CreateNewSession()
        {
            _pendingBooking = null;
            _sessionCounter++;
            var s = new ChatSession($"Chat {_sessionCounter}", ShortSystemPrompt());
            _sessions.Add(s);
            SyncList(s);
            RenderSession(s);
            // Welcome message
            ShowAIMessage(s, "Hi! I'm your DriveFlow assistant. Ask me anything — car comparisons, prices, recommendations, or just say 'book [car name]' to rent a car!");
        }

        private void RenderSession(ChatSession session)
        {
            _current = session;
            pnlMessages.SuspendLayout();
            pnlMessages.Controls.Clear();
            foreach (var (isUser, text, carIds) in session.Log)
            {
                if (isUser) AddUserBubble(text);
                else AddAIBubble(text);
                foreach (int cid in carIds)
                {
                    var row = _fleet.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["CarID"]) == cid);
                    if (row != null) AddCarCard(row);
                }
            }
            pnlMessages.ResumeLayout(true);
            lblChatName.Text = session.Name;
            SyncList(session);
            ScrollToBottom();
        }

        private void SyncList(ChatSession sel)
        {
            _suppressSelection = true;
            lstSessions.Items.Clear();
            foreach (var s in _sessions) lstSessions.Items.Add(s);
            lstSessions.SelectedItem = sel;
            _suppressSelection = false;
        }

        // ── Send ──────────────────────────────────────────────────────────────────

        private async void btnSend_Click(object? sender, EventArgs e)
        {
            if (_current == null) return;
            string userText = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            txtInput.Clear();
            var session = _current;

            AddUserBubble(userText);
            session.Log.Add((true, userText, new List<int>()));
            SyncList(session);
            SetInputEnabled(false);
            ScrollToBottom();

            // ── STEP 1: Handle pending booking (waiting for return date) ──────────
            if (_pendingBooking != null)
            {
                var pb = _pendingBooking;
                DateTime? retDate = ParseDate(userText);
                if (retDate == null)
                {
                    ShowAIMessage(session, $"I couldn't understand that date. Please tell me your return date — for example: 'May 25', 'in 3 days', or 'next week'.");
                    SetInputEnabled(true);
                    return;
                }
                if (retDate.Value.Date <= DateTime.Today)
                {
                    ShowAIMessage(session, "Return date must be after today. When would you like to return the car?");
                    SetInputEnabled(true);
                    return;
                }
                // Execute booking
                try
                {
                    decimal finalDailyRate = pb.Rate;
                    // Apply discount logic if coupon provided
                    string couponMatched = "";
                    decimal discountVal = 0;
                    foreach (DataRow r in _coupons.Rows)
                    {
                        if (Convert.ToBoolean(r["IsActive"]))
                        {
                            string code = r["Code"].ToString().ToUpper();
                            if (userText.ToUpper().Contains(code) || pb.CouponCode == code)
                            {
                                decimal pct = Convert.ToDecimal(r["DiscountPercentage"]);
                                discountVal = finalDailyRate * (pct / 100m);
                                finalDailyRate -= discountVal;
                                couponMatched = code;
                                break;
                            }
                        }
                    }

                    int days = (retDate.Value.Date - DateTime.Today).Days;
                    decimal total = days * finalDailyRate;
                    
                    string paymentMethod = "Late Payment";
                    string bookingStatus = "Pending";
                    
                    var payRes = MessageBox.Show($"Would you like to pay now via Card for instant auto-approval?\nTotal: BDT {total:N0}\n\n(Selecting No will reserve the car with Late Payment for manager approval)", "Select Payment Method", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (payRes == DialogResult.Cancel)
                    {
                        SetInputEnabled(true);
                        return;
                    }
                    else if (payRes == DialogResult.Yes)
                    {
                        frmPaymentGateway gateway = new frmPaymentGateway(total);
                        if (gateway.ShowDialog() != DialogResult.OK)
                        {
                            ShowAIMessage(session, "Payment cancelled. Booking was not completed.");
                            SetInputEnabled(true);
                            return;
                        }
                        paymentMethod = "Card (Full Payment)";
                        bookingStatus = "Active";
                    }

                    bool ok = bookingBLL.CreateBooking(SessionManager.CurrentUser.UserID, pb.CarId, DateTime.Today, retDate.Value.Date, bookingStatus, paymentMethod, couponMatched, discountVal);
                    if (ok)
                    {
                        _pendingBooking = null;
                        string statusStr = bookingStatus == "Active" ? "AUTO-APPROVED (Paid via Card)" : "Pending Manager Approval (Late Payment)";
                        string msg = $"✅ Booking confirmed!\n🚗 {pb.CarName}\n📅 Pickup: {DateTime.Today:dd MMM yyyy}  →  Return: {retDate.Value:dd MMM yyyy}\n💰 Total: BDT {total:N0} ({days} day{(days > 1 ? "s" : "")})\n📌 Status: {statusStr}";
                        if (!string.IsNullOrEmpty(couponMatched)) msg += $"\n🎁 Coupon {couponMatched} applied!";
                        ShowAIMessage(session, msg);
                        try { _fleet = carBLL.GetAvailableCars(); } catch { }
                    }
                    else ShowAIMessage(session, "Booking failed. Please try again.");
                }
                catch (Exception ex) { ShowAIMessage(session, $"⚠ {ex.Message}"); }
                SetInputEnabled(true);
                return;
            }

            // ── STEP 2: Check booking intent in user message ───────────────────────
            if (HasBookingIntent(userText))
            {
                // Try explicit car name first; fall back to the last shown car card
                var matchedRow = FindCarInText(userText, session) ?? 
                    (IsContextualBooking(userText) ? _lastShownCarRow : null);
                if (matchedRow != null)
                {
                    int cid = Convert.ToInt32(matchedRow["CarID"]);
                    string brand = matchedRow["Brand"]?.ToString() ?? "";
                    string model = matchedRow["Model"]?.ToString() ?? "";
                    decimal rate = matchedRow["DailyRate"] != DBNull.Value ? Convert.ToDecimal(matchedRow["DailyRate"]) : 0;
                    
                    string foundCoupon = "";
                    foreach (DataRow r in _coupons.Rows)
                    {
                        if (Convert.ToBoolean(r["IsActive"]))
                        {
                            string code = r["Code"].ToString().ToUpper();
                            if (userText.ToUpper().Contains(code)) { foundCoupon = code; break; }
                        }
                    }

                    AddCarCard(matchedRow);
                    session.ShownCarIds.Add(cid);
                    // Update last log entry with car id
                    if (session.Log.Count > 0)
                    {
                        var last = session.Log[^1];
                        last.carIds.Add(cid);
                    }
                    _pendingBooking = new PendingBooking { CarId = cid, CarName = $"{brand} {model}", Rate = rate, CouponCode = foundCoupon };
                    string couponStr = !string.IsNullOrEmpty(foundCoupon) ? $" with coupon {foundCoupon}" : "";
                    ShowAIMessage(session, $"Great choice! I've selected the {brand} {model} for you (BDT {rate:N0}/day){couponStr}. What date would you like to return it? (e.g. 'May 25', 'in 3 days', 'next week')");
                    SetInputEnabled(true);
                    ScrollToBottom();
                    return;
                }
            }

            // ── STEP 3: General AI question — inject fleet into user message ───────
            // Injecting fleet into the user message (not just system prompt) ensures
            // the tiny 0.5B model always has fleet data in its active context window.
            string contextualMessage = BuildContextMessage(userText);
            session.History.Add(new ChatMessage("user", contextualMessage));

            BeginStreamingBubble();

            var aiResponse = new StringBuilder();
            try
            {
                await OllamaService.StreamChatAsync(
                    session.History,
                    onToken: t =>
                    {
                        aiResponse.Append(t);
                        if (_streamingLabel?.IsHandleCreated == true)
                            _streamingLabel.BeginInvoke(() =>
                            {
                                if (_firstToken) { _streamingLabel.Text = ""; _firstToken = false; }
                                _streamingLabel.Text += t;
                                if (_streamingRow != null)
                                {
                                    int need = _streamingLabel.Bottom + 12;
                                    if (need > _streamingRow.Height) _streamingRow.Height = need;
                                }
                                ScrollToBottom();
                            });
                    },
                    cancellationToken: token);
            }
            catch (OperationCanceledException) { aiResponse.Append("[stopped]"); }
            catch (Exception ex) { aiResponse.Append($"❌ {ex.Message}"); }
            finally
            {
                string reply = aiResponse.ToString().Trim();
                if (_streamingLabel?.IsHandleCreated == true)
                    _streamingLabel.BeginInvoke(() => FinaliseStreaming(reply, session));
                if (IsHandleCreated) BeginInvoke(() => SetInputEnabled(true));
            }
        }

        private void FinaliseStreaming(string reply, ChatSession session)
        {
            if (_streamingLabel != null)
            {
                _streamingLabel.Text = reply.Replace("**", "").Replace("### ", "").Replace("## ", "").Replace("# ", "");
            }
            if (_streamingRow != null)
            {
                int need = (_streamingLabel?.Bottom ?? 0) + 12;
                if (need > _streamingRow.Height) _streamingRow.Height = need;
            }
            // Scan AI reply for car cards (only cars not already shown)
            var newCarIds = new List<int>();
            if (_fleet.Rows.Count > 0 && !string.IsNullOrWhiteSpace(reply))
            {
                string lower = reply.ToLower();
                foreach (DataRow row in _fleet.Rows)
                {
                    int cid = Convert.ToInt32(row["CarID"]);
                    if (session.ShownCarIds.Contains(cid)) continue;
                    string brand = (row["Brand"]?.ToString() ?? "").ToLower();
                    string model = (row["Model"]?.ToString() ?? "").ToLower();
                    if ((!string.IsNullOrEmpty(brand) && lower.Contains(brand)) ||
                        (!string.IsNullOrEmpty(model) && lower.Contains(model)))
                    {
                        AddCarCard(row);
                        session.ShownCarIds.Add(cid);
                        newCarIds.Add(cid);
                        _lastShownCarRow = row;
                    }
                }
            }
            session.History.Add(new ChatMessage("assistant", reply));
            session.Log.Add((false, reply, newCarIds));
            _streamingLabel = null;
            _streamingRow = null;
            SyncList(session);
            ScrollToBottom();
        }

        // ── Rendering ─────────────────────────────────────────────────────────────

        private int NextY() => pnlMessages.Controls.Count == 0 ? 10 :
            pnlMessages.Controls.OfType<Control>().Max(c => c.Bottom) + 6;

        private int MsgWidth() => Math.Max(pnlMessages.ClientSize.Width - 12, 500);

        private void AddUserBubble(string text)
        {
            int pw = MsgWidth(), bw = Math.Min((int)(pw * 0.68), 520);
            var lbl = new Label { Text = text, Font = _fntMsg, AutoSize = true, MaximumSize = new Size(bw, 0), BackColor = ClrUser, ForeColor = ClrUserFg, Padding = new Padding(12, 8, 12, 8) };
            lbl.Size = lbl.GetPreferredSize(new Size(bw, 0));
            var ts = new Label { Text = DateTime.Now.ToString("HH:mm"), Font = _fntMeta, ForeColor = Color.FromArgb(148, 163, 184), AutoSize = true };
            var row = new Panel { Width = pw, Height = lbl.Height + ts.Height + 14, Location = new Point(0, NextY()), BackColor = Color.Transparent };
            lbl.Location = new Point(pw - lbl.Width - 8, 4);
            ts.Location = new Point(pw - lbl.Width - 8, lbl.Bottom + 2);
            row.Controls.Add(lbl); row.Controls.Add(ts);
            pnlMessages.Controls.Add(row);
        }

        private void AddAIBubble(string text)
        {
            string cleanText = text.Replace("**", "").Replace("### ", "").Replace("## ", "").Replace("# ", "");
            int pw = MsgWidth(), bw = Math.Min((int)(pw * 0.75), 580);
            var lbl = new Label { Text = cleanText, Font = _fntMsg, AutoSize = true, MaximumSize = new Size(bw - 40, 0), BackColor = ClrAI, ForeColor = ClrAIFg, Padding = new Padding(12, 8, 12, 8) };
            lbl.Size = lbl.GetPreferredSize(new Size(bw - 40, 0));
            var icon = new Label { Text = "🤖", Font = new Font("Segoe UI Emoji", 11), AutoSize = true, BackColor = Color.Transparent, Location = new Point(8, 6) };
            lbl.Location = new Point(36, 4);
            var row = new Panel { Width = pw, Height = lbl.Height + 16, Location = new Point(0, NextY()), BackColor = Color.Transparent };
            row.Controls.Add(icon); row.Controls.Add(lbl);
            pnlMessages.Controls.Add(row);
        }

        private void ShowAIMessage(ChatSession session, string text)
        {
            AddAIBubble(text);
            session.Log.Add((false, text, new List<int>()));
            SyncList(session);
            ScrollToBottom();
        }

        private void BeginStreamingBubble()
        {
            int pw = MsgWidth(), bw = Math.Min((int)(pw * 0.75), 580);
            _streamingLabel = new Label { Text = "…", Font = _fntMsg, AutoSize = true, MaximumSize = new Size(bw - 40, 0), MinimumSize = new Size(60, 36), BackColor = ClrAI, ForeColor = Color.FromArgb(100, 116, 139), Padding = new Padding(12, 8, 12, 8) };
            _streamingLabel.Location = new Point(36, 4);
            _firstToken = true;
            var icon = new Label { Text = "🤖", Font = new Font("Segoe UI Emoji", 11), AutoSize = true, BackColor = Color.Transparent, Location = new Point(8, 6) };
            _streamingRow = new Panel { Width = pw, Height = 56, Location = new Point(0, NextY()), BackColor = Color.Transparent };
            _streamingRow.Controls.Add(icon); _streamingRow.Controls.Add(_streamingLabel);
            pnlMessages.Controls.Add(_streamingRow);
        }

        private void AddCarCard(DataRow row)
        {
            int cid = Convert.ToInt32(row["CarID"]);
            string brand = row["Brand"]?.ToString() ?? "", model = row["Model"]?.ToString() ?? "";
            string year = row["Year"]?.ToString() ?? "", color = row["Color"]?.ToString() ?? "";
            decimal rate = row["DailyRate"] != DBNull.Value ? Convert.ToDecimal(row["DailyRate"]) : 0;

            int pw = MsgWidth(), cardW = Math.Min(400, pw - 60);
            var card = new Panel { Width = cardW, Height = 100, BackColor = Color.White };
            card.Paint += (s, pe) => pe.Graphics.DrawRectangle(new System.Drawing.Pen(Color.FromArgb(219, 234, 254), 2), 1, 1, card.Width - 2, card.Height - 2);
            card.Controls.Add(new Label { Text = $"🚗  {year} {brand} {model}", Font = _fntCard, ForeColor = ClrUser, AutoSize = true, Location = new Point(14, 10) });
            card.Controls.Add(new Label { Text = $"Color: {color}  ·  Rate: BDT {rate:N0}/day", Font = _fntSub, ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(14, 34) });

            int capId = cid; string capName = $"{brand} {model}"; decimal capRate = rate;
            var btnBook = new Button { Text = "📋 Book This Car", Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Size = new Size(150, 34), Location = new Point(14, 58), FlatStyle = FlatStyle.Flat, BackColor = ClrUser, ForeColor = Color.White, Cursor = Cursors.Hand };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += (s, ev) =>
            {
                if (_current == null) return;
                _pendingBooking = new PendingBooking { CarId = capId, CarName = capName, Rate = capRate };
                ShowAIMessage(_current, $"Great! I've selected the **{capName}** (BDT {capRate:N0}/day). What date would you like to return it? (e.g. 'May 25', 'in 3 days', 'next week')");
                txtInput.Focus();
            };
            card.Controls.Add(btnBook);

            var wrapper = new Panel { Width = pw, Height = 108, Location = new Point(0, NextY()), BackColor = Color.Transparent };
            card.Location = new Point(44, 4);
            wrapper.Controls.Add(card);
            pnlMessages.Controls.Add(wrapper);
            _lastShownCarRow = row; // remember for contextual 'book this car'
        }

        // ── Booking intent ────────────────────────────────────────────────────────

        private bool HasBookingIntent(string t)
        {
            string lower = t.ToLower();
            return lower.Contains("book") || lower.Contains("reserve") ||
                   lower.Contains("rent me") || lower.Contains("i want to rent") || lower.Contains("rent this");
        }

        /// <summary>Returns true when the user refers to a car contextually, e.g. 'book this', 'get it', 'that one'.</summary>
        private bool IsContextualBooking(string t)
        {
            string lower = t.ToLower();
            return lower.Contains("this car") || lower.Contains("this one") ||
                   lower.Contains("book it") || lower.Contains("get it") ||
                   lower.Contains("that car") || lower.Contains("that one") ||
                   lower.Contains("for me");
        }

        private DataRow? FindCarInText(string text, ChatSession session)
        {
            string lower = text.ToLower();
            foreach (DataRow row in _fleet.Rows)
            {
                int cid = Convert.ToInt32(row["CarID"]);
                if (session.ShownCarIds.Contains(cid)) continue;
                string brand = (row["Brand"]?.ToString() ?? "").ToLower();
                string model = (row["Model"]?.ToString() ?? "").ToLower();
                if ((!string.IsNullOrEmpty(brand) && lower.Contains(brand)) ||
                    (!string.IsNullOrEmpty(model) && lower.Contains(model)))
                    return row;
            }
            return null;
        }

        // ── Date parsing ──────────────────────────────────────────────────────────

        private DateTime? ParseDate(string input)
        {
            input = input.Trim().ToLower();

            if (input == "tomorrow") return DateTime.Today.AddDays(1);
            if (input == "next week") return DateTime.Today.AddDays(7);
            if (input == "next month") return DateTime.Today.AddMonths(1);

            // "in X days" / "X days"
            var daysMatch = System.Text.RegularExpressions.Regex.Match(input, @"(\d+)\s*day");
            if (daysMatch.Success && int.TryParse(daysMatch.Groups[1].Value, out int days))
                return DateTime.Today.AddDays(days);

            // "X weeks"
            var weeksMatch = System.Text.RegularExpressions.Regex.Match(input, @"(\d+)\s*week");
            if (weeksMatch.Success && int.TryParse(weeksMatch.Groups[1].Value, out int weeks))
                return DateTime.Today.AddDays(weeks * 7);

            // Try standard parse
            if (DateTime.TryParse(input, out DateTime parsed)) return parsed;

            // "May 20", "20 May", "May 20th"
            string clean = System.Text.RegularExpressions.Regex.Replace(input, @"(st|nd|rd|th)", "");
            if (DateTime.TryParse(clean, out DateTime parsed2)) return parsed2;

            return null;
        }

        // ── Context injection ─────────────────────────────────────────────────────

        /// <summary>
        /// Injects the live fleet into every user message so the tiny model
        /// always has fleet data in its immediate context (not just system prompt).
        /// </summary>
        private string BuildContextMessage(string userMessage)
        {
            var sb = new StringBuilder();

            // Tell AI who the customer is — so it NEVER asks for their details
            string userName = SessionManager.CurrentUser?.FullName ?? "Customer";
            sb.AppendLine($"[LOGGED-IN CUSTOMER: {userName} — all contact details are already in our system. NEVER ask for name, phone, email, or any personal information.]");
            sb.AppendLine();
            sb.AppendLine("[AVAILABLE FLEET — use this data to answer]");
            foreach (DataRow r in _fleet.Rows)
            {
                string rate    = r["DailyRate"] != DBNull.Value ? $"BDT {Convert.ToDecimal(r["DailyRate"]):N0}/day" : "N/A";
                string details = (r.Table.Columns.Contains("CarDetails") && r["CarDetails"] != DBNull.Value)
                    ? r["CarDetails"].ToString()! : "";
                sb.Append($"• {r["Year"]} {r["Brand"]} {r["Model"]} | {r["Color"]} | {rate}");
                if (!string.IsNullOrWhiteSpace(details)) sb.Append($" | Details: {details}");
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine("[ACTIVE DISCOUNT COUPONS]");
            foreach (DataRow r in _coupons.Rows)
            {
                if (Convert.ToBoolean(r["IsActive"]))
                    sb.AppendLine($"• {r["Code"]} - {r["DiscountPercentage"]}% OFF");
            }
            sb.AppendLine();
            sb.AppendLine($"Customer: {userMessage}");
            return sb.ToString();
        }

        private string ShortSystemPrompt()
        {
            string userName = SessionManager.CurrentUser?.FullName ?? "Customer";
            return $"You are a helpful car rental assistant for DriveFlow. " +
                   $"The customer '{userName}' is already logged in — you have all their information. " +
                   $"NEVER ask for name, phone number, email, or contact details. " +
                   $"When a customer wants to book a car, only ask for the return date, then the system will handle everything. " +
                   $"Answer any question about cars, comparisons, recommendations, pricing. Use the fleet data in each message. " +
                   $"IMPORTANT: When a user asks for 'cheap', 'budget', 'lowest price', or 'affordable' cars, you MUST suggest the car with the absolute lowest DailyRate in the available fleet. Do not suggest luxury cars for these queries. " +
                   $"Be friendly and concise.";
        }

        // ── Utilities ─────────────────────────────────────────────────────────────

        private void ScrollToBottom()
        {
            if (!pnlMessages.IsHandleCreated) return;
            pnlMessages.AutoScrollPosition = new Point(0, pnlMessages.DisplayRectangle.Height);
        }

        private void SetInputEnabled(bool on)
        {
            txtInput.Enabled = on; btnSend.Enabled = on;
            btnSend.Text = on ? "Send ➤" : "⏳";
            if (on) txtInput.Focus();
        }

        // ── Events ────────────────────────────────────────────────────────────────

        private void btnNewChat_Click(object sender, EventArgs e) => CreateNewSession();

        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelection) return;
            if (lstSessions.SelectedItem is ChatSession s && s != _current)
            { _cts?.Cancel(); _pendingBooking = null; RenderSession(s); }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift) { e.SuppressKeyPress = true; btnSend_Click(sender, e); }
        }

        private void btnBack_Click(object sender, EventArgs e) { _cts?.Cancel(); parentForm.Show(); this.Close(); }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _cts?.Cancel();
            _fntMsg.Dispose(); _fntMeta.Dispose(); _fntCard.Dispose(); _fntSub.Dispose();
            base.OnFormClosed(e);
        }

        private void lstSessions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstSessions.Items.Count) return;
            var s = (ChatSession)lstSessions.Items[e.Index];
            bool sel = (e.State & DrawItemState.Selected) != 0;
            e.Graphics.FillRectangle(new SolidBrush(sel ? ClrSidebarSel : ClrSidebar), e.Bounds);
            if (sel) e.Graphics.DrawLine(new System.Drawing.Pen(Color.FromArgb(37, 99, 235), 3), e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);
            e.Graphics.DrawString(s.Name, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(sel ? ClrUser : Color.FromArgb(15, 23, 42)), new RectangleF(e.Bounds.Left + 12, e.Bounds.Top + 5, e.Bounds.Width - 14, 18));
            e.Graphics.DrawString(s.Preview, new Font("Segoe UI", 8.5f), new SolidBrush(Color.FromArgb(100, 116, 139)), new RectangleF(e.Bounds.Left + 12, e.Bounds.Top + 25, e.Bounds.Width - 14, 16), new StringFormat { Trimming = StringTrimming.EllipsisCharacter });
        }
    }
}
