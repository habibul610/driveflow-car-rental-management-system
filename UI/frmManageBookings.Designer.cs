namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmManageBookings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel pnlSearchWrapper;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        
        private System.Windows.Forms.DataGridView dgvBookings;
        
        private System.Windows.Forms.Panel cardAction;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblProcessReturnTitle;
        private System.Windows.Forms.Label lblActualReturn;
        private System.Windows.Forms.DateTimePicker dtpActualReturnDate;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.Button btnTrackCar;

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
            lblFilter = new Label();
            cmbFilterStatus = new ComboBox();
            dgvBookings = new DataGridView();
            cardAction = new Panel();
            btnApprove = new Button();
            btnCancel = new Button();
            pnlDivider = new Panel();
            lblProcessReturnTitle = new Label();
            lblActualReturn = new Label();
            dtpActualReturnDate = new DateTimePicker();
            btnProcessReturn = new Button();
            btnTrackCar = new Button();
            pnlHeader.SuspendLayout();
            pnlSearchWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            cardAction.SuspendLayout();
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
            pnlHeader.Size = new Size(1257, 80);
            pnlHeader.TabIndex = 5;
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
            lblTitle.Size = new Size(247, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Manage Bookings";
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
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.ForeColor = Color.FromArgb(100, 116, 139);
            lblFilter.Location = new Point(400, 117);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(45, 20);
            lblFilter.TabIndex = 3;
            lblFilter.Text = "Filter:";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Active", "Completed", "Cancelled" });
            cmbFilterStatus.Location = new Point(457, 113);
            cmbFilterStatus.Margin = new Padding(3, 4, 3, 4);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(171, 28);
            cmbFilterStatus.TabIndex = 4;
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            // 
            // dgvBookings
            // 
            dgvBookings.ColumnHeadersHeight = 29;
            dgvBookings.Location = new Point(34, 173);
            dgvBookings.Margin = new Padding(3, 4, 3, 4);
            dgvBookings.Name = "dgvBookings";
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.Size = new Size(1189, 424);
            dgvBookings.TabIndex = 1;
            dgvBookings.CellClick += dgvBookings_CellClick;
            // 
            // cardAction
            // 
            cardAction.BackColor = Color.White;
            cardAction.Controls.Add(btnApprove);
            cardAction.Controls.Add(btnCancel);
            cardAction.Controls.Add(pnlDivider);
            cardAction.Controls.Add(lblProcessReturnTitle);
            cardAction.Controls.Add(lblActualReturn);
            cardAction.Controls.Add(dtpActualReturnDate);
            cardAction.Controls.Add(btnProcessReturn);
            cardAction.Controls.Add(btnTrackCar);
            cardAction.Location = new Point(35, 704);
            cardAction.Margin = new Padding(3, 4, 3, 4);
            cardAction.Name = "cardAction";
            cardAction.Size = new Size(1189, 133);
            cardAction.TabIndex = 0;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(23, 40);
            btnApprove.Margin = new Padding(3, 4, 3, 4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(171, 53);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "☑ Approve Booking";
            btnApprove.Click += btnApprove_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(206, 40);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(226, 232, 240);
            pnlDivider.Location = new Point(411, 27);
            pnlDivider.Margin = new Padding(3, 4, 3, 4);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(2, 80);
            pnlDivider.TabIndex = 2;
            // 
            // lblProcessReturnTitle
            // 
            lblProcessReturnTitle.AutoSize = true;
            lblProcessReturnTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProcessReturnTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblProcessReturnTitle.Location = new Point(457, 27);
            lblProcessReturnTitle.Name = "lblProcessReturnTitle";
            lblProcessReturnTitle.Size = new Size(114, 20);
            lblProcessReturnTitle.TabIndex = 3;
            lblProcessReturnTitle.Text = "Process Return";
            // 
            // lblActualReturn
            // 
            lblActualReturn.AutoSize = true;
            lblActualReturn.Location = new Point(457, 67);
            lblActualReturn.Name = "lblActualReturn";
            lblActualReturn.Size = new Size(44, 20);
            lblActualReturn.TabIndex = 4;
            lblActualReturn.Text = "Date:";
            // 
            // dtpActualReturnDate
            // 
            dtpActualReturnDate.Format = DateTimePickerFormat.Short;
            dtpActualReturnDate.Location = new Point(514, 61);
            dtpActualReturnDate.Margin = new Padding(3, 4, 3, 4);
            dtpActualReturnDate.Name = "dtpActualReturnDate";
            dtpActualReturnDate.Size = new Size(137, 27);
            dtpActualReturnDate.TabIndex = 5;
            // 
            // btnProcessReturn
            // 
            btnProcessReturn.Location = new Point(686, 53);
            btnProcessReturn.Margin = new Padding(3, 4, 3, 4);
            btnProcessReturn.Name = "btnProcessReturn";
            btnProcessReturn.Size = new Size(183, 51);
            btnProcessReturn.TabIndex = 6;
            btnProcessReturn.Text = "✔ Confirm Return";
            btnProcessReturn.Click += btnProcessReturn_Click;
            // 
            // btnTrackCar
            // 
            btnTrackCar.Location = new Point(914, 40);
            btnTrackCar.Margin = new Padding(3, 4, 3, 4);
            btnTrackCar.Name = "btnTrackCar";
            btnTrackCar.Size = new Size(183, 53);
            btnTrackCar.TabIndex = 7;
            btnTrackCar.Text = "🛰 Track Car";
            btnTrackCar.Click += btnTrackCar_Click;
            // 
            // frmManageBookings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1257, 933);
            Controls.Add(cardAction);
            Controls.Add(dgvBookings);
            Controls.Add(pnlSearchWrapper);
            Controls.Add(lblFilter);
            Controls.Add(cmbFilterStatus);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmManageBookings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DriveFlow - Manage Bookings";
            Load += frmManageBookings_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearchWrapper.ResumeLayout(false);
            pnlSearchWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            cardAction.ResumeLayout(false);
            cardAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
