namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmManageUsers
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel pnlSearchWrapper;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        
        private System.Windows.Forms.DataGridView dgvUsers;
        
        private System.Windows.Forms.Panel cardAction;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddManager;

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
            
            this.pnlSearchWrapper = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            
            this.cardAction = new System.Windows.Forms.Panel();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddManager = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSearchWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cardAction.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            
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
            this.lblTitle.Size = new System.Drawing.Size(161, 30);
            this.lblTitle.Text = "Manage Users";
            
            // pnlSearchWrapper
            this.pnlSearchWrapper.Location = new System.Drawing.Point(30, 80);
            this.pnlSearchWrapper.Size = new System.Drawing.Size(350, 36);
            this.pnlSearchWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlSearchWrapper.Padding = new System.Windows.Forms.Padding(1);
            
            // lblSearchIcon
            this.lblSearchIcon.BackColor = System.Drawing.Color.White;
            this.lblSearchIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchIcon.Text = "🔍";
            this.lblSearchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchIcon.Size = new System.Drawing.Size(30, 34);
            
            // txtSearch
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Multiline = true;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.pnlSearchWrapper.Controls.Add(this.txtSearch);
            this.pnlSearchWrapper.Controls.Add(this.lblSearchIcon);
            
            // cardAction
            this.cardAction.BackColor = System.Drawing.Color.White;
            this.cardAction.Controls.Add(this.btnViewProfile);
            this.cardAction.Controls.Add(this.btnDeleteUser);
            this.cardAction.Controls.Add(this.btnAddManager);
            this.cardAction.Location = new System.Drawing.Point(400, 75);
            this.cardAction.Size = new System.Drawing.Size(470, 50);
            
            // btnViewProfile
            this.btnViewProfile.Location = new System.Drawing.Point(10, 5);
            this.btnViewProfile.Size = new System.Drawing.Size(130, 40);
            this.btnViewProfile.Text = "👁 View Details";
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            
            // btnDeleteUser
            this.btnDeleteUser.Location = new System.Drawing.Point(150, 5);
            this.btnDeleteUser.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteUser.Text = "🗑 Delete User";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            // btnAddManager
            this.btnAddManager.Location = new System.Drawing.Point(290, 5);
            this.btnAddManager.Size = new System.Drawing.Size(170, 40);
            this.btnAddManager.Text = "➕ Add Manager";
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            
            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(30, 140);
            this.dgvUsers.Size = new System.Drawing.Size(840, 420);
            
            // frmManageUsers
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cardAction);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlSearchWrapper);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearchWrapper.ResumeLayout(false);
            this.pnlSearchWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cardAction.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
