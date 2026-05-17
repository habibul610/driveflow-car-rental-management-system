using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmNewMessage : Form
    {
        private MessageBLL messageBLL = new MessageBLL();

        public frmNewMessage(Form parent)
        {
            InitializeComponent();
            
            this.Load += frmNewMessage_Load;
            this.btnSend.Click += btnSend_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void frmNewMessage_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnSend, "primary");
            UIHelper.StyleButton(btnCancel, "neutral");
            UIHelper.ApplyFocusBorder(pnlSubjectWrapper, txtSubject);
            UIHelper.ApplyFocusBorder(pnlBodyWrapper, txtBody);

            LoadReceivers();
        }

        private void LoadReceivers()
        {
            DataTable dt = messageBLL.GetAvailableReceivers();
            
            // Filter out current user
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"UserID <> {SessionManager.CurrentUser.UserID}";

            cmbReceiver.DataSource = dv;
            cmbReceiver.DisplayMember = "FullName";
            cmbReceiver.ValueMember = "UserID";
            cmbReceiver.SelectedIndex = -1;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReceiver.SelectedValue == null)
                {
                    MessageBox.Show("Please select a receiver.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int receiverId = (int)cmbReceiver.SelectedValue;
                string subject = txtSubject.Text.Trim();
                string body = txtBody.Text.Trim();

                if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
                {
                    MessageBox.Show("Subject and Body cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (messageBLL.SendMessage(SessionManager.CurrentUser.UserID, receiverId, subject, body))
                {
                    MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to send message. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
