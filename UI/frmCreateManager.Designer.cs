namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmCreateManager
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.pnlFullNameWrapper.SuspendLayout();
            this.pnlUsernameWrapper.SuspendLayout();
            this.pnlEmailWrapper.SuspendLayout();
            this.pnlPhoneWrapper.SuspendLayout();
            this.pnlPasswordWrapper.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(100, 20);
            this.lblTitle.Text = "Create New Manager";
            
            int y = 70;
            int x = 50;
            int w = 300;
            
            // Full Name
            this.lblFullName.Location = new System.Drawing.Point(x, y); this.lblFullName.Text = "Full Name";
            y += 20;
            this.pnlFullNameWrapper.Location = new System.Drawing.Point(x, y); this.pnlFullNameWrapper.Size = new System.Drawing.Size(w, 34);
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill; this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlFullNameWrapper.Controls.Add(this.txtFullName);
            y += 50;
            
            // Username
            this.lblUsername.Location = new System.Drawing.Point(x, y); this.lblUsername.Text = "Username";
            y += 20;
            this.pnlUsernameWrapper.Location = new System.Drawing.Point(x, y); this.pnlUsernameWrapper.Size = new System.Drawing.Size(w, 34);
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill; this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlUsernameWrapper.Controls.Add(this.txtUsername);
            y += 50;
            
            // Email
            this.lblEmail.Location = new System.Drawing.Point(x, y); this.lblEmail.Text = "Email";
            y += 20;
            this.pnlEmailWrapper.Location = new System.Drawing.Point(x, y); this.pnlEmailWrapper.Size = new System.Drawing.Size(w, 34);
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill; this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlEmailWrapper.Controls.Add(this.txtEmail);
            y += 50;
            
            // Phone
            this.lblPhone.Location = new System.Drawing.Point(x, y); this.lblPhone.Text = "Phone";
            y += 20;
            this.pnlPhoneWrapper.Location = new System.Drawing.Point(x, y); this.pnlPhoneWrapper.Size = new System.Drawing.Size(w, 34);
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill; this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlPhoneWrapper.Controls.Add(this.txtPhone);
            y += 50;
            
            // Password
            this.lblPassword.Location = new System.Drawing.Point(x, y); this.lblPassword.Text = "Password";
            y += 20;
            this.pnlPasswordWrapper.Location = new System.Drawing.Point(x, y); this.pnlPasswordWrapper.Size = new System.Drawing.Size(w, 34);
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill; this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtPassword.PasswordChar = '●';
            this.pnlPasswordWrapper.Controls.Add(this.txtPassword);
            y += 60;
            
            // Buttons
            this.btnCreate.Location = new System.Drawing.Point(x, y); this.btnCreate.Size = new System.Drawing.Size(145, 40); this.btnCreate.Text = "Create";
            this.btnCancel.Location = new System.Drawing.Point(x + 155, y); this.btnCancel.Size = new System.Drawing.Size(145, 40); this.btnCancel.Text = "Cancel";
            
            // frmCreateManager
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlPasswordWrapper);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.pnlPhoneWrapper);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.pnlEmailWrapper);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.pnlUsernameWrapper);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pnlFullNameWrapper);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Manager";
            
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
            this.ResumeLayout(false);
        }
    }
}
