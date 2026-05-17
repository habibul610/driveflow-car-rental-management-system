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
    /// <summary>
    /// Multi-turn AI business chat for the administrator.
    /// Maintains full conversation history each request so the AI has context.
    /// </summary>
    public partial class frmAdminChat : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private BookingBLL bookingBLL = new BookingBLL();

        private CancellationTokenSource? _cts;

        // Full conversation history sent to Ollama on every message
        private readonly List<ChatMessage> _history = new();

        // Fonts for chat display
        private readonly Font _fontYou  = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fontAI   = new Font("Segoe UI", 10, FontStyle.Regular);
        private readonly Font _fontMeta = new Font("Segoe UI", 8, FontStyle.Italic);

        public frmAdminChat(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private async void frmAdminChat_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnSend, "primary");
            UIHelper.StyleButton(btnClear, "neutral");

            // Inject system prompt with live business context
            string systemContent = BuildSystemPrompt();
            _history.Add(new ChatMessage("system", systemContent));

            // Connectivity check
            bool ok = await OllamaService.IsAvailableAsync();
            if (ok)
            {
                AppendAIMessage("Hello! I'm your DriveFlow AI business assistant. " +
                    "I've been loaded with your current fleet and booking data. " +
                    "Ask me anything about your business — pricing strategy, fleet performance, " +
                    "revenue insights, customer trends, or anything else!", isWelcome: true);
            }
            else
            {
                AppendSystemNote("⚠  Ollama is not reachable at localhost:11434. Start Ollama with: ollama serve");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(message)) return;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // Show user message
            txtInput.Clear();
            AppendUserMessage(message);

            // Add to history
            _history.Add(new ChatMessage("user", message));

            // Lock input
            SetInputEnabled(false);

            try
            {
                // Start AI response bubble
                AppendAIMessageStart();

                var aiResponse = new StringBuilder();
                await OllamaService.StreamChatAsync(
                    _history,
                    onToken: t =>
                    {
                        aiResponse.Append(t);
                        if (rtbChat.IsHandleCreated)
                            rtbChat.BeginInvoke(() =>
                            {
                                // Append each token directly into the active AI bubble
                                rtbChat.AppendText(t);
                                rtbChat.ScrollToCaret();
                            });
                    },
                    cancellationToken: token);

                // Finalize — add AI response to history
                string fullResponse = aiResponse.ToString();
                _history.Add(new ChatMessage("assistant", fullResponse));

                // Add newlines after the AI bubble
                if (rtbChat.IsHandleCreated)
                    rtbChat.BeginInvoke(() => rtbChat.AppendText("\n\n"));
            }
            catch (OperationCanceledException)
            {
                rtbChat.BeginInvoke(() =>
                {
                    rtbChat.AppendText("\n[stopped]\n\n");
                });
            }
            catch (Exception ex)
            {
                rtbChat.BeginInvoke(() =>
                {
                    AppendSystemNote($"❌  Error: {ex.Message}");
                });
            }
            finally
            {
                if (IsHandleCreated)
                    BeginInvoke(() => SetInputEnabled(true));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            rtbChat.Clear();

            // Keep only the system message, reset history
            _history.RemoveAll(m => m.Role != "system");

            // Update system prompt with fresh data
            if (_history.Count > 0)
                _history[0] = new ChatMessage("system", BuildSystemPrompt());

            AppendSystemNote("Chat cleared. History reset with fresh business data.");
        }

        // ── Chat display helpers ─────────────────────────────────────────────────

        private void AppendUserMessage(string text)
        {
            rtbChat.SelectionFont = _fontMeta;
            rtbChat.SelectionColor = Color.FromArgb(100, 116, 139);
            rtbChat.AppendText($"You  ·  {DateTime.Now:HH:mm}\n");

            rtbChat.SelectionFont = _fontYou;
            rtbChat.SelectionColor = Color.FromArgb(27, 58, 107);
            rtbChat.AppendText(text + "\n\n");
            rtbChat.ScrollToCaret();
        }

        private void AppendAIMessageStart()
        {
            rtbChat.SelectionFont = _fontMeta;
            rtbChat.SelectionColor = Color.FromArgb(100, 116, 139);
            rtbChat.AppendText($"DriveFlow AI  ·  {DateTime.Now:HH:mm}\n");

            rtbChat.SelectionFont = _fontAI;
            rtbChat.SelectionColor = Color.FromArgb(15, 23, 42);
            // Tokens stream in here via AppendText in onToken callback
        }

        private void AppendAIMessage(string text, bool isWelcome = false)
        {
            rtbChat.SelectionFont = _fontMeta;
            rtbChat.SelectionColor = Color.FromArgb(100, 116, 139);
            rtbChat.AppendText($"DriveFlow AI  ·  {DateTime.Now:HH:mm}\n");

            rtbChat.SelectionFont = _fontAI;
            rtbChat.SelectionColor = isWelcome
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(15, 23, 42);
            rtbChat.AppendText(text + "\n\n");
            rtbChat.ScrollToCaret();
        }

        private void AppendSystemNote(string text)
        {
            rtbChat.SelectionFont = _fontMeta;
            rtbChat.SelectionColor = Color.FromArgb(217, 119, 6);
            rtbChat.AppendText("─── " + text + " ───\n\n");
            rtbChat.ScrollToCaret();
        }

        private void SetInputEnabled(bool enabled)
        {
            txtInput.Enabled = enabled;
            btnSend.Enabled = enabled;
            btnSend.Text = enabled ? "Send ➤" : "⏳ Thinking...";
            if (enabled) txtInput.Focus();
        }

        // ── Context builder ──────────────────────────────────────────────────────

        /// <summary>
        /// Builds a rich system prompt that contains live fleet/booking/revenue data.
        /// This is sent as the system message at the start of every conversation.
        /// </summary>
        private string BuildSystemPrompt()
        {
            var sb = new StringBuilder();
            sb.AppendLine("You are a professional AI business analyst and assistant for DriveFlow Car Rental.");
            sb.AppendLine("You have access to real-time business data shown below. Answer concisely and professionally.");
            sb.AppendLine("When asked about specific cars, bookings, or revenue, use the provided data.");
            sb.AppendLine();

            try
            {
                DataTable cars = carBLL.GetAllCars();
                int total       = cars.Rows.Count;
                int available   = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Available");
                int rented      = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Rented");
                int maintenance = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Maintenance");

                sb.AppendLine("=== CURRENT FLEET ===");
                sb.AppendLine($"Total Cars: {total} | Available: {available} | Rented: {rented} | Maintenance: {maintenance}");
                sb.AppendLine($"Occupancy Rate: {(total > 0 ? (double)rented / total * 100 : 0):F1}%");
                sb.AppendLine();
                sb.AppendLine("Cars in fleet:");
                foreach (DataRow r in cars.Rows)
                {
                    string rate = r["DailyRate"] != DBNull.Value
                        ? $"BDT {Convert.ToDecimal(r["DailyRate"]):N0}/day" : "N/A";
                    sb.AppendLine($"  - {r["Year"]} {r["Brand"]} {r["Model"]} | {r["Color"]} | {r["PlateNumber"]} | {rate} | Status: {r["Status"]}");
                }

                DataTable bookings = bookingBLL.GetAllBookings();
                int totalBk    = bookings.Rows.Count;
                int activeBk   = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Active");
                int completedBk = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Completed");

                decimal revenue = bookings.AsEnumerable()
                    .Where(r => r["Status"].ToString() == "Completed" && r["TotalAmount"] != DBNull.Value)
                    .Sum(r => Convert.ToDecimal(r["TotalAmount"]));

                sb.AppendLine();
                sb.AppendLine("=== BOOKINGS & REVENUE ===");
                sb.AppendLine($"Total Bookings: {totalBk} | Active: {activeBk} | Completed: {completedBk}");
                sb.AppendLine($"Total Revenue: BDT {revenue:N2}");
                if (completedBk > 0)
                    sb.AppendLine($"Avg Revenue/Booking: BDT {revenue / completedBk:N2}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"[Live data load error: {ex.Message} — answer from general knowledge]");
            }

            sb.AppendLine();
            sb.AppendLine($"Data snapshot time: {DateTime.Now:dd MMM yyyy HH:mm}");

            return sb.ToString();
        }

        // ── Handle Enter key to send ─────────────────────────────────────────────

        private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(sender, e);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            parentForm.Show();
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _cts?.Cancel();
            _fontYou.Dispose();
            _fontAI.Dispose();
            _fontMeta.Dispose();
            base.OnFormClosed(e);
        }
    }
}
