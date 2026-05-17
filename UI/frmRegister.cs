using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmRegister : Form
    {
        private UserBLL userBLL = new UserBLL();

        public frmRegister()
        {
            InitializeComponent();
            
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnRegister, "accent"); // Accent = Electric Blue #2563EB
            UIHelper.ApplyFocusBorder(pnlFullNameWrapper, txtFullName);
            UIHelper.ApplyFocusBorder(pnlUsernameWrapper, txtUsername);
            UIHelper.ApplyFocusBorder(pnlEmailWrapper, txtEmail);
            UIHelper.ApplyFocusBorder(pnlPhoneWrapper, txtPhone);
            UIHelper.ApplyFocusBorder(pnlPasswordWrapper, txtPassword);
            UIHelper.ApplyFocusBorder(pnlConfirmPasswordWrapper, txtConfirmPassword);
            
            // Password toggle logic
            lblShowHidePwd.Click += (s, e) => TogglePasswordVisibility(txtPassword, lblShowHidePwd);
            lblShowHideConfirmPwd.Click += (s, e) => TogglePasswordVisibility(txtConfirmPassword, lblShowHideConfirmPwd);
        }

        private void TogglePasswordVisibility(TextBox txt, Label lbl)
        {
            if (txt.PasswordChar == '●')
            {
                txt.PasswordChar = '\0';
                lbl.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            }
            else
            {
                txt.PasswordChar = '●';
                lbl.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Name and Username are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show("Phone number must be 11 digits and numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = userBLL.RegisterCustomer(fullName, username, email, phone, password);
                if (success)
                {
                    MessageBox.Show("Registration successful! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnToLogin();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReturnToLogin();
        }

        private void ReturnToLogin()
        {
            this.Close(); // This triggers FormClosed (L-7)
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            var loginForm = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                new frmLogin().Show();
            }
        }
    }
}
