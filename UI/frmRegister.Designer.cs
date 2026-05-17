namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmRegister
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        
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
        
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPasswordWrapper;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblShowHidePwd;
        
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Panel pnlConfirmPasswordWrapper;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblShowHideConfirmPwd;
        
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lnkLogin;

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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            
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
            
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlPasswordWrapper = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblShowHidePwd = new System.Windows.Forms.Label();
            
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.pnlConfirmPasswordWrapper = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblShowHideConfirmPwd = new System.Windows.Forms.Label();
            
            this.btnRegister = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            
            this.pnlCard.SuspendLayout();
            this.pnlFullNameWrapper.SuspendLayout();
            this.pnlUsernameWrapper.SuspendLayout();
            this.pnlEmailWrapper.SuspendLayout();
            this.pnlPhoneWrapper.SuspendLayout();
            this.pnlPasswordWrapper.SuspendLayout();
            this.pnlConfirmPasswordWrapper.SuspendLayout();
            this.SuspendLayout();
            
            // pnlCard
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblFullName);
            this.pnlCard.Controls.Add(this.pnlFullNameWrapper);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.pnlUsernameWrapper);
            this.pnlCard.Controls.Add(this.lblEmail);
            this.pnlCard.Controls.Add(this.pnlEmailWrapper);
            this.pnlCard.Controls.Add(this.lblPhone);
            this.pnlCard.Controls.Add(this.pnlPhoneWrapper);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.pnlPasswordWrapper);
            this.pnlCard.Controls.Add(this.lblConfirmPassword);
            this.pnlCard.Controls.Add(this.pnlConfirmPasswordWrapper);
            this.pnlCard.Controls.Add(this.btnRegister);
            this.pnlCard.Controls.Add(this.lnkLogin);
            this.pnlCard.Location = new System.Drawing.Point(25, 25);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(550, 600);
            this.pnlCard.TabIndex = 0;
            
            int currentY = 30;
            int leftMargin = 50;
            int ctrlWidth = 450;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblTitle.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Account";
            
            currentY += 45;
            
            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(leftMargin + 5, currentY);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(107, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Join DriveFlow today";
            
            currentY += 40;
            
            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblFullName.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(63, 15);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name";
            
            currentY += 20;
            
            // pnlFullNameWrapper
            this.pnlFullNameWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlFullNameWrapper.Controls.Add(this.txtFullName);
            this.pnlFullNameWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlFullNameWrapper.Name = "pnlFullNameWrapper";
            this.pnlFullNameWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFullNameWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlFullNameWrapper.TabIndex = 3;
            
            // txtFullName
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtFullName.Location = new System.Drawing.Point(1, 1);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(ctrlWidth - 2, 32);
            this.txtFullName.TabIndex = 0;
            
            currentY += 50;
            
            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblUsername.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 15);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            
            currentY += 20;
            
            // pnlUsernameWrapper
            this.pnlUsernameWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlUsernameWrapper.Controls.Add(this.txtUsername);
            this.pnlUsernameWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlUsernameWrapper.Name = "pnlUsernameWrapper";
            this.pnlUsernameWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlUsernameWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlUsernameWrapper.TabIndex = 5;
            
            // txtUsername
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUsername.Location = new System.Drawing.Point(1, 1);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(ctrlWidth - 2, 32);
            this.txtUsername.TabIndex = 0;
            
            currentY += 50;
            
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblEmail.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            
            currentY += 20;
            
            // pnlEmailWrapper
            this.pnlEmailWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlEmailWrapper.Controls.Add(this.txtEmail);
            this.pnlEmailWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlEmailWrapper.Name = "pnlEmailWrapper";
            this.pnlEmailWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlEmailWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlEmailWrapper.TabIndex = 7;
            
            // txtEmail
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtEmail.Location = new System.Drawing.Point(1, 1);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(ctrlWidth - 2, 32);
            this.txtEmail.TabIndex = 0;
            
            currentY += 50;
            
            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblPhone.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(42, 15);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Phone";
            
            currentY += 20;
            
            // pnlPhoneWrapper
            this.pnlPhoneWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlPhoneWrapper.Controls.Add(this.txtPhone);
            this.pnlPhoneWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlPhoneWrapper.Name = "pnlPhoneWrapper";
            this.pnlPhoneWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlPhoneWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlPhoneWrapper.TabIndex = 9;
            
            // txtPhone
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPhone.Location = new System.Drawing.Point(1, 1);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(ctrlWidth - 2, 32);
            this.txtPhone.TabIndex = 0;
            
            currentY += 50;
            
            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblPassword.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 15);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            
            currentY += 20;
            
            // pnlPasswordWrapper
            this.pnlPasswordWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlPasswordWrapper.Controls.Add(this.txtPassword);
            this.pnlPasswordWrapper.Controls.Add(this.lblShowHidePwd);
            this.pnlPasswordWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlPasswordWrapper.Name = "pnlPasswordWrapper";
            this.pnlPasswordWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlPasswordWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlPasswordWrapper.TabIndex = 11;
            
            // txtPassword
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPassword.Location = new System.Drawing.Point(1, 1);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(ctrlWidth - 32, 32);
            this.txtPassword.TabIndex = 0;
            
            // lblShowHidePwd
            this.lblShowHidePwd.BackColor = System.Drawing.Color.White;
            this.lblShowHidePwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowHidePwd.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblShowHidePwd.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShowHidePwd.Location = new System.Drawing.Point(ctrlWidth - 31, 1);
            this.lblShowHidePwd.Name = "lblShowHidePwd";
            this.lblShowHidePwd.Size = new System.Drawing.Size(30, 32);
            this.lblShowHidePwd.TabIndex = 1;
            this.lblShowHidePwd.Text = "👁";
            this.lblShowHidePwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            currentY += 50;
            
            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblConfirmPassword.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(107, 15);
            this.lblConfirmPassword.TabIndex = 12;
            this.lblConfirmPassword.Text = "Confirm Password";
            
            currentY += 20;
            
            // pnlConfirmPasswordWrapper
            this.pnlConfirmPasswordWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlConfirmPasswordWrapper.Controls.Add(this.txtConfirmPassword);
            this.pnlConfirmPasswordWrapper.Controls.Add(this.lblShowHideConfirmPwd);
            this.pnlConfirmPasswordWrapper.Location = new System.Drawing.Point(leftMargin, currentY);
            this.pnlConfirmPasswordWrapper.Name = "pnlConfirmPasswordWrapper";
            this.pnlConfirmPasswordWrapper.Padding = new System.Windows.Forms.Padding(1);
            this.pnlConfirmPasswordWrapper.Size = new System.Drawing.Size(ctrlWidth, 34);
            this.pnlConfirmPasswordWrapper.TabIndex = 13;
            
            // txtConfirmPassword
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtConfirmPassword.Location = new System.Drawing.Point(1, 1);
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(ctrlWidth - 32, 32);
            this.txtConfirmPassword.TabIndex = 0;
            
            // lblShowHideConfirmPwd
            this.lblShowHideConfirmPwd.BackColor = System.Drawing.Color.White;
            this.lblShowHideConfirmPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowHideConfirmPwd.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblShowHideConfirmPwd.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblShowHideConfirmPwd.Location = new System.Drawing.Point(ctrlWidth - 31, 1);
            this.lblShowHideConfirmPwd.Name = "lblShowHideConfirmPwd";
            this.lblShowHideConfirmPwd.Size = new System.Drawing.Size(30, 32);
            this.lblShowHideConfirmPwd.TabIndex = 1;
            this.lblShowHideConfirmPwd.Text = "👁";
            this.lblShowHideConfirmPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            currentY += 60;
            
            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(leftMargin, currentY);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(ctrlWidth, 42);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            
            currentY += 60;
            
            // lnkLogin
            this.lnkLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lnkLogin.Location = new System.Drawing.Point(leftMargin, currentY);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(ctrlWidth, 19);
            this.lnkLogin.TabIndex = 15;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Already have an account? Login";
            this.lnkLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            
            // frmRegister
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.pnlCard);
            this.Name = "frmRegister";
            this.Text = "DriveFlow - Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegister_FormClosed);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlFullNameWrapper.ResumeLayout(false);
            this.pnlFullNameWrapper.PerformLayout();
            this.pnlUsernameWrapper.ResumeLayout(false);
            this.pnlUsernameWrapper.PerformLayout();
            this.pnlEmailWrapper.ResumeLayout(false);
            this.pnlEmailWrapper.PerformLayout();
            this.pnlPhoneWrapper.ResumeLayout(false);
            this.pnlPhoneWrapper.PerformLayout();
            this.pnlPasswordWrapper.ResumeLayout(false);
            this.pnlPasswordWrapper.PerformLayout();
            this.pnlConfirmPasswordWrapper.ResumeLayout(false);
            this.pnlConfirmPasswordWrapper.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
