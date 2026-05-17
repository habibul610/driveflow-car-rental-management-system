using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmManageBookings : Form
    {
        private Form parentForm;
        private BookingBLL bookingBLL = new BookingBLL();
        private CarBLL carBLL = new CarBLL();
        private DataTable bookingsTable;
        private int selectedBookingId = 0;
        private int selectedCarId = 0;
        private string selectedStatus = "";
        private DateTime expectedReturn;
        private DateTime pickupDate;

        public frmManageBookings(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            dtpActualReturnDate.Enabled = false;
            btnProcessReturn.Enabled = false;
        }

        private void frmManageBookings_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnApprove, "success");
            UIHelper.StyleButton(btnCancel, "danger");
            UIHelper.StyleButton(btnProcessReturn, "primary");
            UIHelper.StyleButton(btnTrackCar, "primary");
            
            UIHelper.ApplyFocusBorder(pnlSearchWrapper, txtSearch);
            
            UIHelper.StyleDataGridView(dgvBookings);
            dgvBookings.CellFormatting += (s, ev) => 
            {
                if (dgvBookings.Columns[ev.ColumnIndex].Name == "Status" && ev.Value != null)
                {
                    UIHelper.ApplyStatusColor(ev, ev.Value.ToString());
                }
            };

            LoadBookings();
        }

        private void LoadBookings()
        {
            bookingsTable = bookingBLL.GetAllBookings();
            ApplyFilters();
            dgvBookings.ClearSelection();
            selectedBookingId = 0;
            dtpActualReturnDate.Enabled = false;
            btnProcessReturn.Enabled = false;
        }

        private void ApplyFilters()
        {
            if (bookingsTable == null) return;
            string search = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString();

            DataView dv = bookingsTable.DefaultView;
            string filter = "1=1";

            // Only apply status filter if a specific status (not null and not "All") is selected
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                filter += $" AND Status = '{statusFilter}'";
            }

            if (!string.IsNullOrEmpty(search))
            {
                string safeSearch = search.Replace("'", "''");
                filter += $" AND (CustomerName LIKE '%{safeSearch}%' OR CarDetails LIKE '%{safeSearch}%' OR Convert(BookingID, 'System.String') LIKE '%{safeSearch}%')";
            }

            dv.RowFilter = filter;
            dgvBookings.DataSource = dv;
            
            if (dgvBookings.Columns["BookingID"] != null) dgvBookings.Columns["BookingID"].HeaderText = "Booking ID";
            if (dgvBookings.Columns["CustomerName"] != null) dgvBookings.Columns["CustomerName"].HeaderText = "Customer Name";
            if (dgvBookings.Columns["CarDetails"] != null) dgvBookings.Columns["CarDetails"].HeaderText = "Car Details";
            if (dgvBookings.Columns["PickupDate"] != null) { dgvBookings.Columns["PickupDate"].HeaderText = "Pickup Date"; dgvBookings.Columns["PickupDate"].DefaultCellStyle.Format = "yyyy-MM-dd"; }
            if (dgvBookings.Columns["ExpectedReturnDate"] != null) { dgvBookings.Columns["ExpectedReturnDate"].HeaderText = "Exp. Return Date"; dgvBookings.Columns["ExpectedReturnDate"].DefaultCellStyle.Format = "yyyy-MM-dd"; }
            if (dgvBookings.Columns["ActualReturnDate"] != null) { dgvBookings.Columns["ActualReturnDate"].HeaderText = "Act. Return Date"; dgvBookings.Columns["ActualReturnDate"].DefaultCellStyle.Format = "yyyy-MM-dd"; }
            if (dgvBookings.Columns["TotalAmount"] != null) dgvBookings.Columns["TotalAmount"].HeaderText = "Total (BDT)";
            
            if (dgvBookings.Columns.Contains("CarID"))
            {
                dgvBookings.Columns["CarID"].Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                
                // L-2: Robust data retrieval from DataBoundItem
                if (row.DataBoundItem is DataRowView drv)
                {
                    selectedBookingId = Convert.ToInt32(drv["BookingID"]);
                    selectedCarId = Convert.ToInt32(drv["CarID"]);
                    selectedStatus = drv["Status"].ToString();
                    pickupDate = Convert.ToDateTime(drv["PickupDate"]);
                    expectedReturn = Convert.ToDateTime(drv["ExpectedReturnDate"]);
                }
                else
                {
                    selectedBookingId = Convert.ToInt32(row.Cells["BookingID"].Value);
                    selectedCarId = Convert.ToInt32(row.Cells["CarID"].Value);
                    selectedStatus = row.Cells["Status"].Value.ToString();
                    pickupDate = Convert.ToDateTime(row.Cells["PickupDate"].Value);
                    expectedReturn = Convert.ToDateTime(row.Cells["ExpectedReturnDate"].Value);
                }

                if (selectedStatus == "Active")
                {
                    dtpActualReturnDate.Enabled = true;
                    btnProcessReturn.Enabled = true;
                    dtpActualReturnDate.MinDate = pickupDate;
                    dtpActualReturnDate.Value = DateTime.Today < pickupDate ? pickupDate : DateTime.Today;
                    btnTrackCar.Enabled = true;
                }
                else
                {
                    dtpActualReturnDate.Enabled = false;
                    btnProcessReturn.Enabled = false;
                    btnTrackCar.Enabled = false;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0)
            {
                MessageBox.Show("Please select a booking.");
                return;
            }

            if (selectedStatus != "Pending")
            {
                MessageBox.Show("Only Pending bookings can be approved.");
                return;
            }

            if (bookingBLL.ApproveBooking(selectedBookingId, selectedCarId))
            {
                MessageBox.Show("Booking approved.");
                LoadBookings();
            }
            else
            {
                MessageBox.Show("Failed to approve booking.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0)
            {
                MessageBox.Show("Please select a booking.");
                return;
            }

            if (selectedStatus == "Completed" || selectedStatus == "Cancelled")
            {
                MessageBox.Show("This booking cannot be cancelled.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (bookingBLL.CancelBooking(selectedBookingId, selectedCarId, selectedStatus))
                {
                    MessageBox.Show("Booking cancelled.");
                    LoadBookings();
                }
                else
                {
                    MessageBox.Show("Failed to cancel booking.");
                }
            }
        }

        private void btnProcessReturn_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0 || selectedStatus != "Active")
            {
                MessageBox.Show("Please select an Active booking to process return.");
                return;
            }

            DateTime actualReturn = dtpActualReturnDate.Value.Date;
            Car car = carBLL.GetCarByID(selectedCarId);
            if (car == null)
            {
                MessageBox.Show("Car details not found.");
                return;
            }

            decimal dailyRate = car.DailyRate;
            decimal discountAmount = 0;
            
            if (dgvBookings.SelectedRows[0].DataBoundItem is DataRowView drv && drv["DiscountAmount"] != DBNull.Value)
            {
                discountAmount = Convert.ToDecimal(drv["DiscountAmount"]);
            }

            if (bookingBLL.ProcessReturn(selectedBookingId, selectedCarId, pickupDate, expectedReturn, actualReturn, dailyRate, discountAmount))
            {
                MessageBox.Show("Return processed successfully. Bill generated.");
                LoadBookings();
            }
            else
            {
                MessageBox.Show("Failed to process return.");
            }
        }
        private void btnTrackCar_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == 0 || selectedStatus != "Active")
            {
                MessageBox.Show("Please select an Active booking to track.");
                return;
            }

            // Open GPS form without hiding parent — prevents permanent hide if user closes via X
            frmGPSSimulation frm = new frmGPSSimulation(this);
            frm.Show();
        }
    }
}
