using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmCreateManager : Form
    {
        private UserBLL userBLL = new UserBLL();

        public frmCreateManager()
        {
            InitializeComponent();
            
            this.Load += (s, e) => {
                UIHelper.SetupForm(this);
                UIHelper.StyleButton(btnCreate, "success");
                UIHelper.StyleButton(btnCancel, "neutral");
                UIHelper.ApplyFocusBorder(pnlFullNameWrapper, txtFullName);
                UIHelper.ApplyFocusBorder(pnlUsernameWrapper, txtUsername);
                UIHelper.ApplyFocusBorder(pnlEmailWrapper, txtEmail);
                UIHelper.ApplyFocusBorder(pnlPhoneWrapper, txtPhone);
                UIHelper.ApplyFocusBorder(pnlPasswordWrapper, txtPassword);
            };
            
            this.btnCreate.Click += btnCreate_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text; // Do NOT trim passwords

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (userBLL.RegisterManager(fullName, username, email, phone, password))
            {
                MessageBox.Show("Manager account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create manager account. Username or email might already exist.");
            }
        }
    }
}
