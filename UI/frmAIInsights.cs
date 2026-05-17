using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmAIInsights : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private BookingBLL bookingBLL = new BookingBLL();
        private BillingBLL billingBLL = new BillingBLL();

        private CancellationTokenSource? _cts;

        public frmAIInsights(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private async void frmAIInsights_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnGenerate, "primary");
            rtbInsights.Font = new System.Drawing.Font("Cascadia Code", 11F);
            rtbInsights.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);

            // Check Ollama availability on load
            bool available = await OllamaService.IsAvailableAsync();
            if (!available)
            {
                rtbInsights.Text = "⚠ Ollama is not reachable at http://localhost:11434\n\n" +
                                   "Make sure Ollama is running:\n  ollama serve\n\n" +
                                   "Then click \"Generate Insights\".";
                rtbInsights.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            }
            else
            {
                rtbInsights.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
                rtbInsights.Text = "✅ Ollama connected (qwen2.5:0.5b)\n\nClick \"✨ Generate Insights\" to analyze your fleet with AI.";
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            // Cancel any previous running generation
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            btnGenerate.Enabled = false;
            btnGenerate.Text = "⏳ Thinking...";
            rtbInsights.Clear();

            try
            {
                // ── Build live context from the DB ──────────────────────────────
                string context = BuildFleetContext();

                string systemPrompt =
                    "You are an AI business analyst for DriveFlow, a professional car rental company. " +
                    "Your job is to analyze fleet and booking data and give clear, actionable business insights. " +
                    "Be concise, specific, and professional. Format your response with clear sections. " +
                    "Do not hallucinate data — only analyse what is provided to you.";

                string userMessage =
                    $"Here is our current business data:\n\n{context}\n\n" +
                    "Please provide:\n" +
                    "1. Fleet performance summary\n" +
                    "2. Revenue analysis\n" +
                    "3. Top 2 actionable business recommendations\n" +
                    "4. Any risks or anomalies you notice";

                // ── Stream tokens directly into the RichTextBox ─────────────────
                await OllamaService.StreamAsync(
                    systemPrompt,
                    userMessage,
                    onToken: t =>
                    {
                        // Marshal token back to UI thread
                        if (rtbInsights.IsHandleCreated)
                            rtbInsights.BeginInvoke(() =>
                            {
                                rtbInsights.AppendText(t);
                                rtbInsights.ScrollToCaret();
                            });
                    },
                    cancellationToken: token);

                // Append a timestamp footer
                rtbInsights.BeginInvoke(() =>
                    rtbInsights.AppendText($"\n\n─────────────────────────────────────\n" +
                                           $"Generated at {DateTime.Now:dd MMM yyyy HH:mm:ss} by qwen2.5:0.5b via Ollama"));
            }
            catch (OperationCanceledException)
            {
                rtbInsights.BeginInvoke(() => rtbInsights.AppendText("\n\n[Generation stopped by user]"));
            }
            catch (Exception ex)
            {
                rtbInsights.BeginInvoke(() =>
                {
                    rtbInsights.Text = $"❌  Error: {ex.Message}\n\n" +
                                       "Make sure Ollama is running and the model is available:\n" +
                                       "  ollama run qwen2.5:0.5b";
                    rtbInsights.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
                });
            }
            finally
            {
                // Restore button on UI thread
                if (btnGenerate.IsHandleCreated)
                    btnGenerate.BeginInvoke(() =>
                    {
                        btnGenerate.Enabled = true;
                        btnGenerate.Text = "✨ Generate Insights";
                    });
            }
        }

        /// <summary>
        /// Builds a structured plain-text context string from live DB data
        /// to send to the AI as grounding information.
        /// </summary>
        private string BuildFleetContext()
        {
            var sb = new StringBuilder();

            try
            {
                DataTable cars = carBLL.GetAllCars();
                int totalCars     = cars.Rows.Count;
                int available     = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Available");
                int rented        = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Rented");
                int maintenance   = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Maintenance");
                double occupancy  = totalCars > 0 ? (double)rented / totalCars * 100 : 0;

                sb.AppendLine("=== FLEET ===");
                sb.AppendLine($"Total Cars: {totalCars}");
                sb.AppendLine($"Available: {available}");
                sb.AppendLine($"Currently Rented: {rented}");
                sb.AppendLine($"Under Maintenance: {maintenance}");
                sb.AppendLine($"Occupancy Rate: {occupancy:F1}%");

                // List car brands/models
                var brands = cars.AsEnumerable()
                    .GroupBy(r => r["Brand"].ToString())
                    .Select(g => $"{g.Key} ({g.Count()})");
                sb.AppendLine($"Brands in Fleet: {string.Join(", ", brands)}");

                DataTable bookings = bookingBLL.GetAllBookings();
                int totalBookings  = bookings.Rows.Count;
                int activeBookings = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Active");
                int completed      = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Completed");
                int cancelled      = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Cancelled");

                decimal totalRevenue = bookingBLL.GetEarnings(null);

                sb.AppendLine();
                sb.AppendLine("=== BOOKINGS ===");
                sb.AppendLine($"Total Bookings: {totalBookings}");
                sb.AppendLine($"Active (Ongoing): {activeBookings}");
                sb.AppendLine($"Completed: {completed}");
                sb.AppendLine($"Cancelled: {cancelled}");

                sb.AppendLine();
                sb.AppendLine("=== REVENUE ===");
                sb.AppendLine($"Total Revenue from Completed Rentals: BDT {totalRevenue:N2}");
                if (completed > 0)
                    sb.AppendLine($"Average Revenue per Completed Booking: BDT {totalRevenue / completed:N2}");

                // Most rented cars
                var topCars = bookings.AsEnumerable()
                    .GroupBy(r => r["CarDetails"]?.ToString() ?? "Unknown")
                    .OrderByDescending(g => g.Count())
                    .Take(3)
                    .Select(g => $"{g.Key}: {g.Count()} booking(s)");
                if (topCars.Any())
                {
                    sb.AppendLine();
                    sb.AppendLine("=== TOP RENTED CARS ===");
                    foreach (var car in topCars) sb.AppendLine(car);
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"[Data load error: {ex.Message}]");
            }

            return sb.ToString();
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
