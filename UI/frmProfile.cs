using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmProfile : Form
    {
        private Form parentForm;
        private UserBLL userBLL = new UserBLL();

        public frmProfile(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnSave, "success");
            UIHelper.StyleButton(btnChangePassword, "primary");
            
            UIHelper.ApplyFocusBorder(pnlFullNameWrapper, txtFullName);
            UIHelper.ApplyFocusBorder(pnlUsernameWrapper, txtUsername);
            UIHelper.ApplyFocusBorder(pnlEmailWrapper, txtEmail);
            UIHelper.ApplyFocusBorder(pnlPhoneWrapper, txtPhone);
            
            UIHelper.DrawAvatar(pnlAvatar, SessionManager.CurrentUser?.FullName ?? "User");
            
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            if (SessionManager.IsLoggedIn())
            {
                txtFullName.Text = SessionManager.CurrentUser.FullName;
                txtUsername.Text = SessionManager.CurrentUser.Username;
                txtEmail.Text = SessionManager.CurrentUser.Email;
                txtPhone.Text = SessionManager.CurrentUser.Phone;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (parentForm is frmAdminHome adminHome)
            {
                adminHome.LoadDashboardData();
            }
            else if (parentForm is frmCustomerHome custHome)
            {
                custHome.LoadDashboardData();
            }
            else if (parentForm is frmManagerHome managerHome)
            {
                // Refresh manager welcome label in case name was changed
                managerHome.RefreshWelcome();
            }
            parentForm.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full Name cannot be empty.");
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show("Phone must be 11 numeric digits.");
                return;
            }

            SessionManager.CurrentUser.FullName = fullName;
            SessionManager.CurrentUser.Email = email;
            SessionManager.CurrentUser.Phone = phone;

            if (userBLL.UpdateProfile(SessionManager.CurrentUser))
            {
                MessageBox.Show("Profile updated successfully!");
                LoadProfileData();
            }
            else
            {
                MessageBox.Show("Failed to update profile.");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = PromptForPassword("Enter Current Password:");
            if (string.IsNullOrEmpty(currentPassword)) return;

            string newPassword = PromptForPassword("Enter New Password:");
            if (string.IsNullOrEmpty(newPassword)) return;

            if (!ValidationHelper.IsValidPassword(newPassword))
            {
                MessageBox.Show("New password must be at least 8 characters.");
                return;
            }

            if (userBLL.ChangePassword(SessionManager.CurrentUser.UserID, currentPassword, newPassword))
            {
                MessageBox.Show("Password changed successfully!");
            }
            else
            {
                MessageBox.Show("Failed to change password. Current password might be incorrect.");
            }
        }

        private string PromptForPassword(string text)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 210,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Change Password",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.White
            };

            Label textLabel = new Label()
            {
                Left = 50, Top = 20,
                Text = text,
                Width = 300,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(27, 58, 107)
            };

            Panel pnlWrapper = new Panel()
            {
                Left = 50, Top = 50,
                Width = 280, Height = 34
            };

            TextBox textBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                PasswordChar = '●',
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            pnlWrapper.Controls.Add(textBox);
            UIHelper.ApplyFocusBorder(pnlWrapper, textBox);

            Button confirmation = new Button()
            {
                Text = "Confirm",
                Left = 130, Width = 100, Height = 36, Top = 105,
                DialogResult = DialogResult.OK
            };
            UIHelper.StyleButton(confirmation, "primary");
            confirmation.Click += (sender, e) => { prompt.Close(); };

            Button cancelBtn = new Button()
            {
                Text = "Cancel",
                Left = 240, Width = 90, Height = 36, Top = 105,
                DialogResult = DialogResult.Cancel
            };
            UIHelper.StyleButton(cancelBtn, "neutral");
            cancelBtn.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(pnlWrapper);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelBtn);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelBtn;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
