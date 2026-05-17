namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmManagerHome
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnManageCars;
        private System.Windows.Forms.Button btnManageBookings;
        private System.Windows.Forms.Button btnBillingRecords;
        private System.Windows.Forms.Button btnMessages;
        private System.Windows.Forms.Button btnGPSTracker;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderLogo = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnManageCars = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.btnBillingRecords = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.btnGPSTracker = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.lblHeaderLogo);
            this.pnlHeader.Controls.Add(this.pnlAvatar);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            
            // lblHeaderLogo
            this.lblHeaderLogo.AutoSize = true;
            this.lblHeaderLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLogo.ForeColor = System.Drawing.Color.White;
            this.lblHeaderLogo.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderLogo.Text = "🚗 DriveFlow - Manager";
            
            // lblWelcome
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(500, 20);
            this.lblWelcome.Size = new System.Drawing.Size(430, 20);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWelcome.Text = "Welcome, Manager!";
            
            // pnlAvatar
            this.pnlAvatar.Location = new System.Drawing.Point(940, 10);
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnGPSTracker);
            this.pnlSidebar.Controls.Add(this.btnMessages);
            this.pnlSidebar.Controls.Add(this.btnBillingRecords);
            this.pnlSidebar.Controls.Add(this.btnManageBookings);
            this.pnlSidebar.Controls.Add(this.btnManageCars);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(200, 540);
            
            // btnManageCars
            this.btnManageCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCars.ForeColor = System.Drawing.Color.White;
            this.btnManageCars.Height = 50;
            this.btnManageCars.Text = "🚗 Manage Cars";
            
            // btnManageBookings
            this.btnManageBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBookings.ForeColor = System.Drawing.Color.White;
            this.btnManageBookings.Height = 50;
            this.btnManageBookings.Text = "📋 Manage Bookings";
            
            // btnBillingRecords
            this.btnBillingRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBillingRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillingRecords.ForeColor = System.Drawing.Color.White;
            this.btnBillingRecords.Height = 50;
            this.btnBillingRecords.Text = "💳 Billing Records";
            
            // btnMessages
            this.btnMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessages.ForeColor = System.Drawing.Color.White;
            this.btnMessages.Height = 50;
            this.btnMessages.Text = "💬 Messages";
            
            // btnGPSTracker
            this.btnGPSTracker.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGPSTracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPSTracker.ForeColor = System.Drawing.Color.White;
            this.btnGPSTracker.Height = 50;
            this.btnGPSTracker.Text = "🛰 GPS Tracker";
            
            // btnProfile
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Height = 50;
            this.btnProfile.Text = "👤 My Profile";
            
            // btnLogout
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Height = 50;
            this.btnLogout.Text = "Logout";
            
            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // frmManagerHome
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Manager Dashboard";
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
