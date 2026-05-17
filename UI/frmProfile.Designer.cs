namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmProfile
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel cardProfile;
        private System.Windows.Forms.Panel pnlAvatar;
        
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Panel pnlFullNameWrapper;
        private System.Windows.Forms.TextBox txtFullName;
        
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUsernameWrapper;
        private System.Windows.Forms.TextBox txtUsername;
        
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel pnlEmailWrapper;
        private System.Windows.Forms.TextBox txtEmail;
        
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel pnlPhoneWrapper;
        private System.Windows.Forms.TextBox txtPhone;
        
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangePassword;

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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.cardProfile = new System.Windows.Forms.Panel();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            
            this.lblFullName = new System.Windows.Forms.Label();
            this.pnlFullNameWrapper = new System.Windows.Forms.Panel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlUsernameWrapper = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            
            this.lblEmail = new System.Windows.Forms.Label();
            this.pnlEmailWrapper = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            
            this.lblPhone = new System.Windows.Forms.Label();
            this.pnlPhoneWrapper = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.cardProfile.SuspendLayout();
            this.pnlFullNameWrapper.SuspendLayout();
            this.pnlUsernameWrapper.SuspendLayout();
            this.pnlEmailWrapper.SuspendLayout();
            this.pnlPhoneWrapper.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            
            // btnBack
            this.btnBack.Location = new System.Drawing.Point(20, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.Text = "← Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblTitle.Location = new System.Drawing.Point(120, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 30);
            this.lblTitle.Text = "My Profile";
            
            // cardProfile
            this.cardProfile.BackColor = System.Drawing.Color.White;
            this.cardProfile.Controls.Add(this.pnlAvatar);
            this.cardProfile.Controls.Add(this.lblFullName);
            this.cardProfile.Controls.Add(this.pnlFullNameWrapper);
            this.cardProfile.Controls.Add(this.lblUsername);
            this.cardProfile.Controls.Add(this.pnlUsernameWrapper);
            this.cardProfile.Controls.Add(this.lblEmail);
            this.cardProfile.Controls.Add(this.pnlEmailWrapper);
            this.cardProfile.Controls.Add(this.lblPhone);
            this.cardProfile.Controls.Add(this.pnlPhoneWrapper);
            this.cardProfile.Controls.Add(this.btnSave);
            this.cardProfile.Controls.Add(this.btnChangePassword);
            this.cardProfile.Location = new System.Drawing.Point(100, 100);
            this.cardProfile.Size = new System.Drawing.Size(400, 520);
            
            // pnlAvatar
            this.pnlAvatar.Location = new System.Drawing.Point(160, 20);
            this.pnlAvatar.Size = new System.Drawing.Size(80, 80);
            
            int y = 120;
            int inputWidth = 300;
            int lblX = 50;
            
            // Full Name
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblFullName.Location = new System.Drawing.Point(lblX, y);
            this.lblFullName.Text = "Full Name";
            
            y += 20;
            this.pnlFullNameWrapper.Location = new System.Drawing.Point(lblX, y);
            this.pnlFullNameWrapper.Size = new System.Drawing.Size(inputWidth, 34);
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlFullNameWrapper.Controls.Add(this.txtFullName);
            
            y += 50;
            
            // Username
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblUsername.Location = new System.Drawing.Point(lblX, y);
            this.lblUsername.Text = "Username (Read Only)";
            
            y += 20;
            this.pnlUsernameWrapper.Location = new System.Drawing.Point(lblX, y);
            this.pnlUsernameWrapper.Size = new System.Drawing.Size(inputWidth, 34);
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ReadOnly = true;
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlUsernameWrapper.Controls.Add(this.txtUsername);
            
            y += 50;
            
            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblEmail.Location = new System.Drawing.Point(lblX, y);
            this.lblEmail.Text = "Email";
            
            y += 20;
            this.pnlEmailWrapper.Location = new System.Drawing.Point(lblX, y);
            this.pnlEmailWrapper.Size = new System.Drawing.Size(inputWidth, 34);
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlEmailWrapper.Controls.Add(this.txtEmail);
            
            y += 50;
            
            // Phone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblPhone.Location = new System.Drawing.Point(lblX, y);
            this.lblPhone.Text = "Phone";
            
            y += 20;
            this.pnlPhoneWrapper.Location = new System.Drawing.Point(lblX, y);
            this.pnlPhoneWrapper.Size = new System.Drawing.Size(inputWidth, 34);
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlPhoneWrapper.Controls.Add(this.txtPhone);
            
            y += 60;
            
            // Buttons
            this.btnSave.Location = new System.Drawing.Point(lblX, y);
            this.btnSave.Size = new System.Drawing.Size(145, 40);
            this.btnSave.Text = "Save Changes";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            this.btnChangePassword.Location = new System.Drawing.Point(lblX + 155, y);
            this.btnChangePassword.Size = new System.Drawing.Size(145, 40);
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            
            // frmProfile
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.cardProfile);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - My Profile";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardProfile.ResumeLayout(false);
            this.cardProfile.PerformLayout();
            this.pnlFullNameWrapper.ResumeLayout(false);
            this.pnlFullNameWrapper.PerformLayout();
            this.pnlUsernameWrapper.ResumeLayout(false);
            this.pnlUsernameWrapper.PerformLayout();
            this.pnlEmailWrapper.ResumeLayout(false);
            this.pnlEmailWrapper.PerformLayout();
            this.pnlPhoneWrapper.ResumeLayout(false);
            this.pnlPhoneWrapper.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
