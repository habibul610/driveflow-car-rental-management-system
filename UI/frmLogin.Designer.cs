namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblTagline;
        
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUsernameWrapper;
        private System.Windows.Forms.TextBox txtUsername;
        
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPasswordWrapper;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblShowHide;
        
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;

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
            pnlLeft = new Panel();
            lblLogoIcon = new Label();
            lblAppName = new Label();
            lblTagline = new Label();
            pnlRight = new Panel();
            lblWelcome = new Label();
            lblSubtitle = new Label();
            lblUsername = new Label();
            pnlUsernameWrapper = new Panel();
            txtUsername = new TextBox();
            lblPassword = new Label();
            pnlPasswordWrapper = new Panel();
            txtPassword = new TextBox();
            lblShowHide = new Label();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlUsernameWrapper.SuspendLayout();
            pnlPasswordWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(27, 58, 107);
            pnlLeft.Controls.Add(lblLogoIcon);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Controls.Add(lblTagline);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(3, 4, 3, 4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(366, 667);
            pnlLeft.TabIndex = 0;
            // 
            // lblLogoIcon
            // 
            lblLogoIcon.AutoSize = true;
            lblLogoIcon.Font = new Font("Segoe UI Emoji", 72F);
            lblLogoIcon.ForeColor = Color.White;
            lblLogoIcon.Location = new Point(73, 150);
            lblLogoIcon.Name = "lblLogoIcon";
            lblLogoIcon.Size = new Size(232, 159);
            lblLogoIcon.TabIndex = 0;
            lblLogoIcon.Text = "🚗";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(53, 309);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(282, 72);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "DriveFlow";
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 12F);
            lblTagline.ForeColor = Color.White;
            lblTagline.Location = new Point(46, 400);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(283, 28);
            lblTagline.TabIndex = 2;
            lblTagline.Text = "DriveFlow: Move with Freedom";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(lblWelcome);
            pnlRight.Controls.Add(lblSubtitle);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(pnlUsernameWrapper);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(pnlPasswordWrapper);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(lnkRegister);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(366, 0);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(548, 667);
            pnlRight.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(27, 58, 107);
            lblWelcome.Location = new Point(80, 93);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(277, 50);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Back";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(86, 153);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(178, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Login to your account";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(27, 58, 107);
            lblUsername.Location = new Point(86, 227);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(80, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // pnlUsernameWrapper
            // 
            pnlUsernameWrapper.BackColor = Color.FromArgb(226, 232, 240);
            pnlUsernameWrapper.Controls.Add(txtUsername);
            pnlUsernameWrapper.Location = new Point(86, 253);
            pnlUsernameWrapper.Margin = new Padding(3, 4, 3, 4);
            pnlUsernameWrapper.Name = "pnlUsernameWrapper";
            pnlUsernameWrapper.Padding = new Padding(1);
            pnlUsernameWrapper.Size = new Size(377, 45);
            pnlUsernameWrapper.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(1, 1);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(375, 43);
            txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(27, 58, 107);
            lblPassword.Location = new Point(86, 320);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // pnlPasswordWrapper
            // 
            pnlPasswordWrapper.BackColor = Color.FromArgb(226, 232, 240);
            pnlPasswordWrapper.Controls.Add(txtPassword);
            pnlPasswordWrapper.Controls.Add(lblShowHide);
            pnlPasswordWrapper.Location = new Point(86, 347);
            pnlPasswordWrapper.Margin = new Padding(3, 4, 3, 4);
            pnlPasswordWrapper.Name = "pnlPasswordWrapper";
            pnlPasswordWrapper.Padding = new Padding(1);
            pnlPasswordWrapper.Size = new Size(377, 45);
            pnlPasswordWrapper.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(1, 1);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(341, 43);
            txtPassword.TabIndex = 0;
            // 
            // lblShowHide
            // 
            lblShowHide.BackColor = Color.White;
            lblShowHide.Cursor = Cursors.Hand;
            lblShowHide.Dock = DockStyle.Right;
            lblShowHide.Font = new Font("Segoe UI Emoji", 12F);
            lblShowHide.Location = new Point(342, 1);
            lblShowHide.Name = "lblShowHide";
            lblShowHide.Size = new Size(34, 43);
            lblShowHide.TabIndex = 1;
            lblShowHide.Text = "👁";
            lblShowHide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(86, 440);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(377, 56);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.ActiveLinkColor = Color.FromArgb(37, 99, 235);
            lnkRegister.Font = new Font("Segoe UI", 10F);
            lnkRegister.LinkColor = Color.FromArgb(37, 99, 235);
            lnkRegister.Location = new Point(86, 533);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(377, 25);
            lnkRegister.TabIndex = 7;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Don't have an account? Register here";
            lnkRegister.TextAlign = ContentAlignment.MiddleCenter;
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 667);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmLogin";
            Text = "DriveFlow - Login";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlUsernameWrapper.ResumeLayout(false);
            pnlUsernameWrapper.PerformLayout();
            pnlPasswordWrapper.ResumeLayout(false);
            pnlPasswordWrapper.PerformLayout();
            ResumeLayout(false);
        }
    }
}
