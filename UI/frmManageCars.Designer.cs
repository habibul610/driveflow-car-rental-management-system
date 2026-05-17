namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmManageCars
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel cardDetails;
        private System.Windows.Forms.Label lblCardDetailsTitle;
        
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel pnlBrandWrapper;
        private System.Windows.Forms.TextBox txtBrand;
        
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Panel pnlModelWrapper;
        private System.Windows.Forms.TextBox txtModel;
        
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Panel pnlYearWrapper;
        private System.Windows.Forms.TextBox txtYear;
        
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Panel pnlColorWrapper;
        private System.Windows.Forms.TextBox txtColor;
        
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.Panel pnlPlateWrapper;
        private System.Windows.Forms.TextBox txtPlateNumber;
        
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.Panel pnlImageWrapper;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;
        
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Panel pnlRateWrapper;
        private System.Windows.Forms.TextBox txtDailyRate;
        
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        
        private System.Windows.Forms.Panel cardList;
        private System.Windows.Forms.Panel pnlSearchWrapper;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.DataGridView dgvCars;

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
            
            this.cardDetails = new System.Windows.Forms.Panel();
            this.lblCardDetailsTitle = new System.Windows.Forms.Label();
            
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlBrandWrapper = new System.Windows.Forms.Panel();
            this.txtBrand = new System.Windows.Forms.TextBox();
            
            this.lblModel = new System.Windows.Forms.Label();
            this.pnlModelWrapper = new System.Windows.Forms.Panel();
            this.txtModel = new System.Windows.Forms.TextBox();
            
            this.lblYear = new System.Windows.Forms.Label();
            this.pnlYearWrapper = new System.Windows.Forms.Panel();
            this.txtYear = new System.Windows.Forms.TextBox();
            
            this.lblColor = new System.Windows.Forms.Label();
            this.pnlColorWrapper = new System.Windows.Forms.Panel();
            this.txtColor = new System.Windows.Forms.TextBox();
            
            this.lblPlate = new System.Windows.Forms.Label();
            this.pnlPlateWrapper = new System.Windows.Forms.Panel();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            
            this.lblImagePath = new System.Windows.Forms.Label();
            this.pnlImageWrapper = new System.Windows.Forms.Panel();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            
            this.lblRate = new System.Windows.Forms.Label();
            this.pnlRateWrapper = new System.Windows.Forms.Panel();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            
            this.cardList = new System.Windows.Forms.Panel();
            this.pnlSearchWrapper = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            
            this.pnlHeader.SuspendLayout();
            this.cardDetails.SuspendLayout();
            this.pnlBrandWrapper.SuspendLayout();
            this.pnlModelWrapper.SuspendLayout();
            this.pnlYearWrapper.SuspendLayout();
            this.pnlColorWrapper.SuspendLayout();
            this.pnlPlateWrapper.SuspendLayout();
            this.pnlRateWrapper.SuspendLayout();
            this.cardList.SuspendLayout();
            this.pnlSearchWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1050, 60);
            
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
            this.lblTitle.Size = new System.Drawing.Size(147, 30);
            this.lblTitle.Text = "Manage Cars";
            
            // cardDetails
            this.cardDetails.BackColor = System.Drawing.Color.White;
            this.cardDetails.Controls.Add(this.lblCardDetailsTitle);
            this.cardDetails.Controls.Add(this.lblBrand);
            this.cardDetails.Controls.Add(this.pnlBrandWrapper);
            this.cardDetails.Controls.Add(this.lblModel);
            this.cardDetails.Controls.Add(this.pnlModelWrapper);
            this.cardDetails.Controls.Add(this.lblYear);
            this.cardDetails.Controls.Add(this.pnlYearWrapper);
            this.cardDetails.Controls.Add(this.lblColor);
            this.cardDetails.Controls.Add(this.pnlColorWrapper);
            this.cardDetails.Controls.Add(this.lblPlate);
            this.cardDetails.Controls.Add(this.pnlPlateWrapper);
            this.cardDetails.Controls.Add(this.lblRate);
            this.cardDetails.Controls.Add(this.pnlRateWrapper);
            this.cardDetails.Controls.Add(this.lblStatus);
            this.cardDetails.Controls.Add(this.cmbStatus);
            this.cardDetails.Controls.Add(this.lblImagePath);
            this.cardDetails.Controls.Add(this.pnlImageWrapper);
            this.cardDetails.Controls.Add(this.btnBrowseImage);
            this.cardDetails.Controls.Add(this.btnAdd);
            this.cardDetails.Controls.Add(this.btnUpdate);
            this.cardDetails.Controls.Add(this.btnDelete);
            this.cardDetails.Controls.Add(this.btnClear);
            this.cardDetails.Location = new System.Drawing.Point(20, 80);
            this.cardDetails.Name = "cardDetails";
            this.cardDetails.Size = new System.Drawing.Size(350, 580);
            
            int y = 10;
            int inputWidth = 310;
            
            this.lblCardDetailsTitle.AutoSize = true;
            this.lblCardDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCardDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCardDetailsTitle.Location = new System.Drawing.Point(20, y);
            this.lblCardDetailsTitle.Text = "Car Details";
            
            y += 25;
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblBrand.Location = new System.Drawing.Point(20, y);
            this.lblBrand.Text = "Brand *";
            
            y += 18;
            this.pnlBrandWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlBrandWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBrandWrapper.Controls.Add(this.txtBrand);
            
            y += 34;
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblModel.Location = new System.Drawing.Point(20, y);
            this.lblModel.Text = "Model *";
            
            y += 18;
            this.pnlModelWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlModelWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlModelWrapper.Controls.Add(this.txtModel);
            
            y += 34;
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblYear.Location = new System.Drawing.Point(20, y);
            this.lblYear.Text = "Year *";
            
            y += 18;
            this.pnlYearWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlYearWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlYearWrapper.Controls.Add(this.txtYear);
            
            y += 34;
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblColor.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblColor.Location = new System.Drawing.Point(20, y);
            this.lblColor.Text = "Color *";
            
            y += 18;
            this.pnlColorWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlColorWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlColorWrapper.Controls.Add(this.txtColor);
            
            y += 34;
            this.lblPlate.AutoSize = true;
            this.lblPlate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPlate.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblPlate.Location = new System.Drawing.Point(20, y);
            this.lblPlate.Text = "Plate No *";
            
            y += 18;
            this.pnlPlateWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlPlateWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtPlateNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlateNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlPlateWrapper.Controls.Add(this.txtPlateNumber);
            
            y += 34;
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblRate.Location = new System.Drawing.Point(20, y);
            this.lblRate.Text = "Daily Rate *";
            
            y += 18;
            this.pnlRateWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlRateWrapper.Size = new System.Drawing.Size(inputWidth, 30);
            this.txtDailyRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDailyRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlRateWrapper.Controls.Add(this.txtDailyRate);
            
            y += 34;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblStatus.Location = new System.Drawing.Point(20, y);
            this.lblStatus.Text = "Status *";
            
            y += 18;
            this.cmbStatus.Location = new System.Drawing.Point(20, y);
            this.cmbStatus.Size = new System.Drawing.Size(inputWidth, 30);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Available", "Maintenance", "Rented" });
            
            y += 36;
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblImagePath.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblImagePath.Location = new System.Drawing.Point(20, y);
            this.lblImagePath.Text = "Image Path";
            
            y += 18;
            this.pnlImageWrapper.Location = new System.Drawing.Point(20, y);
            this.pnlImageWrapper.Size = new System.Drawing.Size(220, 30);
            this.txtImagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlImageWrapper.Controls.Add(this.txtImagePath);
            
            this.btnBrowseImage.Location = new System.Drawing.Point(250, y);
            this.btnBrowseImage.Size = new System.Drawing.Size(80, 30);
            this.btnBrowseImage.Text = "Browse";
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            
            y += 40;
            int btnWidth = 150;
            this.btnAdd.Location = new System.Drawing.Point(20, y);
            this.btnAdd.Size = new System.Drawing.Size(btnWidth, 36);
            this.btnAdd.Text = "+ Add Car";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            this.btnUpdate.Location = new System.Drawing.Point(180, y);
            this.btnUpdate.Size = new System.Drawing.Size(btnWidth, 36);
            this.btnUpdate.Text = "✏ Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            
            y += 40;
            this.btnDelete.Location = new System.Drawing.Point(20, y);
            this.btnDelete.Size = new System.Drawing.Size(btnWidth, 36);
            this.btnDelete.Text = "🗑 Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            this.btnClear.Location = new System.Drawing.Point(180, y);
            this.btnClear.Size = new System.Drawing.Size(btnWidth, 36);
            this.btnClear.Text = "✕ Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            
            // cardList
            this.cardList.BackColor = System.Drawing.Color.White;
            this.cardList.Controls.Add(this.pnlSearchWrapper);
            this.cardList.Controls.Add(this.lblFilter);
            this.cardList.Controls.Add(this.cmbFilterStatus);
            this.cardList.Controls.Add(this.dgvCars);
            this.cardList.Location = new System.Drawing.Point(390, 80);
            this.cardList.Name = "cardList";
            this.cardList.Size = new System.Drawing.Size(740, 580);
            
            // Search
            this.pnlSearchWrapper.Location = new System.Drawing.Point(20, 20);
            this.pnlSearchWrapper.Size = new System.Drawing.Size(280, 36);
            this.pnlSearchWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlSearchWrapper.Padding = new System.Windows.Forms.Padding(1);
            
            this.lblSearchIcon.BackColor = System.Drawing.Color.White;
            this.lblSearchIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchIcon.Text = "🔍";
            this.lblSearchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchIcon.Size = new System.Drawing.Size(34, 34);
            
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Multiline = true;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.pnlSearchWrapper.Controls.Add(this.txtSearch);
            this.pnlSearchWrapper.Controls.Add(this.lblSearchIcon);
            
            // Filter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(320, 28);
            this.lblFilter.Text = "Filter:";
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            
            this.cmbFilterStatus.Location = new System.Drawing.Point(370, 25);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            this.cmbFilterStatus.SelectedIndex = 0;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);
            
            // dgvCars
            this.dgvCars.Location = new System.Drawing.Point(20, 80);
            this.dgvCars.Size = new System.Drawing.Size(700, 480);
            this.dgvCars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellClick);
            
            // frmManageCars
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(1150, 680);
            this.Controls.Add(this.cardDetails);
            this.Controls.Add(this.cardList);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManageCars";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Manage Cars";
            this.Load += new System.EventHandler(this.frmManageCars_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardDetails.ResumeLayout(false);
            this.cardDetails.PerformLayout();
            this.pnlBrandWrapper.ResumeLayout(false);
            this.pnlBrandWrapper.PerformLayout();
            this.pnlModelWrapper.ResumeLayout(false);
            this.pnlModelWrapper.PerformLayout();
            this.pnlYearWrapper.ResumeLayout(false);
            this.pnlYearWrapper.PerformLayout();
            this.pnlColorWrapper.ResumeLayout(false);
            this.pnlColorWrapper.PerformLayout();
            this.pnlPlateWrapper.ResumeLayout(false);
            this.pnlPlateWrapper.PerformLayout();
            this.pnlRateWrapper.ResumeLayout(false);
            this.pnlRateWrapper.PerformLayout();
            this.cardList.ResumeLayout(false);
            this.cardList.PerformLayout();
            this.pnlSearchWrapper.ResumeLayout(false);
            this.pnlSearchWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
