namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmMessages
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.DataGridView dgvMessages;
        
        private System.Windows.Forms.Panel cardAction;
        private System.Windows.Forms.Button btnNewMessage;
        private System.Windows.Forms.Button btnMarkRead;
        
        private System.Windows.Forms.Panel cardMessage;
        private System.Windows.Forms.Label lblMessageTitle;
        private System.Windows.Forms.RichTextBox rtbMessageBody;

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
            
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            
            this.cardAction = new System.Windows.Forms.Panel();
            this.btnNewMessage = new System.Windows.Forms.Button();
            this.btnMarkRead = new System.Windows.Forms.Button();
            
            this.cardMessage = new System.Windows.Forms.Panel();
            this.lblMessageTitle = new System.Windows.Forms.Label();
            this.rtbMessageBody = new System.Windows.Forms.RichTextBox();
            
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.cardAction.SuspendLayout();
            this.cardMessage.SuspendLayout();
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
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblTitle.Location = new System.Drawing.Point(120, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 30);
            this.lblTitle.Text = "Messages";
            
            // cardAction
            this.cardAction.BackColor = System.Drawing.Color.White;
            this.cardAction.Controls.Add(this.btnNewMessage);
            this.cardAction.Controls.Add(this.btnMarkRead);
            this.cardAction.Location = new System.Drawing.Point(570, 75);
            this.cardAction.Size = new System.Drawing.Size(300, 50);
            
            // btnNewMessage
            this.btnNewMessage.Location = new System.Drawing.Point(10, 5);
            this.btnNewMessage.Size = new System.Drawing.Size(130, 40);
            this.btnNewMessage.Text = "✉ New Message";
            
            // btnMarkRead
            this.btnMarkRead.Location = new System.Drawing.Point(160, 5);
            this.btnMarkRead.Size = new System.Drawing.Size(130, 40);
            this.btnMarkRead.Text = "✓ Mark as Read";
            
            // dgvMessages
            this.dgvMessages.Location = new System.Drawing.Point(30, 140);
            this.dgvMessages.Size = new System.Drawing.Size(840, 250);
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.SelectionChanged += new System.EventHandler(this.dgvMessages_SelectionChanged);
            
            // cardMessage
            this.cardMessage.BackColor = System.Drawing.Color.White;
            this.cardMessage.Controls.Add(this.lblMessageTitle);
            this.cardMessage.Controls.Add(this.rtbMessageBody);
            this.cardMessage.Location = new System.Drawing.Point(30, 410);
            this.cardMessage.Size = new System.Drawing.Size(840, 300);
            
            // lblMessageTitle
            this.lblMessageTitle.AutoSize = true;
            this.lblMessageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMessageTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMessageTitle.Text = "Message Content";
            
            // rtbMessageBody
            this.rtbMessageBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMessageBody.Location = new System.Drawing.Point(20, 50);
            this.rtbMessageBody.Size = new System.Drawing.Size(800, 230);
            this.rtbMessageBody.ReadOnly = true;
            this.rtbMessageBody.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // frmMessages
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(900, 750);
            this.Controls.Add(this.cardMessage);
            this.Controls.Add(this.cardAction);
            this.Controls.Add(this.dgvMessages);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow - Messages";
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.cardAction.ResumeLayout(false);
            this.cardMessage.ResumeLayout(false);
            this.cardMessage.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
