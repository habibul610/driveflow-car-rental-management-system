using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmAISuggestions : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private CancellationTokenSource? _cts;

        // Full available-car table loaded once per session
        private DataTable? _allAvailableCars;

        public frmAISuggestions(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private async void frmAISuggestions_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnSuggest, "primary");
            UIHelper.StyleDataGridView(dgvSuggestions);

            // Pre-load cars
            try { _allAvailableCars = carBLL.GetAvailableCars(); }
            catch { _allAvailableCars = new DataTable(); }

            // Ollama connectivity check
            bool available = await OllamaService.IsAvailableAsync();
            UpdateStatus(
                available ? "✅ AI ready — describe the car you need!" : "⚠ Ollama not reachable (localhost:11434)",
                available ? System.Drawing.Color.FromArgb(22, 163, 74) : System.Drawing.Color.FromArgb(217, 119, 6));
        }

        private async void btnSuggest_Click(object sender, EventArgs e)
        {
            string pref = txtPreferences.Text.Trim();
            if (string.IsNullOrWhiteSpace(pref))
            {
                MessageBox.Show("Please describe what kind of car you're looking for!",
                    "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // Reset UI
            btnSuggest.Enabled = false;
            btnSuggest.Text = "⏳ Thinking...";
            rtbAiResponse.Clear();
            rtbAiResponse.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvSuggestions.DataSource = null;
            dgvSuggestions.Visible = false;
            UpdateStatus("🤖  AI is reading your request...",
                System.Drawing.Color.FromArgb(100, 116, 139));

            try
            {
                // ── Build complete car context for the AI ─────────────────────
                string carInventory = BuildCarInventoryContext(_allAvailableCars);

                string systemPrompt =
                    "You are a friendly car rental assistant for DriveFlow. " +
                    "You have full knowledge of every car currently available in the fleet (listed below). " +
                    "When a customer describes what they want, recommend the most suitable cars by their EXACT brand and model name. " +
                    "Keep your response under 5 sentences. Be warm, clear, and helpful.";

                string userMessage =
                    $"Our currently available cars:\n{carInventory}\n\n" +
                    $"Customer's request: \"{pref}\"\n\n" +
                    "Which of our available cars do you recommend and why?";

                // ── Stream AI response into RichTextBox ───────────────────────
                var aiResponse = new StringBuilder();
                await OllamaService.StreamAsync(
                    systemPrompt,
                    userMessage,
                    onToken: t =>
                    {
                        aiResponse.Append(t);
                        if (rtbAiResponse.IsHandleCreated)
                            rtbAiResponse.BeginInvoke(() =>
                            {
                                rtbAiResponse.AppendText(t);
                                rtbAiResponse.ScrollToCaret();
                            });
                    },
                    cancellationToken: token);

                // ── AI is done — now match car names it mentioned ─────────────
                if (rtbAiResponse.IsHandleCreated)
                    rtbAiResponse.BeginInvoke(() =>
                    {
                        ShowMatchingCars(aiResponse.ToString());
                        UpdateStatus("✅  Here are your matches based on the AI recommendation:",
                            System.Drawing.Color.FromArgb(22, 163, 74));
                    });
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("Stopped.", System.Drawing.Color.FromArgb(100, 116, 139));
            }
            catch (Exception ex)
            {
                rtbAiResponse.BeginInvoke(() =>
                {
                    rtbAiResponse.Text = $"❌  Error: {ex.Message}\n\nMake sure Ollama is running: ollama serve";
                    rtbAiResponse.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
                    ShowAllAvailableCars();
                    UpdateStatus("⚠  AI unavailable — showing all available cars.",
                        System.Drawing.Color.FromArgb(217, 119, 6));
                });
            }
            finally
            {
                if (btnSuggest.IsHandleCreated)
                    btnSuggest.BeginInvoke(() =>
                    {
                        btnSuggest.Enabled = true;
                        btnSuggest.Text = "🔍 Ask AI";
                    });
            }
        }

        /// <summary>
        /// After AI finishes, scan its response for brand/model names from the actual inventory.
        /// Show matched cars in the grid. Falls back to all cars if nothing matches.
        /// </summary>
        private void ShowMatchingCars(string aiText)
        {
            if (_allAvailableCars == null || _allAvailableCars.Rows.Count == 0)
            {
                ShowAllAvailableCars();
                return;
            }

            string lowerResponse = aiText.ToLower();

            var matched = _allAvailableCars.AsEnumerable()
                .Where(r =>
                {
                    string brand = (r["Brand"]?.ToString() ?? "").ToLower();
                    string model = (r["Model"]?.ToString() ?? "").ToLower();
                    // Match if the AI mentioned the brand OR model name
                    return (!string.IsNullOrEmpty(brand) && lowerResponse.Contains(brand)) ||
                           (!string.IsNullOrEmpty(model) && lowerResponse.Contains(model));
                })
                .ToList();

            dgvSuggestions.DataSource = matched.Count > 0
                ? matched.CopyToDataTable()
                : _allAvailableCars; // fallback: show all

            dgvSuggestions.Visible = true;
        }

        private void ShowAllAvailableCars()
        {
            dgvSuggestions.DataSource = _allAvailableCars;
            dgvSuggestions.Visible = _allAvailableCars?.Rows.Count > 0;
        }

        /// <summary>
        /// Builds a numbered car inventory list that the AI can reason about.
        /// Includes all details so AI understands what's actually in the fleet.
        /// </summary>
        private string BuildCarInventoryContext(DataTable? cars)
        {
            if (cars == null || cars.Rows.Count == 0)
                return "No cars currently available for rental.";

            var sb = new StringBuilder();
            int i = 1;
            foreach (DataRow row in cars.Rows)
            {
                string brand = row["Brand"]?.ToString() ?? "";
                string model = row["Model"]?.ToString() ?? "";
                string year  = row["Year"]?.ToString() ?? "";
                string color = row["Color"]?.ToString() ?? "";
                string rate  = row["DailyRate"] != DBNull.Value
                    ? $"BDT {Convert.ToDecimal(row["DailyRate"]):N0}/day" : "N/A";

                sb.AppendLine($"{i}. {year} {brand} {model} — {color} — {rate}");
                i++;
                if (i > 20) { sb.AppendLine($"... and {cars.Rows.Count - 20} more"); break; }
            }
            return sb.ToString();
        }

        private void UpdateStatus(string text, System.Drawing.Color color)
        {
            if (lblStatus.IsHandleCreated)
                lblStatus.BeginInvoke(() => { lblStatus.Text = text; lblStatus.ForeColor = color; });
            else { lblStatus.Text = text; lblStatus.ForeColor = color; }
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
            base.OnFormClosed(e);
        }
    }
}
