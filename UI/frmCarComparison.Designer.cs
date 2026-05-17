namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmCarComparison
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.ComboBox cmbCar1;
        private System.Windows.Forms.ComboBox cmbCar2;
        private System.Windows.Forms.Panel pnlCar1;
        private System.Windows.Forms.Panel pnlCar2;
        private System.Windows.Forms.Label lblVs;

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
            
            this.cmbCar1 = new System.Windows.Forms.ComboBox();
            this.cmbCar2 = new System.Windows.Forms.ComboBox();
            this.pnlCar1 = new System.Windows.Forms.Panel();
            this.pnlCar2 = new System.Windows.Forms.Panel();
            this.lblVs = new System.Windows.Forms.Label();
            
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            
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
            this.lblTitle.Size = new System.Drawing.Size(180, 30);
            this.lblTitle.Text = "Compare Cars";
            
            // cmbCar1
            this.cmbCar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCar1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCar1.Location = new System.Drawing.Point(50, 100);
            this.cmbCar1.Name = "cmbCar1";
            this.cmbCar1.Size = new System.Drawing.Size(250, 28);
            this.cmbCar1.SelectedIndexChanged += new System.EventHandler(this.cmbCar1_SelectedIndexChanged);
            
            // cmbCar2
            this.cmbCar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCar2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCar2.Location = new System.Drawing.Point(500, 100);
            this.cmbCar2.Name = "cmbCar2";
            this.cmbCar2.Size = new System.Drawing.Size(250, 28);
            this.cmbCar2.SelectedIndexChanged += new System.EventHandler(this.cmbCar2_SelectedIndexChanged);
            
            // pnlCar1
            this.pnlCar1.Location = new System.Drawing.Point(50, 150);
            this.pnlCar1.Name = "pnlCar1";
            this.pnlCar1.Size = new System.Drawing.Size(250, 350);
            this.pnlCar1.BackColor = System.Drawing.Color.White;
            
            // pnlCar2
            this.pnlCar2.Location = new System.Drawing.Point(500, 150);
            this.pnlCar2.Name = "pnlCar2";
            this.pnlCar2.Size = new System.Drawing.Size(250, 350);
            this.pnlCar2.BackColor = System.Drawing.Color.White;
            
            // lblVs
            this.lblVs.AutoSize = true;
            this.lblVs.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblVs.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblVs.Location = new System.Drawing.Point(365, 280);
            this.lblVs.Name = "lblVs";
            this.lblVs.Size = new System.Drawing.Size(59, 45);
            this.lblVs.Text = "VS";
            
            // frmCarComparison
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.lblVs);
            this.Controls.Add(this.pnlCar1);
            this.Controls.Add(this.pnlCar2);
            this.Controls.Add(this.cmbCar1);
            this.Controls.Add(this.cmbCar2);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCarComparison";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Car Comparison";
            this.Load += new System.EventHandler(this.frmCarComparison_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
