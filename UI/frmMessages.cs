using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmMessages : Form
    {
        private Form parentForm;
        private MessageBLL messageBLL = new MessageBLL();

        public frmMessages(Form parent)
        {
            InitializeComponent();
            parentForm = parent;

            // Wire up events
            this.Load += frmMessages_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnNewMessage.Click += btnNewMessage_Click;
            this.btnMarkRead.Click += btnMarkRead_Click;
        }

        private void frmMessages_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnNewMessage, "primary");
            UIHelper.StyleButton(btnMarkRead, "success");
            UIHelper.StyleDataGridView(dgvMessages);

            LoadMessages();
        }

        private void LoadMessages()
        {
            DataTable dt = messageBLL.GetInbox(SessionManager.CurrentUser.UserID);
            dgvMessages.DataSource = dt;

            if (dgvMessages.Columns.Contains("MessageID")) dgvMessages.Columns["MessageID"].Visible = false;
            if (dgvMessages.Columns.Contains("SenderID")) dgvMessages.Columns["SenderID"].Visible = false;
            if (dgvMessages.Columns.Contains("ReceiverID")) dgvMessages.Columns["ReceiverID"].Visible = false;
            if (dgvMessages.Columns.Contains("MessageBody")) dgvMessages.Columns["MessageBody"].Visible = false;

            if (dgvMessages.Columns.Contains("SenderName")) dgvMessages.Columns["SenderName"].HeaderText = "From";
            if (dgvMessages.Columns.Contains("Subject")) dgvMessages.Columns["Subject"].HeaderText = "Subject";
            if (dgvMessages.Columns.Contains("SentDate")) dgvMessages.Columns["SentDate"].HeaderText = "Date";
            if (dgvMessages.Columns.Contains("IsRead")) dgvMessages.Columns["IsRead"].HeaderText = "Read?";

            dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Show empty-state message when inbox has no messages
            if (dt.Rows.Count == 0)
            {
                rtbMessageBody.Text = "📭  Your inbox is empty. Use \"New Message\" to send one!";
                rtbMessageBody.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            }
            else
            {
                rtbMessageBody.Text = "";
                rtbMessageBody.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void btnNewMessage_Click(object sender, EventArgs e)
        {
            frmNewMessage frmNew = new frmNewMessage(this);
            frmNew.ShowDialog();
            LoadMessages();
        }

        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                // MessageID is hidden (Visible=false) but still accessible by cell name — this is correct.
                // Setting Visible=false hides the column visually but does NOT remove it from the Cells collection.
                int messageId = Convert.ToInt32(dgvMessages.SelectedRows[0].Cells["MessageID"].Value);
                if (messageBLL.MarkAsRead(messageId))
                {
                    LoadMessages();
                }
            }
            else
            {
                MessageBox.Show("Please select a message to mark as read.");
            }
        }

        private void dgvMessages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                var row = dgvMessages.SelectedRows[0];
                if (row.Cells["MessageBody"].Value != null)
                {
                    rtbMessageBody.Text = row.Cells["MessageBody"].Value.ToString();
                }
                else
                {
                    rtbMessageBody.Text = "";
                }
            }
            else
            {
                rtbMessageBody.Text = "";
            }
        }
    }
}
