namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmMyBookings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.DataGridView dgvMyBookings;
        
        private System.Windows.Forms.Panel cardAction;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnReturnCar;

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
            
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            
            this.cardAction = new System.Windows.Forms.Panel();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnReturnCar = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(149, 30);
            this.lblTitle.Text = "My Bookings";
            
            // dgvMyBookings
            this.dgvMyBookings.Location = new System.Drawing.Point(30, 80);
            this.dgvMyBookings.Size = new System.Drawing.Size(840, 420);
            
            // cardAction
            this.cardAction.BackColor = System.Drawing.Color.White;
            this.cardAction.Controls.Add(this.btnCancelBooking);
            this.cardAction.Controls.Add(this.btnReturnCar);
            this.cardAction.Location = new System.Drawing.Point(30, 520);
            this.cardAction.Size = new System.Drawing.Size(840, 60);
            
            // btnCancelBooking
            this.btnCancelBooking.Location = new System.Drawing.Point(20, 10);
            this.btnCancelBooking.Size = new System.Drawing.Size(180, 40);
            this.btnCancelBooking.Text = "❌ Cancel Booking";
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            
            // btnReturnCar
            this.btnReturnCar.Location = new System.Drawing.Point(220, 10);
            this.btnReturnCar.Size = new System.Drawing.Size(180, 40);
            this.btnReturnCar.Text = "🔄 Return Car";
            this.btnReturnCar.Click += new System.EventHandler(this.btnReturnCar_Click);

            // frmMyBookings
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cardAction);
            this.Controls.Add(this.dgvMyBookings);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMyBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - My Bookings";
            this.Load += new System.EventHandler(this.frmMyBookings_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.cardAction.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
