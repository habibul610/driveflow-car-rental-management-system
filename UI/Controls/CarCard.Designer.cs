namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI.Controls
{
    partial class CarCard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.Label lblBrandModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCompare;

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
            this.picCar = new System.Windows.Forms.PictureBox();
            this.lblBrandModel = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.SuspendLayout();
            
            // picCar
            this.picCar.Location = new System.Drawing.Point(0, 0);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(250, 140);
            this.picCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            
            // lblBrandModel
            this.lblBrandModel.AutoSize = true;
            this.lblBrandModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBrandModel.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblBrandModel.Location = new System.Drawing.Point(10, 150);
            this.lblBrandModel.Name = "lblBrandModel";
            this.lblBrandModel.Size = new System.Drawing.Size(100, 21);
            this.lblBrandModel.Text = "Brand Model";
            
            // lblYear
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblYear.Location = new System.Drawing.Point(10, 175);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(40, 15);
            this.lblYear.Text = "Year: 2020";
            
            // lblRate
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblRate.Location = new System.Drawing.Point(10, 195);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(120, 20);
            this.lblRate.Text = "BDT 2500 / day";
            
            // btnSelect
            this.btnSelect.Location = new System.Drawing.Point(10, 225);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 36);
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            
            // btnCompare
            this.btnCompare.Location = new System.Drawing.Point(130, 225);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(110, 36);
            this.btnCompare.Text = "Compare";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            
            // CarCard
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.lblBrandModel);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCompare);
            this.Name = "CarCard";
            this.Size = new System.Drawing.Size(250, 275);
            this.Padding = new System.Windows.Forms.Padding(2);
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
