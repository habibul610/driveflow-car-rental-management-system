namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmMakeBooking
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel pnlSearchWrapper;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        
        private System.Windows.Forms.FlowLayoutPanel flpCars;
        
        private System.Windows.Forms.Panel cardBooking;
        private System.Windows.Forms.Label lblSelectedCarTitle;
        private System.Windows.Forms.Label lblSelectedCar;
        private System.Windows.Forms.Label lblPickupDate;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.Button btnConfirmBooking;

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
            pnlHeader = new Panel();
            btnBack = new Button();
            lblTitle = new Label();
            pnlSearchWrapper = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            flpCars = new FlowLayoutPanel();
            cardBooking = new Panel();
            lblSelectedCarTitle = new Label();
            lblSelectedCar = new Label();
            lblPickupDate = new Label();
            dtpPickupDate = new DateTimePicker();
            lblReturnDate = new Label();
            dtpReturnDate = new DateTimePicker();
            lblEstimatedCost = new Label();
            btnConfirmBooking = new Button();
            pnlHeader.SuspendLayout();
            pnlSearchWrapper.SuspendLayout();
            cardBooking.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1086, 80);
            pnlHeader.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(23, 20);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 43);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(27, 58, 107);
            lblTitle.Location = new Point(137, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(276, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Browse && Book Cars";
            // 
            // pnlSearchWrapper
            // 
            pnlSearchWrapper.BackColor = Color.FromArgb(226, 232, 240);
            pnlSearchWrapper.Controls.Add(txtSearch);
            pnlSearchWrapper.Controls.Add(lblSearchIcon);
            pnlSearchWrapper.Location = new Point(34, 107);
            pnlSearchWrapper.Margin = new Padding(3, 4, 3, 4);
            pnlSearchWrapper.Name = "pnlSearchWrapper";
            pnlSearchWrapper.Padding = new Padding(1);
            pnlSearchWrapper.Size = new Size(343, 48);
            pnlSearchWrapper.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(35, 1);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(307, 46);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.BackColor = Color.White;
            lblSearchIcon.Dock = DockStyle.Left;
            lblSearchIcon.Location = new Point(1, 1);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(34, 46);
            lblSearchIcon.TabIndex = 1;
            lblSearchIcon.Text = "🔍";
            lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
            flpCars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpCars.AutoScroll = true;
            flpCars.BackColor = Color.FromArgb(248, 250, 252);
            flpCars.Location = new Point(34, 160);
            flpCars.Margin = new Padding(3, 4, 3, 4);
            flpCars.Name = "flpCars";
            flpCars.Padding = new Padding(11, 13, 11, 13);
            flpCars.Size = new Size(670, 620);
            flpCars.TabIndex = 1;
            cardBooking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cardBooking.BackColor = Color.White;
            cardBooking.Controls.Add(lblSelectedCarTitle);
            cardBooking.Controls.Add(lblSelectedCar);
            cardBooking.Controls.Add(lblPickupDate);
            cardBooking.Controls.Add(dtpPickupDate);
            cardBooking.Controls.Add(lblReturnDate);
            cardBooking.Controls.Add(dtpReturnDate);
            cardBooking.Controls.Add(lblEstimatedCost);
            cardBooking.Controls.Add(btnConfirmBooking);
            cardBooking.Location = new Point(720, 107);
            cardBooking.Margin = new Padding(3, 4, 3, 4);
            cardBooking.Name = "cardBooking";
            cardBooking.Size = new Size(330, 673);
            cardBooking.TabIndex = 0;
            // 
            // lblSelectedCarTitle
            // 
            lblSelectedCarTitle.AutoSize = true;
            lblSelectedCarTitle.Font = new Font("Segoe UI", 10F);
            lblSelectedCarTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSelectedCarTitle.Location = new Point(20, 20);
            lblSelectedCarTitle.Name = "lblSelectedCarTitle";
            lblSelectedCarTitle.Size = new Size(109, 23);
            lblSelectedCarTitle.TabIndex = 0;
            lblSelectedCarTitle.Text = "Selected Car:";
            // 
            // lblSelectedCar
            // 
            lblSelectedCar.AutoSize = false;
            lblSelectedCar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSelectedCar.ForeColor = Color.FromArgb(15, 23, 42);
            lblSelectedCar.Location = new Point(20, 45);
            lblSelectedCar.Name = "lblSelectedCar";
            lblSelectedCar.Size = new Size(290, 55);
            lblSelectedCar.TabIndex = 1;
            lblSelectedCar.Text = "None";
            // 
            // lblPickupDate
            // 
            lblPickupDate.AutoSize = true;
            lblPickupDate.Location = new Point(20, 105);
            lblPickupDate.Name = "lblPickupDate";
            lblPickupDate.Size = new Size(91, 20);
            lblPickupDate.TabIndex = 2;
            lblPickupDate.Text = "Pickup Date:";
            // 
            // dtpPickupDate
            // 
            dtpPickupDate.Format = DateTimePickerFormat.Short;
            dtpPickupDate.Location = new Point(20, 130);
            dtpPickupDate.Margin = new Padding(3, 4, 3, 4);
            dtpPickupDate.Name = "dtpPickupDate";
            dtpPickupDate.Size = new Size(290, 27);
            dtpPickupDate.TabIndex = 3;
            dtpPickupDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // lblReturnDate
            // 
            lblReturnDate.Location = new Point(20, 170);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(290, 25);
            lblReturnDate.TabIndex = 4;
            lblReturnDate.Text = "Expected Return Date:";
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Format = DateTimePickerFormat.Short;
            dtpReturnDate.Location = new Point(20, 195);
            dtpReturnDate.Margin = new Padding(3, 4, 3, 4);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(290, 27);
            dtpReturnDate.TabIndex = 5;
            dtpReturnDate.ValueChanged += dtpDate_ValueChanged;
            lblEstimatedCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblEstimatedCost.ForeColor = Color.FromArgb(22, 163, 74);
            lblEstimatedCost.Location = new Point(20, 540);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(180, 32);
            lblEstimatedCost.TabIndex = 6;
            lblEstimatedCost.Text = "Cost: BDT 0.00";
            btnConfirmBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirmBooking.Location = new Point(20, 590);
            btnConfirmBooking.Margin = new Padding(3, 4, 3, 4);
            btnConfirmBooking.MinimumSize = new Size(183, 51);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(290, 60);
            btnConfirmBooking.TabIndex = 7;
            btnConfirmBooking.Text = "✅ Confirm Booking";
            btnConfirmBooking.Click += btnConfirmBooking_Click;
            // 
            // frmMakeBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1086, 827);
            Controls.Add(cardBooking);
            Controls.Add(flpCars);
            Controls.Add(pnlSearchWrapper);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = true;
            Name = "frmMakeBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DriveFlow - Book a Car";
            Load += frmMakeBooking_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearchWrapper.ResumeLayout(false);
            pnlSearchWrapper.PerformLayout();
            cardBooking.ResumeLayout(false);
            cardBooking.PerformLayout();
            ResumeLayout(false);
        }
    }
}
