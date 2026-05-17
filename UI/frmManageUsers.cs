using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmManageUsers : Form
    {
        private Form parentForm;
        private UserBLL userBLL = new UserBLL();
        private DataTable usersTable;

        public frmManageUsers(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnViewProfile, "primary");
            UIHelper.StyleButton(btnDeleteUser, "danger");
            UIHelper.StyleButton(btnAddManager, "success");
            
            UIHelper.ApplyFocusBorder(pnlSearchWrapper, txtSearch);
            UIHelper.StyleDataGridView(dgvUsers);
            
            LoadUsers();
        }

        private void LoadUsers()
        {
            usersTable = userBLL.GetAllCustomers();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (usersTable == null) return;
            string search = txtSearch.Text.Trim().ToLower();
            
            DataView dv = usersTable.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                // Escape apostrophe (L-1)
                string safeSearch = search.Replace("'", "''");
                dv.RowFilter = $"FullName LIKE '%{safeSearch}%' OR Username LIKE '%{safeSearch}%' OR Email LIKE '%{safeSearch}%'";
            }
            else
            {
                dv.RowFilter = "1=1";
            }
            dgvUsers.DataSource = dv;
            if (dgvUsers.Columns["RegistrationDate"] != null)
            {
                dgvUsers.Columns["RegistrationDate"].HeaderText = "Registration Date";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (parentForm is frmAdminHome adminHome)
            {
                adminHome.LoadDashboardData();
            }
            parentForm.Show();
            this.Close();
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                string details = $"Name: {row.Cells["FullName"].Value}\n" +
                                 $"Username: {row.Cells["Username"].Value}\n" +
                                 $"Email: {row.Cells["Email"].Value}\n" +
                                 $"Phone: {row.Cells["Phone"].Value}\n" +
                                 $"Registered: {Convert.ToDateTime(row.Cells["RegistrationDate"].Value):yyyy-MM-dd}";
                MessageBox.Show(details, "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a user to view.");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (userBLL.DeleteUser(userId))
                        {
                            MessageBox.Show("User deleted successfully.");
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete user.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            frmCreateManager frm = new frmCreateManager();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Note: LoadUsers shows only Customers, so the new manager
                // will NOT appear in this grid — this is by design.
                // The manager can log in with their credentials immediately.
                MessageBox.Show(
                    "Manager created successfully!\n\nNote: This list shows Customers only. " +
                    "Managers can log in with their credentials right away.",
                    "Manager Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }
    }
}
