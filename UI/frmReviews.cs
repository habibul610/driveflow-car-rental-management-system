using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public class frmReviews : Form
    {
        private Form parentForm;
        private ReviewBLL reviewBLL = new ReviewBLL();
        private BookingBLL bookingBLL = new BookingBLL();
        private FlowLayoutPanel flpReviews;

        public frmReviews(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Customer Reviews";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            UIHelper.SetupForm(this);

            Label lblTitle = new Label { Text = "Customer Reviews", Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(20, 20), ForeColor = Color.FromArgb(15, 23, 42) };
            
            Button btnBack = new Button { Text = "Back", Location = new Point(680, 20), Size = new Size(80, 30) };
            UIHelper.StyleButton(btnBack, "neutral");
            btnBack.Click += (s, e) => { parentForm.Show(); this.Close(); };

            flpReviews = new FlowLayoutPanel
            {
                Location = new Point(20, 70),
                Size = new Size(740, 400),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnBack);
            this.Controls.Add(flpReviews);

            if (SessionManager.CurrentUser.Role == "Customer")
            {
                Panel pnlWrite = new Panel { Location = new Point(20, 480), Size = new Size(740, 80), BackColor = Color.Transparent };
                Button btnWrite = new Button { Text = "Write a Review", Location = new Point(10, 10), Size = new Size(180, 40) };
                UIHelper.StyleButton(btnWrite, "primary");
                btnWrite.Click += BtnWrite_Click;
                pnlWrite.Controls.Add(btnWrite);
                this.Controls.Add(pnlWrite);
            }

            this.Load += (s, e) => LoadReviews();
        }

        private void LoadReviews()
        {
            flpReviews.Controls.Clear();
            var reviews = reviewBLL.GetAllReviews();
            foreach (var r in reviews)
            {
                Panel pnl = new Panel { Width = 700, Height = 80, BackColor = Color.White, Margin = new Padding(0, 0, 0, 10) };
                string stars = new string('★', r.Rating) + new string('☆', 5 - r.Rating);
                Label lblRating = new Label { Text = stars, Font = new Font("Segoe UI", 12), ForeColor = Color.FromArgb(245, 158, 11), Location = new Point(10, 10), AutoSize = true };
                Label lblUser = new Label { Text = $"{r.UserName} reviewed {r.CarName} on {r.ReviewDate:MMM dd, yyyy}", Font = new Font("Segoe UI", 9, FontStyle.Italic), ForeColor = Color.Gray, Location = new Point(100, 13), AutoSize = true };
                Label lblComment = new Label { Text = r.Comment, Font = new Font("Segoe UI", 10), Location = new Point(10, 40), Size = new Size(680, 40) };
                
                pnl.Controls.Add(lblRating);
                pnl.Controls.Add(lblUser);
                pnl.Controls.Add(lblComment);

                // Add Edit button for owner
                if (SessionManager.CurrentUser.UserID == r.UserID || SessionManager.CurrentUser.FullName == r.UserName)
                {
                    Button btnEdit = new Button { Text = "Edit Review", Location = new Point(490, 10), Size = new Size(110, 30) };
                    UIHelper.StyleButton(btnEdit, "secondary");
                    btnEdit.BringToFront();
                    btnEdit.Click += (s, e) => ShowEditPrompt(r);
                    pnl.Controls.Add(btnEdit);
                }

                // Add Delete button for Admin
                if (SessionManager.CurrentUser.Role == "Admin" || SessionManager.CurrentUser.Role == "Manager")
                {
                    Button btnDelete = new Button { Text = "Delete", Location = new Point(610, 10), Size = new Size(60, 25) };
                    UIHelper.StyleButton(btnDelete, "danger");
                    btnDelete.Click += (s, e) =>
                    {
                        if (MessageBox.Show("Delete this review?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            reviewBLL.DeleteReview(r.ReviewID);
                            LoadReviews();
                        }
                    };
                    pnl.Controls.Add(btnDelete);
                }

                flpReviews.Controls.Add(pnl);
            }
        }

        private void ShowEditPrompt(Review r)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 350,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Edit Review",
                StartPosition = FormStartPosition.CenterScreen
            };
            UIHelper.SetupForm(prompt);

            Label lblCar = new Label() { Left = 20, Top = 20, Text = $"Car: {r.CarName}", AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            
            Label ratingLabel = new Label() { Left = 20, Top = 60, Text = "Rating (1-5):" };
            NumericUpDown numRating = new NumericUpDown() { Left = 20, Top = 80, Width = 100, Minimum = 1, Maximum = 5, Value = r.Rating };

            Label commentLabel = new Label() { Left = 20, Top = 120, Text = "Comment:" };
            Panel pnlComment = new Panel() { Left = 20, Top = 140, Width = 340, Height = 80 };
            TextBox txtComment = new TextBox() { Dock = DockStyle.Fill, Multiline = true, Text = r.Comment };
            pnlComment.Controls.Add(txtComment);
            UIHelper.ApplyFocusBorder(pnlComment, txtComment);

            Button confirmation = new Button() { Text = "Update", Left = 20, Width = 340, Top = 240 };
            UIHelper.StyleButton(confirmation, "primary");
            confirmation.Click += (sender, e) => 
            { 
                try
                {
                    reviewBLL.UpdateReview(r.ReviewID, (int)numRating.Value, txtComment.Text.Trim());
                    LoadReviews();
                    prompt.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update review: " + ex.Message, "Error");
                }
            };

            prompt.Controls.Add(lblCar);
            prompt.Controls.Add(ratingLabel);
            prompt.Controls.Add(numRating);
            prompt.Controls.Add(commentLabel);
            prompt.Controls.Add(pnlComment);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            DataTable myBookings = bookingBLL.GetBookingsByUserID(SessionManager.CurrentUser.UserID);
            DataRow[] completedBookings = myBookings.Select("Status = 'Completed'");
            if (completedBookings.Length == 0)
            {
                MessageBox.Show("You must have completed a booking to write a review.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form prompt = new Form()
            {
                Width = 400,
                Height = 350,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Write Review",
                StartPosition = FormStartPosition.CenterScreen
            };
            UIHelper.SetupForm(prompt);

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Select Car:" };
            ComboBox cmbCars = new ComboBox() { Left = 20, Top = 40, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (DataRow row in completedBookings)
            {
                cmbCars.Items.Add(new { Text = row["CarDetails"].ToString(), Value = Convert.ToInt32(row["CarID"]) });
            }
            cmbCars.DisplayMember = "Text";
            cmbCars.ValueMember = "Value";
            if (cmbCars.Items.Count > 0) cmbCars.SelectedIndex = 0;

            Label ratingLabel = new Label() { Left = 20, Top = 80, Text = "Rating (1-5):" };
            NumericUpDown numRating = new NumericUpDown() { Left = 20, Top = 100, Width = 100, Minimum = 1, Maximum = 5, Value = 5 };

            Label commentLabel = new Label() { Left = 20, Top = 140, Text = "Comment:" };
            Panel pnlComment = new Panel() { Left = 20, Top = 160, Width = 340, Height = 80 };
            TextBox txtComment = new TextBox() { Dock = DockStyle.Fill, Multiline = true };
            pnlComment.Controls.Add(txtComment);
            UIHelper.ApplyFocusBorder(pnlComment, txtComment);

            Button confirmation = new Button() { Text = "Submit", Left = 20, Width = 340, Top = 260 };
            UIHelper.StyleButton(confirmation, "primary");
            confirmation.Click += (sender, e) => 
            { 
                if (cmbCars.SelectedItem != null)
                {
                    dynamic selected = cmbCars.SelectedItem;
                    var review = new Review
                    {
                        CarID = selected.Value,
                        UserID = SessionManager.CurrentUser.UserID,
                        Rating = (int)numRating.Value,
                        Comment = txtComment.Text.Trim()
                    };
                    reviewBLL.CreateReview(review);
                    LoadReviews();
                }
                prompt.Close(); 
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cmbCars);
            prompt.Controls.Add(ratingLabel);
            prompt.Controls.Add(numRating);
            prompt.Controls.Add(commentLabel);
            prompt.Controls.Add(pnlComment);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
        }
    }
}
