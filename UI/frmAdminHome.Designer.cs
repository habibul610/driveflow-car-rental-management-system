namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmAdminHome
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlAvatar;
        
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnManageCars;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageBookings;
        private System.Windows.Forms.Button btnBillingRecords;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMessages;
        private System.Windows.Forms.Button btnGPSTracker;
        private System.Windows.Forms.Button btnAIInsights;
        private System.Windows.Forms.Button btnRandomizeImages;
        private System.Windows.Forms.Button btnLogout;
        
        private System.Windows.Forms.Panel pnlContent;
        
        private System.Windows.Forms.Panel cardTotalCars;
        private System.Windows.Forms.Label iconTotalCars;
        private System.Windows.Forms.Label lblTotalCars;
        private System.Windows.Forms.Label titleTotalCars;
        
        private System.Windows.Forms.Panel cardAvailableCars;
        private System.Windows.Forms.Label iconAvailableCars;
        private System.Windows.Forms.Label lblAvailableCars;
        private System.Windows.Forms.Label titleAvailableCars;
        
        private System.Windows.Forms.Panel cardActiveBookings;
        private System.Windows.Forms.Label iconActiveBookings;
        private System.Windows.Forms.Label lblActiveBookings;
        private System.Windows.Forms.Label titleActiveBookings;
        
        private System.Windows.Forms.Panel cardTotalRevenue;
        private System.Windows.Forms.Label iconTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label titleTotalRevenue;
        
        private System.Windows.Forms.Label lblTotalBookings; // hidden field
        
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChartFleet;
        
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
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.btnBillingRecords = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.btnGPSTracker = new System.Windows.Forms.Button();
            this.btnAIInsights = new System.Windows.Forms.Button();
            this.btnRandomizeImages = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            
            this.pnlContent = new System.Windows.Forms.Panel();
            
            this.cardTotalCars = new System.Windows.Forms.Panel();
            this.iconTotalCars = new System.Windows.Forms.Label();
            this.lblTotalCars = new System.Windows.Forms.Label();
            this.titleTotalCars = new System.Windows.Forms.Label();
            
            this.cardAvailableCars = new System.Windows.Forms.Panel();
            this.iconAvailableCars = new System.Windows.Forms.Label();
            this.lblAvailableCars = new System.Windows.Forms.Label();
            this.titleAvailableCars = new System.Windows.Forms.Label();
            
            this.cardActiveBookings = new System.Windows.Forms.Panel();
            this.iconActiveBookings = new System.Windows.Forms.Label();
            this.lblActiveBookings = new System.Windows.Forms.Label();
            this.titleActiveBookings = new System.Windows.Forms.Label();
            
            this.cardTotalRevenue = new System.Windows.Forms.Panel();
            this.iconTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.titleTotalRevenue = new System.Windows.Forms.Label();
            
            this.lblTotalBookings = new System.Windows.Forms.Label();
            this.pieChartFleet = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.cardTotalCars.SuspendLayout();
            this.cardAvailableCars.SuspendLayout();
            this.cardActiveBookings.SuspendLayout();
            this.cardTotalRevenue.SuspendLayout();
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
            this.lblWelcome.Text = "Welcome, Admin!";
            
            // pnlAvatar
            this.pnlAvatar.Location = new System.Drawing.Point(840, 10);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlSidebar.Controls.Add(this.btnLogout); // Dock Bottom
            this.pnlSidebar.Controls.Add(this.btnRandomizeImages);
            this.pnlSidebar.Controls.Add(this.btnAIInsights);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnGPSTracker);
            this.pnlSidebar.Controls.Add(this.btnMessages);
            this.pnlSidebar.Controls.Add(this.btnBillingRecords);
            this.pnlSidebar.Controls.Add(this.btnManageBookings);
            this.pnlSidebar.Controls.Add(this.btnManageUsers);
            this.pnlSidebar.Controls.Add(this.btnManageCars);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.pnlSidebar.Size = new System.Drawing.Size(200, 540);
            this.pnlSidebar.TabIndex = 1;
            
            // btnManageCars
            this.btnManageCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageCars.FlatAppearance.BorderSize = 0;
            this.btnManageCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCars.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnManageCars.ForeColor = System.Drawing.Color.White;
            this.btnManageCars.Location = new System.Drawing.Point(0, 20);
            this.btnManageCars.Name = "btnManageCars";
            this.btnManageCars.Size = new System.Drawing.Size(200, 45);
            this.btnManageCars.Text = "🚗 Manage Cars";
            this.btnManageCars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCars.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageCars.Click += new System.EventHandler(this.btnManageCars_Click);
            
            // btnManageUsers
            this.btnManageUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(0, 65);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(200, 45);
            this.btnManageUsers.Text = "👥 Manage Users";
            this.btnManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUsers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            
            // btnManageBookings
            this.btnManageBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageBookings.FlatAppearance.BorderSize = 0;
            this.btnManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnManageBookings.ForeColor = System.Drawing.Color.White;
            this.btnManageBookings.Location = new System.Drawing.Point(0, 110);
            this.btnManageBookings.Name = "btnManageBookings";
            this.btnManageBookings.Size = new System.Drawing.Size(200, 45);
            this.btnManageBookings.Text = "📋 Manage Bookings";
            this.btnManageBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageBookings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageBookings.Click += new System.EventHandler(this.btnManageBookings_Click);
            
            // btnBillingRecords
            this.btnBillingRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBillingRecords.FlatAppearance.BorderSize = 0;
            this.btnBillingRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillingRecords.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnBillingRecords.ForeColor = System.Drawing.Color.White;
            this.btnBillingRecords.Location = new System.Drawing.Point(0, 155);
            this.btnBillingRecords.Name = "btnBillingRecords";
            this.btnBillingRecords.Size = new System.Drawing.Size(200, 45);
            this.btnBillingRecords.Text = "💳 Billing Records";
            this.btnBillingRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBillingRecords.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBillingRecords.Click += new System.EventHandler(this.btnBillingRecords_Click);
            
            // btnProfile
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(0, 200);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(200, 45);
            this.btnProfile.Text = "👤 My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            
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

            // btnGPSTracker
            this.btnGPSTracker.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGPSTracker.FlatAppearance.BorderSize = 0;
            this.btnGPSTracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPSTracker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnGPSTracker.ForeColor = System.Drawing.Color.White;
            this.btnGPSTracker.Location = new System.Drawing.Point(0, 290);
            this.btnGPSTracker.Name = "btnGPSTracker";
            this.btnGPSTracker.Size = new System.Drawing.Size(200, 45);
            this.btnGPSTracker.Text = "🛰 GPS Tracker";
            this.btnGPSTracker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGPSTracker.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnGPSTracker.Click += new System.EventHandler(this.btnGPSTracker_Click);
            
            // btnAIInsights
            this.btnAIInsights.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAIInsights.FlatAppearance.BorderSize = 0;
            this.btnAIInsights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIInsights.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAIInsights.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0); // Gold
            this.btnAIInsights.Location = new System.Drawing.Point(0, 335);
            this.btnAIInsights.Name = "btnAIInsights";
            this.btnAIInsights.Size = new System.Drawing.Size(200, 45);
            this.btnAIInsights.Text = "✨ AI Business Insights";
            this.btnAIInsights.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAIInsights.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAIInsights.Click += new System.EventHandler(this.btnAIInsights_Click);
            
            // btnRandomizeImages
            this.btnRandomizeImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRandomizeImages.FlatAppearance.BorderSize = 0;
            this.btnRandomizeImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandomizeImages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.btnRandomizeImages.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253); // Light blue
            this.btnRandomizeImages.Location = new System.Drawing.Point(0, 380);
            this.btnRandomizeImages.Name = "btnRandomizeImages";
            this.btnRandomizeImages.Size = new System.Drawing.Size(200, 45);
            this.btnRandomizeImages.Text = "🖼 Randomize Car Images";
            this.btnRandomizeImages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandomizeImages.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRandomizeImages.Click += new System.EventHandler(this.btnRandomizeImages_Click);
            
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
            this.pnlContent.Controls.Add(this.cardTotalCars);
            this.pnlContent.Controls.Add(this.cardAvailableCars);
            this.pnlContent.Controls.Add(this.cardActiveBookings);
            this.pnlContent.Controls.Add(this.cardTotalRevenue);
            this.pnlContent.Controls.Add(this.lblTotalBookings); // hidden
            this.pnlContent.Controls.Add(this.pieChartFleet);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30);
            this.pnlContent.Size = new System.Drawing.Size(700, 540);
            this.pnlContent.TabIndex = 2;
            
            int cardWidth = 170;
            int cardHeight = 100;
            int gap = 15;
            int currentX = 30;
            
            // cardTotalCars
            this.cardTotalCars.BackColor = System.Drawing.Color.White;
            this.cardTotalCars.Controls.Add(this.iconTotalCars);
            this.cardTotalCars.Controls.Add(this.lblTotalCars);
            this.cardTotalCars.Controls.Add(this.titleTotalCars);
            this.cardTotalCars.Location = new System.Drawing.Point(currentX, 30);
            this.cardTotalCars.Size = new System.Drawing.Size(cardWidth, cardHeight);
            
            this.iconTotalCars.AutoSize = true;
            this.iconTotalCars.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconTotalCars.Location = new System.Drawing.Point(15, 15);
            this.iconTotalCars.Text = "🚗";
            
            this.lblTotalCars.AutoSize = true;
            this.lblTotalCars.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalCars.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalCars.Location = new System.Drawing.Point(12, 35);
            this.lblTotalCars.Text = "0";
            
            this.titleTotalCars.AutoSize = true;
            this.titleTotalCars.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleTotalCars.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.titleTotalCars.Location = new System.Drawing.Point(15, 75);
            this.titleTotalCars.Text = "Total Cars";
            
            currentX += cardWidth + gap;
            
            // cardAvailableCars
            this.cardAvailableCars.BackColor = System.Drawing.Color.White;
            this.cardAvailableCars.Controls.Add(this.iconAvailableCars);
            this.cardAvailableCars.Controls.Add(this.lblAvailableCars);
            this.cardAvailableCars.Controls.Add(this.titleAvailableCars);
            this.cardAvailableCars.Location = new System.Drawing.Point(currentX, 30);
            this.cardAvailableCars.Size = new System.Drawing.Size(cardWidth, cardHeight);
            
            this.iconAvailableCars.AutoSize = true;
            this.iconAvailableCars.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconAvailableCars.Location = new System.Drawing.Point(15, 15);
            this.iconAvailableCars.Text = "✅";
            
            this.lblAvailableCars.AutoSize = true;
            this.lblAvailableCars.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAvailableCars.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblAvailableCars.Location = new System.Drawing.Point(12, 35);
            this.lblAvailableCars.Text = "0";
            
            this.titleAvailableCars.AutoSize = true;
            this.titleAvailableCars.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleAvailableCars.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.titleAvailableCars.Location = new System.Drawing.Point(15, 75);
            this.titleAvailableCars.Text = "Available Cars";
            
            currentX += cardWidth + gap;
            
            // cardActiveBookings
            this.cardActiveBookings.BackColor = System.Drawing.Color.White;
            this.cardActiveBookings.Controls.Add(this.iconActiveBookings);
            this.cardActiveBookings.Controls.Add(this.lblActiveBookings);
            this.cardActiveBookings.Controls.Add(this.titleActiveBookings);
            this.cardActiveBookings.Location = new System.Drawing.Point(currentX, 30);
            this.cardActiveBookings.Size = new System.Drawing.Size(cardWidth, cardHeight);
            
            this.iconActiveBookings.AutoSize = true;
            this.iconActiveBookings.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconActiveBookings.Location = new System.Drawing.Point(15, 15);
            this.iconActiveBookings.Text = "📋";
            
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
            
            currentX += cardWidth + gap;
            
            // cardTotalRevenue
            this.cardTotalRevenue.BackColor = System.Drawing.Color.White;
            this.cardTotalRevenue.Controls.Add(this.iconTotalRevenue);
            this.cardTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.cardTotalRevenue.Controls.Add(this.titleTotalRevenue);
            this.cardTotalRevenue.Location = new System.Drawing.Point(currentX, 30);
            this.cardTotalRevenue.Size = new System.Drawing.Size(220, cardHeight); // Wider — BDT amounts need room
            
            this.iconTotalRevenue.AutoSize = true;
            this.iconTotalRevenue.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.iconTotalRevenue.Location = new System.Drawing.Point(15, 15);
            this.iconTotalRevenue.Text = "💰";
            
            this.lblTotalRevenue.AutoSize = true;  // Must be AutoSize to never clip BDT amounts
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblTotalRevenue.Location = new System.Drawing.Point(12, 35);
            this.lblTotalRevenue.Text = "BDT 0.00";
            
            this.titleTotalRevenue.AutoSize = true;
            this.titleTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.titleTotalRevenue.Location = new System.Drawing.Point(15, 75);
            this.titleTotalRevenue.Text = "Total Revenue";
            
            // pieChartFleet
            this.pieChartFleet.Location = new System.Drawing.Point(30, 175);
            this.pieChartFleet.Name = "pieChartFleet";
            this.pieChartFleet.Size = new System.Drawing.Size(400, 300);
            this.pieChartFleet.BackColor = System.Drawing.Color.White;
            
            // lblTotalBookings (hidden, kept for code compatibility if needed, or we just update the text)
            this.lblTotalBookings.Visible = false;
            
            // frmAdminHome
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdminHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Admin Dashboard";
            this.Load += new System.EventHandler(this.frmAdminHome_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminHome_FormClosed);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.cardTotalCars.ResumeLayout(false);
            this.cardTotalCars.PerformLayout();
            this.cardAvailableCars.ResumeLayout(false);
            this.cardAvailableCars.PerformLayout();
            this.cardActiveBookings.ResumeLayout(false);
            this.cardActiveBookings.PerformLayout();
            this.cardTotalRevenue.ResumeLayout(false);
            this.cardTotalRevenue.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
