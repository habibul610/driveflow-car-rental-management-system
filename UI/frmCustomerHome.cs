using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmCustomerHome : Form
    {
        private BookingBLL bookingBLL = new BookingBLL();

        public frmCustomerHome()
        {
            InitializeComponent();
            
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.DrawAvatar(pnlAvatar, SessionManager.CurrentUser?.FullName ?? "Customer");
            
            // Sidebar buttons hover effect
            Button[] sidebarButtons = { btnBrowseCars, btnMyBookings, btnMyBills, btnProfile, btnCompareCars, btnMessages, btnAISuggestions };
            foreach (var btn in sidebarButtons)
            {
                btn.MouseEnter += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(20, 45, 84); // Darker navy
                btn.MouseLeave += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            }

            // Add Feedback button dynamically (to avoid designer conflicts)
            Button btnFeedback = new Button
            {
                Text = "💬 Feedback",
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
            
            // Assuming the sidebar panel is named pnlSidebar
            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnFeedback); btnFeedback.BringToFront();
                    break;
                }
            }

            // Add Reviews button dynamically
            Button btnReviews = new Button
            {
                Text = "⭐ Reviews",
                Name = "btnReviews",
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
            btnReviews.FlatAppearance.BorderSize = 0;
            btnReviews.Click += (s, e) => { new frmReviews(this).Show(); this.Hide(); };
            btnReviews.MouseEnter += (s, ev) => btnReviews.BackColor = System.Drawing.Color.FromArgb(20, 45, 84);
            btnReviews.MouseLeave += (s, ev) => btnReviews.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            
            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnReviews);
                    btnReviews.BringToFront();
                    break;
                }
            }
        }

        private void frmCustomerHome_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn() || SessionManager.CurrentUser.Role != "Customer")
            {
                MessageBox.Show("Session expired or unauthorized. Please login again.");
                Logout();
                return;
            }

            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName}!";
            lblWelcomeMessage.Text = $"Welcome back, {SessionManager.CurrentUser.FullName}! Here's your rental summary:";
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            try
            {
                DataTable bookings = bookingBLL.GetBookingsByUserID(SessionManager.CurrentUser.UserID);
                int totalBookings = bookings.Rows.Count;
                int activeBookings = bookings.AsEnumerable().Count(r => 
                    r["Status"].ToString() == "Active" || r["Status"].ToString() == "Pending");

                lblTotalBookings.Text = totalBookings.ToString();
                lblActiveBookings.Text = activeBookings.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dashboard Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseCars_Click(object sender, EventArgs e)
        {
            new frmMakeBooking(this).Show();
            this.Hide();
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            new frmMyBookings(this).Show();
            this.Hide();
        }

        private void btnMyBills_Click(object sender, EventArgs e)
        {
            new frmBillingRecord(this).Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile(this);
            profile.Show();
            this.Hide();
        }

        private void btnCompareCars_Click(object sender, EventArgs e)
        {
            frmCarComparison compare = new frmCarComparison(this);
            compare.Show();
            this.Hide();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            new frmMessages(this).Show();
            this.Hide();
        }

        private void btnAISuggestions_Click(object sender, EventArgs e)
        {
            new frmCustomerChat(this).Show();
            this.Hide();
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

        private void frmCustomerHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!SessionManager.IsLoggedIn()) return;
            Application.Exit();
        }
    }
}
