using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmLogin : Form
    {
        private UserBLL userBLL = new UserBLL();

        public frmLogin()
        {
            InitializeComponent();
            this.Text = "DriveFlow - Professional Car Rental";
            this.AcceptButton = btnLogin; 

            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnLogin, "primary");
            UIHelper.ApplyFocusBorder(pnlUsernameWrapper, txtUsername);
            UIHelper.ApplyFocusBorder(pnlPasswordWrapper, txtPassword);
            
            // Password toggle logic
            lblShowHide.Click += (s, e) => 
            {
                if (txtPassword.PasswordChar == '●')
                {
                    txtPassword.PasswordChar = '\0';
                    lblShowHide.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235); // #2563EB
                }
                else
                {
                    txtPassword.PasswordChar = '●';
                    lblShowHide.ForeColor = System.Drawing.Color.Black;
                }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // Q-3: Do not trim passwords

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = userBLL.AuthenticateUser(username, password);

            if (user != null)
            {
                SessionManager.CurrentUser = user;
                
                if (user.Role == "Admin")
                {
                    frmAdminHome adminHome = new frmAdminHome();
                    adminHome.Show();
                }
                else if (user.Role == "Manager")
                {
                    frmManagerHome managerHome = new frmManagerHome();
                    managerHome.Show();
                }
                else
                {
                    frmCustomerHome customerHome = new frmCustomerHome();
                    customerHome.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            registerForm.Show();
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Only exit if no other home forms are visible (L-2)
                bool homeVisible = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Visible && (f is frmAdminHome || f is frmCustomerHome || f is frmManagerHome))
                    {
                        homeVisible = true;
                        break;
                    }
                }
                if (!homeVisible) Application.Exit();
            }
        }
    }
}
