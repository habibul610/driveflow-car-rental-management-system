using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmBillingRecord : Form
    {
        private Form parentForm;
        private BillingBLL billingBLL = new BillingBLL();
        private DataTable billingTable;
        private bool isAdmin;

        public frmBillingRecord(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            
            if (SessionManager.CurrentUser != null)
            {
                isAdmin = SessionManager.CurrentUser.Role == "Admin" || SessionManager.CurrentUser.Role == "Manager";
                
                if (isAdmin)
                {
                    btnMarkPaid.Text = "💳 Mark as Paid";
                    txtSearch.PlaceholderText = "🔍 Search by Customer, Bill ID, or Status...";
                }
                else
                {
                    btnMarkPaid.Text = "💳 Pay Bill";
                }
            }
        }

        private void frmBillingRecord_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnMarkPaid, "success");
            UIHelper.StyleButton(btnDownloadInvoice, "primary");
            
            UIHelper.ApplyFocusBorder(pnlSearchWrapper, txtSearch);
            
            UIHelper.StyleDataGridView(dgvBilling);
            dgvBilling.CellFormatting += (s, ev) => 
            {
                if (dgvBilling.Columns[ev.ColumnIndex].Name == "PaymentStatus" && ev.Value != null)
                {
                    UIHelper.ApplyStatusColor(ev, ev.Value.ToString());
                }
            };
            
            LoadBilling();
        }

        private void LoadBilling()
        {
            if (isAdmin)
            {
                billingTable = billingBLL.GetAllBillingRecords();
            }
            else
            {
                billingTable = billingBLL.GetBillingRecordsByUserID(SessionManager.CurrentUser.UserID);
            }
            ApplyFilters();
            dgvBilling.ClearSelection();
        }

        private void ApplyFilters()
        {
            if (billingTable == null) return;
            string search = txtSearch.Text.Trim().ToLower();

            DataView dv = billingTable.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                // Escape apostrophe to prevent crash (L-1)
                string safeSearch = search.Replace("'", "''");
                
                if (isAdmin)
                {
                    dv.RowFilter = $"PaymentStatus LIKE '%{safeSearch}%' OR Convert(BillID, 'System.String') LIKE '%{safeSearch}%' OR CustomerName LIKE '%{safeSearch}%'";
                }
                else
                {
                    dv.RowFilter = $"PaymentStatus LIKE '%{safeSearch}%' OR Convert(BillID, 'System.String') LIKE '%{safeSearch}%' OR Convert(TotalAmount, 'System.String') LIKE '%{safeSearch}%'";
                }
            }
            else
            {
                dv.RowFilter = "1=1";
            }
            dgvBilling.DataSource = dv;
            
            if (dgvBilling.Columns["CustomerName"] != null) dgvBilling.Columns["CustomerName"].HeaderText = "Customer";
            if (dgvBilling.Columns["CarDetails"] != null) dgvBilling.Columns["CarDetails"].HeaderText = "Car Details";
            if (dgvBilling.Columns["RentStart"] != null) dgvBilling.Columns["RentStart"].HeaderText = "Rent Start";
            if (dgvBilling.Columns["RentEnd"] != null) dgvBilling.Columns["RentEnd"].HeaderText = "Rent End";
            if (dgvBilling.Columns["DaysRented"] != null) dgvBilling.Columns["DaysRented"].HeaderText = "Days";
            if (dgvBilling.Columns["DailyRate"] != null) dgvBilling.Columns["DailyRate"].HeaderText = "Daily Rate";
            if (dgvBilling.Columns["TotalAmount"] != null) dgvBilling.Columns["TotalAmount"].HeaderText = "Total (BDT)";
            if (dgvBilling.Columns["BillDate"] != null) dgvBilling.Columns["BillDate"].HeaderText = "Bill Date";
            if (dgvBilling.Columns["PaymentStatus"] != null) dgvBilling.Columns["PaymentStatus"].HeaderText = "Status";
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            else if (parentForm is frmCustomerHome custHome)
            {
                custHome.LoadDashboardData();
            }
            parentForm.Show();
            this.Close();
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBilling.SelectedRows[0];
                int billingId = Convert.ToInt32(row.Cells["BillID"].Value);
                string status = row.Cells["PaymentStatus"].Value.ToString();

                if (status == "Paid")
                {
                    MessageBox.Show("This bill is already paid.");
                    return;
                }

                string msg = isAdmin ? "Mark this bill as Paid?" : "Proceed with payment for this bill?";
                var result = MessageBox.Show(msg, "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (!isAdmin)
                    {
                        decimal amountToPay = Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                        frmPaymentGateway gateway = new frmPaymentGateway(amountToPay);
                        if (gateway.ShowDialog() != DialogResult.OK)
                        {
                            return; // Payment cancelled or failed
                        }
                    }

                    if (billingBLL.UpdatePaymentStatus(billingId, "Paid"))
                    {
                        MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBilling();
                    }
                    else
                    {
                        MessageBox.Show("Failed to process payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a billing record.");
            }
        }

        private void btnDownloadInvoice_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvBilling.SelectedRows[0];
                    DataRowView drv = (DataRowView)row.DataBoundItem;
                    DataRow dataRow = drv.Row;

                    string customerName = isAdmin ? dataRow["CustomerName"].ToString() : SessionManager.CurrentUser.FullName;
                    string billId = dataRow["BillID"].ToString();

                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "PDF Document (*.pdf)|*.pdf",
                        FileName = $"Invoice_{billId}.pdf",
                        Title = "Save Invoice"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        PDFGenerator.GenerateInvoice(dataRow, customerName, sfd.FileName);
                        MessageBox.Show("Invoice generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Optionally open it automatically
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a billing record to download.");
            }
        }
    }
}
