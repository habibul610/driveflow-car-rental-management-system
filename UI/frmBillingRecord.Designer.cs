namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmBillingRecord
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.Panel pnlSearchWrapper;
        private System.Windows.Forms.TextBox txtSearch;
        
        private System.Windows.Forms.DataGridView dgvBilling;
        
        private System.Windows.Forms.Panel cardAction;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnDownloadInvoice;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            
            this.cardAction = new System.Windows.Forms.Panel();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnDownloadInvoice = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSearchWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(167, 30);
            this.lblTitle.Text = "Billing Records";
            
            // pnlSearchWrapper
            this.pnlSearchWrapper.Location = new System.Drawing.Point(30, 80);
            this.pnlSearchWrapper.Size = new System.Drawing.Size(400, 36);
            this.pnlSearchWrapper.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlSearchWrapper.Padding = new System.Windows.Forms.Padding(1);
            
            // txtSearch
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Multiline = true;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.PlaceholderText = "🔍 Search by Customer, Bill ID, or Status...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.pnlSearchWrapper.Controls.Add(this.txtSearch);
            
            // dgvBilling
            this.dgvBilling.Location = new System.Drawing.Point(30, 140);
            this.dgvBilling.Size = new System.Drawing.Size(840, 360);
            
            // cardAction
            this.cardAction.BackColor = System.Drawing.Color.White;
            this.cardAction.Controls.Add(this.btnMarkPaid);
            this.cardAction.Controls.Add(this.btnDownloadInvoice);
            this.cardAction.Location = new System.Drawing.Point(30, 520);
            this.cardAction.Size = new System.Drawing.Size(840, 60);
            
            // btnMarkPaid
            this.btnMarkPaid.Location = new System.Drawing.Point(20, 10);
            this.btnMarkPaid.Size = new System.Drawing.Size(180, 40);
            this.btnMarkPaid.Text = "💳 Process Payment";
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            
            // btnDownloadInvoice
            this.btnDownloadInvoice.Location = new System.Drawing.Point(210, 10);
            this.btnDownloadInvoice.Size = new System.Drawing.Size(180, 40);
            this.btnDownloadInvoice.Text = "📄 Download Invoice";
            this.btnDownloadInvoice.Click += new System.EventHandler(this.btnDownloadInvoice_Click);
            
            // frmBillingRecord
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.cardAction);
            this.Controls.Add(this.dgvBilling);
            this.Controls.Add(this.pnlSearchWrapper);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBillingRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Billing Records";
            this.Load += new System.EventHandler(this.frmBillingRecord_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearchWrapper.ResumeLayout(false);
            this.pnlSearchWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.cardAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
