using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmAdminHome : Form
    {
        private CarBLL carBLL = new CarBLL();
        private BookingBLL bookingBLL = new BookingBLL();

        public frmAdminHome()
        {
            InitializeComponent();
            this.Text = "DriveFlow - Administrator Panel";
            
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.DrawAvatar(pnlAvatar, SessionManager.CurrentUser?.FullName ?? "Admin");
            
            ComboBox cmbEarningsFilter = new ComboBox { Name = "cmbEarningsFilter", Location = new System.Drawing.Point(585, 5), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEarningsFilter.Items.AddRange(new string[] { "All Time", "This Week", "This Month" });
            cmbEarningsFilter.SelectedIndex = 0;
            cmbEarningsFilter.SelectedIndexChanged += (s, e) => LoadDashboardData();
            pnlContent.Controls.Add(cmbEarningsFilter);
            cmbEarningsFilter.BringToFront();
            
            // Sidebar buttons hover effect
            Button[] sidebarButtons = { btnManageCars, btnManageUsers, btnManageBookings, btnBillingRecords, btnProfile, btnMessages, btnGPSTracker, btnAIInsights, btnRandomizeImages };
            foreach (var btn in sidebarButtons)
            {
                btn.MouseEnter += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(20, 45, 84); // Darker navy
                btn.MouseLeave += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            }

            // Add Feedback button dynamically
            Button btnFeedback = new Button
            {
                Text = "💬 Feedback Logs",
                Name = "btnFeedback",
                Dock = DockStyle.Top,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(27, 58, 107),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10F)
            };
            btnFeedback.FlatAppearance.BorderSize = 0;
            btnFeedback.Click += (s, e) => { new frmFeedback(this).Show(); this.Hide(); };
            btnFeedback.MouseEnter += (s, ev) => btnFeedback.BackColor = System.Drawing.Color.FromArgb(20, 45, 84);
            btnFeedback.MouseLeave += (s, ev) => btnFeedback.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            
            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnFeedback);
                    btnFeedback.BringToFront();
                    break;
                }
            }

            // Add AI Chat button dynamically
            Button btnAIChat = new Button
            {
                Text = "💬 AI Business Chat",
                Name = "btnAIChat",
                Dock = DockStyle.Top,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(27, 58, 107),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10F)
            };
            btnAIChat.FlatAppearance.BorderSize = 0;
            btnAIChat.Click += (s, e) => { new frmAdminChat(this).Show(); this.Hide(); };
            btnAIChat.MouseEnter += (s, ev) => btnAIChat.BackColor = System.Drawing.Color.FromArgb(20, 45, 84);
            btnAIChat.MouseLeave += (s, ev) => btnAIChat.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);

            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnAIChat);
                    btnAIChat.BringToFront();
                    break;
                }
            }

            // Dynamic Buttons
            Button btnCoupons = CreateSidebarBtn("🎟️ Manage Coupons", "btnManageCoupons");
            btnCoupons.Click += (s, e) => { new frmManageCoupons(this).Show(); this.Hide(); };
            
            Button btnReviews = CreateSidebarBtn("⭐ Reviews", "btnReviews");
            btnReviews.Click += (s, e) => { new frmReviews(this).Show(); this.Hide(); };

            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnCoupons); btnCoupons.BringToFront();
                    c.Controls.Add(btnReviews); btnReviews.BringToFront();
                    break;
                }
            }
        }

        private Button CreateSidebarBtn(string text, string name)
        {
            Button btn = new Button
            {
                Text = text, Name = name, Dock = DockStyle.Top, Height = 45, FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White, BackColor = System.Drawing.Color.FromArgb(27, 58, 107),
                Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10F)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(20, 45, 84);
            btn.MouseLeave += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            return btn;
        }

        private void frmAdminHome_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn() || SessionManager.CurrentUser.Role != "Admin")
            {
                MessageBox.Show("Session expired or unauthorized. Please login again.");
                Logout();
                return;
            }

            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName}!";
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            try
            {
                DataTable cars = carBLL.GetAllCars();
                int totalCars = cars.Rows.Count;
                int availableCars = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Available");

                DataTable bookings = bookingBLL.GetAllBookings();
                int totalBookings = bookings.Rows.Count;
                int activeBookings = bookings.AsEnumerable().Count(r => r["Status"].ToString() == "Active");

                // Revenue: sum TotalAmount from all Completed bookings
                DateTime? startDate = null;
                var cmb = this.Controls.Find("cmbEarningsFilter", true).FirstOrDefault() as ComboBox;
                if (cmb != null)
                {
                    if (cmb.SelectedIndex == 1) startDate = DateTime.Today.AddDays(-7);
                    else if (cmb.SelectedIndex == 2) startDate = DateTime.Today.AddMonths(-1);
                }

                decimal totalRevenue = bookingBLL.GetEarnings(startDate);

                lblTotalCars.Text = totalCars.ToString();
                lblAvailableCars.Text = availableCars.ToString();
                lblActiveBookings.Text = activeBookings.ToString();
                lblTotalRevenue.Text = UIHelper.FormatBDT(totalRevenue);

                // Configure PieChart (L-9: Avoid crash on all-zero fleet)
                if (totalCars > 0)
                {
                    int rentedCars = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Rented");
                    int maintenanceCars = cars.AsEnumerable().Count(r => r["Status"].ToString() == "Maintenance");

                    pieChartFleet.Series = new ISeries[]
                    {
                        new PieSeries<int> { Values = new[] { availableCars }, Name = "Available" },
                        new PieSeries<int> { Values = new[] { rentedCars }, Name = "Rented" },
                        new PieSeries<int> { Values = new[] { maintenanceCars }, Name = "Maintenance" }
                    };
                }
                else
                {
                    pieChartFleet.Series = new ISeries[] { };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dashboard Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageCars_Click(object sender, EventArgs e)
        {
            new frmManageCars(this).Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            new frmManageUsers(this).Show();
            this.Hide();
        }

        private void btnManageBookings_Click(object sender, EventArgs e)
        {
            new frmManageBookings(this).Show();
            this.Hide();
        }

        private void btnBillingRecords_Click(object sender, EventArgs e)
        {
            new frmBillingRecord(this).Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            new frmProfile(this).Show();
            this.Hide();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            new frmMessages(this).Show();
            this.Hide();
        }

        private void btnGPSTracker_Click(object sender, EventArgs e)
        {
            new frmGPSSimulation(this).Show();
            this.Hide();
        }

        private void btnAIInsights_Click(object sender, EventArgs e)
        {
            new frmAIInsights(this).Show();
            this.Hide();
        }

        private void btnRandomizeImages_Click(object sender, EventArgs e)
        {
            try
            {
                string imagesPath = System.IO.Path.Combine(Application.StartupPath, "images");
                string[] fileNames = {
                    "andrew-pons-Os7C4iw2rDc-unsplash.jpg", "dhiva-krishna-X16zXcbxU4U-unsplash.jpg",
                    "florian-schneider-799KfBloSFQ-unsplash.jpg", "grahame-jenkins-p7tai9P7H-s-unsplash.jpg",
                    "joey-banks-YApiWyp0lqo-unsplash.jpg", "jon-flobrant-lRSChvh1Mhs-unsplash.jpg",
                    "jonathan-gallegos-5FGqfV6UjzI-unsplash.jpg", "josh-berquist-_4sWbzH5fp8-unsplash.jpg",
                    "joshua-koblin-eqW1MPinEV4-unsplash.jpg", "lance-asper-N9Pf2J656aQ-unsplash.jpg",
                    "peter-broomfield-m3m-lnR90uM-unsplash.jpg", "roberto-nickson-zu95jkyrGtw-unsplash (1).jpg",
                    "roberto-nickson-zu95jkyrGtw-unsplash.jpg", "tyler-clemmensen-d1Jum1vVLew-unsplash.jpg",
                    "ville-kaisla-HNCSCpWrVJA-unsplash.jpg"
                };

                // Validate: only pass files that actually exist on disk
                var existingFiles = fileNames
                    .Where(f => System.IO.File.Exists(System.IO.Path.Combine(imagesPath, f)))
                    .ToArray();

                if (existingFiles.Length == 0)
                {
                    MessageBox.Show(
                        $"No image files found in:\n{imagesPath}\n\nPlease add car images to that folder first.",
                        "No Images Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new CarBLL().AssignRandomImages(existingFiles);
                MessageBox.Show(
                    $"Successfully randomized images using {existingFiles.Length} available image(s)!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error randomizing images: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Logout();
            }
        }

        private void Logout()
        {
            SessionManager.ClearSession();
            var loginForm = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                new frmLogin().Show();
            }
            this.Close();
        }

        private void frmAdminHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!SessionManager.IsLoggedIn()) return;
            Application.Exit();
        }
    }
}
