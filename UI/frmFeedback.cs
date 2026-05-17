using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmFeedback : Form
    {
        private Form parentForm;
        private FeedbackBLL feedbackBLL;
        private bool isAdminView = false;

        // UI Components
        private ComboBox cmbRating;
        private TextBox txtComments;
        private Button btnSubmit;
        private Button btnBack;
        private DataGridView dgvFeedback;
        private Label lblTitle;

        public frmFeedback(Form parent)
        {
            InitializeComponentManual();
            parentForm = parent;
            
            feedbackBLL = new FeedbackBLL();
            if (SessionManager.CurrentUser != null)
            {
                isAdminView = SessionManager.CurrentUser.Role == "Admin" || SessionManager.CurrentUser.Role == "Manager";
            }
            
            SetupUI();
        }

        private void InitializeComponentManual()
        {
            this.Size = new Size(800, 500);
            this.Text = "DriveFlow — Feedback";
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label { Text = "Feedback", Font = new Font("Segoe UI", 18, FontStyle.Bold), Top = 20, Left = 20, AutoSize = true };

            btnBack = new Button { Text = "← Back", Top = 20, Width = 90, Height = 32,
                Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnBack.Left = this.ClientSize.Width - btnBack.Width - 20;
            btnBack.Click += (s, e) => { parentForm.Show(); this.Close(); };
            this.Resize += (s, e) => { btnBack.Left = this.ClientSize.Width - btnBack.Width - 20; };

            dgvFeedback = new DataGridView { Top = 70, Left = 20, Width = 745, Height = 380, Visible = false };
            
            // Submission controls
            Label lblRating = new Label { Text = "Rating (1-5):", Top = 80, Left = 50, AutoSize = true };
            cmbRating = new ComboBox { Top = 80, Left = 150, Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRating.Items.AddRange(new object[] { "5 - Excellent", "4 - Good", "3 - Average", "2 - Poor", "1 - Terrible" });
            
            Label lblComments = new Label { Text = "Comments:", Top = 120, Left = 50, AutoSize = true };
            txtComments = new TextBox { Top = 120, Left = 150, Width = 500, Height = 200, Multiline = true };
            
            btnSubmit = new Button { Text = "Submit Feedback", Top = 340, Left = 150, Width = 150, Height = 40 };
            btnSubmit.Click += btnSubmit_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnBack);
            this.Controls.Add(dgvFeedback);
            this.Controls.Add(lblRating);
            this.Controls.Add(cmbRating);
            this.Controls.Add(lblComments);
            this.Controls.Add(txtComments);
            this.Controls.Add(btnSubmit);
        }

        private void SetupUI()
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnSubmit, "primary");
            UIHelper.StyleDataGridView(dgvFeedback);

            if (isAdminView)
            {
                lblTitle.Text = "User Feedback Logs";
                // Reposition DGV to fill the panel (hiding submission controls leaves blank space)
                dgvFeedback.Top = 70;
                dgvFeedback.Height = this.ClientSize.Height - 90;
                dgvFeedback.Visible = true;
                cmbRating.Visible = false;
                txtComments.Visible = false;
                btnSubmit.Visible = false;
                // Hide rating/comments labels only
                foreach (Control c in this.Controls)
                    if (c is Label && c != lblTitle) c.Visible = false;

                // Add Delete button column if not exists
                if (!dgvFeedback.Columns.Contains("DeleteBtn"))
                {
                    DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn
                    {
                        Name = "DeleteBtn",
                        HeaderText = "Action",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true,
                        FlatStyle = FlatStyle.Flat
                    };
                    dgvFeedback.Columns.Add(btnDel);
                    dgvFeedback.CellClick -= DgvFeedback_CellClick; // prevent multiple attachments
                    dgvFeedback.CellClick += DgvFeedback_CellClick;
                }

                LoadFeedback();
            }
            else
            {
                lblTitle.Text = "Share Your Experience";
            }
        }

        private void LoadFeedback()
        {
            try
            {
                DataTable dt = feedbackBLL.GetAllFeedback();
                dgvFeedback.DataSource = dt;
                
                if (dgvFeedback.Columns.Count > 0)
                {
                    if (dgvFeedback.Columns.Contains("FeedbackID")) dgvFeedback.Columns["FeedbackID"].Visible = false;
                    if (dgvFeedback.Columns.Contains("FeedbackDate")) dgvFeedback.Columns["FeedbackDate"].HeaderText = "Date";
                }
            }
            catch (Exception ex)
            {
                string detail = ex.StackTrace ?? "No stack trace";
                MessageBox.Show($"Error loading feedback: {ex.Message}\n\nStack: {detail}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFeedback_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvFeedback.Columns["DeleteBtn"].Index)
            {
                int feedbackId = Convert.ToInt32(dgvFeedback.Rows[e.RowIndex].Cells["FeedbackID"].Value);
                if (MessageBox.Show("Are you sure you want to delete this feedback?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (feedbackBLL.DeleteFeedback(feedbackId))
                    {
                        MessageBox.Show("Feedback deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFeedback();
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbRating.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtComments.Text))
            {
                MessageBox.Show("Please provide a rating and comments.");
                return;
            }

            int rating = 5 - cmbRating.SelectedIndex; // "5 - Excellent" is index 0
            if (feedbackBLL.SubmitFeedback(SessionManager.CurrentUser.UserID, rating, txtComments.Text.Trim()))
            {
                MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBack.PerformClick();
            }
            else
            {
                MessageBox.Show("Failed to submit feedback.");
            }
        }
    }
}
