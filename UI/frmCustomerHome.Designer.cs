namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmCustomerHome
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlAvatar;
        
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnBrowseCars;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Button btnMyBills;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnCompareCars;
        private System.Windows.Forms.Button btnMessages;
        private System.Windows.Forms.Button btnAISuggestions;
        private System.Windows.Forms.Button btnLogout;
        
        private System.Windows.Forms.Panel pnlContent;
        
        private System.Windows.Forms.Label lblWelcomeMessage;
        
        private System.Windows.Forms.Panel cardTotalBookings;
        private System.Windows.Forms.Label iconTotalBookings;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label titleTotalBookings;
        
        private System.Windows.Forms.Panel cardActiveBookings;
        private System.Windows.Forms.Label iconActiveBookings;
        private System.Windows.Forms.Label lblActiveBookings;
        private System.Windows.Forms.Label titleActiveBookings;
        
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
            this.btnBrowseCars = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.btnMyBills = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnCompareCars = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.btnAISuggestions = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            
            this.cardTotalBookings = new System.Windows.Forms.Panel();
            this.iconTotalBookings = new System.Windows.Forms.Label();
            this.lblTotalBookings = new System.Windows.Forms.Label();
            this.titleTotalBookings = new System.Windows.Forms.Label();
            
            this.cardActiveBookings = new System.Windows.Forms.Panel();
            this.iconActiveBookings = new System.Windows.Forms.Label();
            this.lblActiveBookings = new System.Windows.Forms.Label();
            this.titleActiveBookings = new System.Windows.Forms.Label();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.cardTotalBookings.SuspendLayout();
            this.cardActiveBookings.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.lblHeaderLogo);
            this.pnlHeader.Controls.Add(this.pnlAvatar);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            
            // lblHeaderLogo
            this.lblHeaderLogo.AutoSize = true;
            this.lblHeaderLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLogo.ForeColor = System.Drawing.Color.White;
            this.lblHeaderLogo.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderLogo.Name = "lblHeaderLogo";
            this.lblHeaderLogo.Size = new System.Drawing.Size(100, 30);
            this.lblHeaderLogo.Text = "🚗 DriveFlow";
            
            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(400, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(420, 20);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWelcome.Text = "Welcome, Customer!";
            
            // pnlAvatar
            this.pnlAvatar.Location = new System.Drawing.Point(840, 10);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnAISuggestions);
            this.pnlSidebar.Controls.Add(this.btnMessages);
            this.pnlSidebar.Controls.Add(this.btnCompareCars);
            this.pnlSidebar.Controls.Add(this.btnMyBills);
            this.pnlSidebar.Controls.Add(this.btnMyBookings);
            this.pnlSidebar.Controls.Add(this.btnBrowseCars);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.pnlSidebar.Size = new System.Drawing.Size(200, 540);
            this.pnlSidebar.TabIndex = 1;
            
            // btnBrowseCars
            this.btnBrowseCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrowseCars.FlatAppearance.BorderSize = 0;
            this.btnBrowseCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseCars.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnBrowseCars.ForeColor = System.Drawing.Color.White;
            this.btnBrowseCars.Location = new System.Drawing.Point(0, 20);
            this.btnBrowseCars.Name = "btnBrowseCars";
            this.btnBrowseCars.Size = new System.Drawing.Size(200, 45);
            this.btnBrowseCars.Text = "🚗 Browse Cars && Book";
            this.btnBrowseCars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseCars.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBrowseCars.Click += new System.EventHandler(this.btnBrowseCars_Click);
            
            // btnMyBookings
            this.btnMyBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyBookings.FlatAppearance.BorderSize = 0;
            this.btnMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnMyBookings.ForeColor = System.Drawing.Color.White;
            this.btnMyBookings.Location = new System.Drawing.Point(0, 65);
            this.btnMyBookings.Name = "btnMyBookings";
            this.btnMyBookings.Size = new System.Drawing.Size(200, 45);
            this.btnMyBookings.Text = "📋 My Bookings";
            this.btnMyBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyBookings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMyBookings.Click += new System.EventHandler(this.btnMyBookings_Click);
            
            // btnMyBills
            this.btnMyBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyBills.FlatAppearance.BorderSize = 0;
            this.btnMyBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBills.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnMyBills.ForeColor = System.Drawing.Color.White;
            this.btnMyBills.Location = new System.Drawing.Point(0, 110);
            this.btnMyBills.Name = "btnMyBills";
            this.btnMyBills.Size = new System.Drawing.Size(200, 45);
            this.btnMyBills.Text = "💳 My Bills";
            this.btnMyBills.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyBills.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMyBills.Click += new System.EventHandler(this.btnMyBills_Click);
            
            // btnProfile
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(0, 155);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(200, 45);
            this.btnProfile.Text = "👤 My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            
            // btnCompareCars
            this.btnCompareCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompareCars.FlatAppearance.BorderSize = 0;
            this.btnCompareCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompareCars.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnCompareCars.ForeColor = System.Drawing.Color.White;
            this.btnCompareCars.Location = new System.Drawing.Point(0, 200);
            this.btnCompareCars.Name = "btnCompareCars";
            this.btnCompareCars.Size = new System.Drawing.Size(200, 45);
            this.btnCompareCars.Text = "⚖️ Compare Cars";
            this.btnCompareCars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompareCars.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCompareCars.Click += new System.EventHandler(this.btnCompareCars_Click);

            // btnMessages
            this.btnMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMessages.FlatAppearance.BorderSize = 0;
            this.btnMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnMessages.ForeColor = System.Drawing.Color.White;
            this.btnMessages.Location = new System.Drawing.Point(0, 245);
            this.btnMessages.Name = "btnMessages";
            this.btnMessages.Size = new System.Drawing.Size(200, 45);
            this.btnMessages.Text = "💬 Messages";
            this.btnMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessages.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMessages.Click += new System.EventHandler(this.btnMessages_Click);
            
            // btnAISuggestions
            this.btnAISuggestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAISuggestions.FlatAppearance.BorderSize = 0;
            this.btnAISuggestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAISuggestions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAISuggestions.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0); // Gold
            this.btnAISuggestions.Location = new System.Drawing.Point(0, 290);
            this.btnAISuggestions.Name = "btnAISuggestions";
            this.btnAISuggestions.Size = new System.Drawing.Size(200, 45);
            this.btnAISuggestions.Text = "✨ AI Car Finder";
            this.btnAISuggestions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAISuggestions.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAISuggestions.Click += new System.EventHandler(this.btnAISuggestions_Click);
            
            // btnLogout
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(153, 27, 27); // #991B1B
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 475);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            
            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlContent.Controls.Add(this.lblWelcomeMessage);
            this.pnlContent.Controls.Add(this.cardTotalBookings);
            this.pnlContent.Controls.Add(this.cardActiveBookings);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30);
            this.pnlContent.Size = new System.Drawing.Size(700, 540);
            this.pnlContent.TabIndex = 2;
            
            // lblWelcomeMessage
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblWelcomeMessage.Location = new System.Drawing.Point(30, 30);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(331, 32);
            this.lblWelcomeMessage.Text = "Here's your rental summary";
            
            int cardWidth = 150;
            int cardHeight = 100;
            int gap = 15;
            int currentX = 30;
            int currentY = 80;
            
            // cardTotalBookings
            this.cardTotalBookings.BackColor = System.Drawing.Color.White;
            this.cardTotalBookings.Controls.Add(this.iconTotalBookings);
            this.cardTotalBookings.Controls.Add(this.lblTotalBookings);
            this.cardTotalBookings.Controls.Add(this.titleTotalBookings);
            this.cardTotalBookings.Location = new System.Drawing.Point(currentX, currentY);
            this.cardTotalBookings.Size = new System.Drawing.Size(cardWidth, cardHeight);
            
            this.iconTotalBookings.AutoSize = true;
            this.iconTotalBookings.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconTotalBookings.Location = new System.Drawing.Point(15, 15);
            this.iconTotalBookings.Text = "📋";
            
            this.lblTotalBookings.AutoSize = true;
            this.lblTotalBookings.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalBookings.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalBookings.Location = new System.Drawing.Point(12, 35);
            this.lblTotalBookings.Text = "0";
            
            this.titleTotalBookings.AutoSize = true;
            this.titleTotalBookings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleTotalBookings.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.titleTotalBookings.Location = new System.Drawing.Point(15, 75);
            this.titleTotalBookings.Text = "Total Bookings";
            currentX += cardWidth + gap;
            
            // cardActiveBookings
            this.cardActiveBookings.BackColor = System.Drawing.Color.White;
            this.cardActiveBookings.Controls.Add(this.iconActiveBookings);
            this.cardActiveBookings.Controls.Add(this.lblActiveBookings);
            this.cardActiveBookings.Controls.Add(this.titleActiveBookings);
            this.cardActiveBookings.Location = new System.Drawing.Point(currentX, currentY);
            this.cardActiveBookings.Size = new System.Drawing.Size(cardWidth, cardHeight);
            
            this.iconActiveBookings.AutoSize = true;
            this.iconActiveBookings.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconActiveBookings.Location = new System.Drawing.Point(15, 15);
            this.iconActiveBookings.Text = "🚗";
            
            this.lblActiveBookings.AutoSize = true;
            this.lblActiveBookings.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblActiveBookings.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblActiveBookings.Location = new System.Drawing.Point(12, 35);
            this.lblActiveBookings.Text = "0";
            
            this.titleActiveBookings.AutoSize = true;
            this.titleActiveBookings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleActiveBookings.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.titleActiveBookings.Location = new System.Drawing.Point(15, 75);
            this.titleActiveBookings.Text = "Active Bookings";
            
            // frmCustomerHome
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCustomerHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Customer Dashboard";
            this.Load += new System.EventHandler(this.frmCustomerHome_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomerHome_FormClosed);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.cardTotalBookings.ResumeLayout(false);
            this.cardTotalBookings.PerformLayout();
            this.cardActiveBookings.ResumeLayout(false);
            this.cardActiveBookings.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
