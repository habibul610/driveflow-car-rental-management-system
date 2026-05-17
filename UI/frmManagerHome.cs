using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmManagerHome : Form
    {
        private MessageBLL messageBLL = new MessageBLL();

        public frmManagerHome()
        {
            InitializeComponent();
            
            // Apply modern UI styling (consistent with AdminHome)
            UIHelper.SetupForm(this);
            
            this.Load += frmManagerHome_Load;
            this.btnManageCars.Click += (s, e) => { new frmManageCars(this).Show(); this.Hide(); };
            this.btnManageBookings.Click += (s, e) => { new frmManageBookings(this).Show(); this.Hide(); };
            this.btnBillingRecords.Click += (s, e) => { new frmBillingRecord(this).Show(); this.Hide(); };
            this.btnMessages.Click += (s, e) => { new frmMessages(this).Show(); this.Hide(); };
            this.btnGPSTracker.Click += (s, e) => { new frmGPSSimulation(this).Show(); this.Hide(); };
            this.btnProfile.Click += (s, e) => { new frmProfile(this).Show(); this.Hide(); };
            this.btnLogout.Click += btnLogout_Click;
            this.FormClosed += frmManagerHome_FormClosed;

            // Sidebar styling loop
            Button[] sidebarButtons = { btnManageCars, btnManageBookings, btnBillingRecords, btnMessages, btnGPSTracker, btnProfile };
            foreach (var btn in sidebarButtons)
            {
                btn.MouseEnter += (s, ev) => btn.BackColor = Color.FromArgb(20, 45, 84);
                btn.MouseLeave += (s, ev) => btn.BackColor = Color.FromArgb(27, 58, 107);
            }

            // Add Feedback button dynamically
            Button btnFeedback = new Button
            {
                Text = "💬 Feedback Logs",
                Name = "btnFeedback",
                Dock = DockStyle.Top,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(27, 58, 107),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10F)
            };
            btnFeedback.FlatAppearance.BorderSize = 0;
            btnFeedback.Click += (s, e) => { new frmFeedback(this).Show(); this.Hide(); };
            btnFeedback.MouseEnter += (s, ev) => btnFeedback.BackColor = Color.FromArgb(20, 45, 84);
            btnFeedback.MouseLeave += (s, ev) => btnFeedback.BackColor = Color.FromArgb(27, 58, 107);
            
            foreach (Control c in this.Controls)
            {
                if (c.Name == "pnlSidebar" || (c is Panel && c.Dock == DockStyle.Left))
                {
                    c.Controls.Add(btnFeedback); btnFeedback.BringToFront();
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
                ForeColor = Color.White, BackColor = Color.FromArgb(27, 58, 107),
                Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10F)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, ev) => btn.BackColor = Color.FromArgb(20, 45, 84);
            btn.MouseLeave += (s, ev) => btn.BackColor = Color.FromArgb(27, 58, 107);
            return btn;
        }

        private void frmManagerHome_Load(object sender, EventArgs e)
        {
            // Security check (C-3)
            if (!SessionManager.IsLoggedIn() || (SessionManager.CurrentUser.Role != "Manager" && SessionManager.CurrentUser.Role != "Admin"))
            {
                MessageBox.Show("Unauthorized access. Please login.");
                Logout();
                return;
            }

            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName}!";
            UIHelper.DrawAvatar(pnlAvatar, SessionManager.CurrentUser.FullName);
            UpdateUnreadBadge();
        }

        private void UpdateUnreadBadge()
        {
            int unread = messageBLL.GetUnreadMessageCount(SessionManager.CurrentUser.UserID);
            if (unread > 0)
                btnMessages.Text = $"💬 Messages ({unread})";
            else
                btnMessages.Text = "💬 Messages";
        }

        public void RefreshWelcome()
        {
            if (SessionManager.IsLoggedIn())
            {
                lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser.FullName}!";
                UIHelper.DrawAvatar(pnlAvatar, SessionManager.CurrentUser.FullName);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            SessionManager.ClearSession();
            var loginForm = System.Linq.Enumerable.FirstOrDefault(Application.OpenForms.OfType<frmLogin>());
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

        private void frmManagerHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If session is still active (user closed via X without logging out),
            // show the login form instead of silently killing the app.
            if (SessionManager.IsLoggedIn())
            {
                SessionManager.ClearSession();
                var loginForm = System.Linq.Enumerable.FirstOrDefault(Application.OpenForms.OfType<frmLogin>());
                if (loginForm != null)
                    loginForm.Show();
                else
                    new frmLogin().Show();
            }
        }
    }
}
