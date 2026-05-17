using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmMyBookings : Form
    {
        private Form parentForm;
        private BookingBLL bookingBLL = new BookingBLL();
        private CarBLL carBLL = new CarBLL();

        public frmMyBookings(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmMyBookings_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnCancelBooking, "danger");
            UIHelper.StyleButton(btnReturnCar, "success");
            
            UIHelper.StyleDataGridView(dgvMyBookings);
            dgvMyBookings.CellFormatting += (s, ev) => 
            {
                if (dgvMyBookings.Columns[ev.ColumnIndex].Name == "Status" && ev.Value != null)
                {
                    UIHelper.ApplyStatusColor(ev, ev.Value.ToString());
                }
            };
            
            LoadMyBookings();
        }

        private void LoadMyBookings()
        {
            try
            {
                DataTable dt = bookingBLL.GetBookingsByUserID(SessionManager.CurrentUser.UserID);
                dgvMyBookings.DataSource = dt;
                
                if (dgvMyBookings.Columns["BookingID"] != null) dgvMyBookings.Columns["BookingID"].HeaderText = "Booking ID";
                if (dgvMyBookings.Columns["CarDetails"] != null) dgvMyBookings.Columns["CarDetails"].HeaderText = "Car Details";
                if (dgvMyBookings.Columns["PickupDate"] != null) dgvMyBookings.Columns["PickupDate"].HeaderText = "Pickup Date";
                if (dgvMyBookings.Columns["ExpectedReturnDate"] != null) dgvMyBookings.Columns["ExpectedReturnDate"].HeaderText = "Exp. Return Date";
                if (dgvMyBookings.Columns["ActualReturnDate"] != null) dgvMyBookings.Columns["ActualReturnDate"].HeaderText = "Act. Return Date";
                if (dgvMyBookings.Columns["TotalAmount"] != null) dgvMyBookings.Columns["TotalAmount"].HeaderText = "Total (BDT)";
                
                if (dgvMyBookings.Columns.Contains("CarID"))
                {
                    dgvMyBookings.Columns["CarID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (parentForm is frmCustomerHome custHome)
            {
                custHome.LoadDashboardData();
            }
            parentForm.Show();
            this.Close();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMyBookings.SelectedRows[0];
                int bookingId = Convert.ToInt32(row.Cells["BookingID"].Value);
                string status = row.Cells["Status"].Value.ToString();

                if (status != "Pending")
                {
                    MessageBox.Show("You can only cancel Pending bookings. For Active bookings, please return the car.");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (bookingBLL.CancelBooking(bookingId))
                    {
                        MessageBox.Show("Booking cancelled successfully.");
                        LoadMyBookings();
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel booking.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking.");
            }
        }

        private void btnReturnCar_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMyBookings.SelectedRows[0];
                int bookingId = Convert.ToInt32(row.Cells["BookingID"].Value);
                string status = row.Cells["Status"].Value.ToString();

                if (status != "Active")
                {
                    MessageBox.Show("You can only return cars for Active bookings.");
                    return;
                }

                var result = MessageBox.Show(
                    "Confirm return of this car today?\n\n" +
                    "Note: A final bill will be generated immediately.\n" +
                    "Minimum charge is 1 day even for same-day returns.",
                    "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int carId = Convert.ToInt32(row.Cells["CarID"].Value);
                        DateTime pickup = Convert.ToDateTime(row.Cells["PickupDate"].Value);
                        DateTime expected = Convert.ToDateTime(row.Cells["ExpectedReturnDate"].Value);
                        DateTime actual = DateTime.Today;
                        
                        Car car = carBLL.GetCarByID(carId);
                        if (car == null)
                        {
                            MessageBox.Show("Error: Car details not found.");
                            return;
                        }
                        
                        decimal discountAmount = 0;
                        if (row.DataBoundItem is DataRowView drv && drv["DiscountAmount"] != DBNull.Value)
                        {
                            discountAmount = Convert.ToDecimal(drv["DiscountAmount"]);
                        }
                        
                        if (bookingBLL.ProcessReturn(bookingId, carId, pickup, expected, actual, car.DailyRate, discountAmount))
                        {
                            MessageBox.Show("Car returned successfully! A bill has been generated.");
                            LoadMyBookings();
                        }
                        else
                        {
                            MessageBox.Show("Failed to process return.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error processing return: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking.");
            }
        }
    }
}
