namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmGPSSimulation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblSelectCar;
        private System.Windows.Forms.ComboBox cmbCars;
        private System.Windows.Forms.Button btnToggleSim;
        
        private System.Windows.Forms.Panel cardStatus;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLng;
        private System.Windows.Forms.Label lblSpeed;
        
        private System.Windows.Forms.Timer simTimer;

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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.pnlMap = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblSelectCar = new System.Windows.Forms.Label();
            this.cmbCars = new System.Windows.Forms.ComboBox();
            this.btnToggleSim = new System.Windows.Forms.Button();
            
            this.cardStatus = new System.Windows.Forms.Panel();
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLng = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            
            this.simTimer = new System.Windows.Forms.Timer(this.components);
            
            this.pnlHeader.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.cardStatus.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            
            // btnBack
            this.btnBack.Location = new System.Drawing.Point(20, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.Text = "← Back";
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 15);
            this.lblTitle.Text = "🛰 DriveFlow GPS Fleet Tracker";
            
            // pnlMap
            this.pnlMap.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);
            this.pnlMap.Location = new System.Drawing.Point(20, 80);
            this.pnlMap.Size = new System.Drawing.Size(600, 480);
            
            // pnlControls
            this.pnlControls.BackColor = System.Drawing.Color.White;
            this.pnlControls.Controls.Add(this.lblSelectCar);
            this.pnlControls.Controls.Add(this.cmbCars);
            this.pnlControls.Controls.Add(this.btnToggleSim);
            this.pnlControls.Location = new System.Drawing.Point(640, 80);
            this.pnlControls.Size = new System.Drawing.Size(240, 200);
            
            // lblSelectCar
            this.lblSelectCar.Location = new System.Drawing.Point(20, 20);
            this.lblSelectCar.Text = "Select Car to Track:";
            
            // cmbCars
            this.cmbCars.Location = new System.Drawing.Point(20, 45);
            this.cmbCars.Size = new System.Drawing.Size(200, 25);
            this.cmbCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // btnToggleSim
            this.btnToggleSim.Location = new System.Drawing.Point(20, 100);
            this.btnToggleSim.Size = new System.Drawing.Size(200, 40);
            this.btnToggleSim.Text = "▶ Start Tracking";
            
            // cardStatus
            this.cardStatus.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.cardStatus.Controls.Add(this.lblLat);
            this.cardStatus.Controls.Add(this.lblLng);
            this.cardStatus.Controls.Add(this.lblSpeed);
            this.cardStatus.Location = new System.Drawing.Point(640, 300);
            this.cardStatus.Size = new System.Drawing.Size(240, 260);
            
            // lblLat
            this.lblLat.ForeColor = System.Drawing.Color.White;
            this.lblLat.Location = new System.Drawing.Point(20, 30);
            this.lblLat.Text = "LAT: 23.8103";
            this.lblLat.AutoSize = true;
            this.lblLat.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            
            // lblLng
            this.lblLng.ForeColor = System.Drawing.Color.White;
            this.lblLng.Location = new System.Drawing.Point(20, 70);
            this.lblLng.Text = "LNG: 90.4125";
            this.lblLng.AutoSize = true;
            this.lblLng.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            
            // lblSpeed
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblSpeed.Location = new System.Drawing.Point(20, 110);
            this.lblSpeed.Text = "SPD: 0.0 km/h";
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            
            // simTimer
            this.simTimer.Interval = 500;
            
            // frmGPSSimulation
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cardStatus);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGPSSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - GPS Fleet Tracker";
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.cardStatus.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
