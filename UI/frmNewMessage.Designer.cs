namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmNewMessage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.ComboBox cmbReceiver;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Panel pnlSubjectWrapper;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Panel pnlBodyWrapper;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblReceiver = new System.Windows.Forms.Label();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.pnlSubjectWrapper = new System.Windows.Forms.Panel();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.pnlBodyWrapper = new System.Windows.Forms.Panel();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.pnlSubjectWrapper.SuspendLayout();
            this.pnlBodyWrapper.SuspendLayout();
            this.SuspendLayout();
            
            // lblReceiver
            this.lblReceiver.Location = new System.Drawing.Point(30, 20);
            this.lblReceiver.Size = new System.Drawing.Size(100, 20);
            this.lblReceiver.Text = "Receiver:";
            
            // cmbReceiver
            this.cmbReceiver.Location = new System.Drawing.Point(30, 40);
            this.cmbReceiver.Size = new System.Drawing.Size(340, 25);
            this.cmbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            // lblSubject
            this.lblSubject.Location = new System.Drawing.Point(30, 80);
            this.lblSubject.Size = new System.Drawing.Size(100, 20);
            this.lblSubject.Text = "Subject:";
            
            // pnlSubjectWrapper
            this.pnlSubjectWrapper.Location = new System.Drawing.Point(30, 100);
            this.pnlSubjectWrapper.Size = new System.Drawing.Size(340, 34);
            this.pnlSubjectWrapper.Controls.Add(this.txtSubject);
            
            // txtSubject
            this.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubject.Multiline = true;
            
            // lblBody
            this.lblBody.Location = new System.Drawing.Point(30, 150);
            this.lblBody.Size = new System.Drawing.Size(100, 20);
            this.lblBody.Text = "Message:";
            
            // pnlBodyWrapper
            this.pnlBodyWrapper.Location = new System.Drawing.Point(30, 170);
            this.pnlBodyWrapper.Size = new System.Drawing.Size(340, 150);
            this.pnlBodyWrapper.Controls.Add(this.txtBody);
            
            // txtBody
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBody.Multiline = true;
            
            // btnSend
            this.btnSend.Location = new System.Drawing.Point(30, 340);
            this.btnSend.Size = new System.Drawing.Size(160, 40);
            this.btnSend.Text = "Send Message";
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(210, 340);
            this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.Text = "Cancel";
            
            // frmNewMessage
            this.ClientSize = new System.Drawing.Size(400, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.pnlBodyWrapper);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.pnlSubjectWrapper);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbReceiver);
            this.Controls.Add(this.lblReceiver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Message";
            
            this.pnlSubjectWrapper.ResumeLayout(false);
            this.pnlSubjectWrapper.PerformLayout();
            this.pnlBodyWrapper.ResumeLayout(false);
            this.pnlBodyWrapper.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
