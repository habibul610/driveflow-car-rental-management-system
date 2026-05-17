using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.UI.Controls;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmMakeBooking : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private BookingBLL bookingBLL = new BookingBLL();
        private DataTable availableCarsTable;
        private int selectedCarId = 0;
        private decimal selectedCarRate = 0;
        private Car? preSelectedCar;
        private DiscountCouponBLL couponBLL = new DiscountCouponBLL();
        private decimal appliedDiscountPercentage = 0;
        private string appliedCouponCode = "";

        public frmMakeBooking(Form parent, Car? car = null)
        {
            InitializeComponent();
            parentForm = parent;
            preSelectedCar = car;
            
            dtpPickupDate.MinDate = DateTime.Today;
            dtpReturnDate.MinDate = DateTime.Today.AddDays(1);
            cardBooking.Enabled = false;

            // Setup filters UI
            ComboBox cmbBrand = new ComboBox { Name = "cmbBrand", Location = new System.Drawing.Point(390, 115), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbBrand.Items.Add("All Brands");
            cmbBrand.SelectedIndex = 0;
            cmbBrand.SelectedIndexChanged += (s, e) => ApplyFilters();
            this.Controls.Add(cmbBrand);

            ComboBox cmbSort = new ComboBox { Name = "cmbSort", Location = new System.Drawing.Point(555, 115), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbSort.Items.Add("Sort by: Default");
            cmbSort.Items.Add("Price: Low to High");
            cmbSort.Items.Add("Price: High to Low");
            cmbSort.SelectedIndex = 0;
            cmbSort.SelectedIndexChanged += (s, e) => ApplyFilters();
            this.Controls.Add(cmbSort);

            // Add Payment Method Selection UI
            Label lblPaymentMethod = new Label { Text = "Payment Method:", Location = new System.Drawing.Point(20, 240), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            
            RadioButton rdoCard = new RadioButton { Name = "rdoCard", Text = "Card (Full Payment)", Location = new System.Drawing.Point(20, 265), AutoSize = true, Checked = true };
            RadioButton rdoLate = new RadioButton { Name = "rdoLate", Text = "Late Payment", Location = new System.Drawing.Point(20, 290), AutoSize = true };
            
            cardBooking.Controls.Add(lblPaymentMethod);
            cardBooking.Controls.Add(rdoCard);
            cardBooking.Controls.Add(rdoLate);

            // Improved Coupon UI inside cardBooking!
            Panel pnlCoupon = new Panel { Name = "pnlCoupon", Location = new System.Drawing.Point(20, 330), Size = new System.Drawing.Size(280, 90), BackColor = System.Drawing.Color.FromArgb(241, 245, 249), Padding = new Padding(10) };
            pnlCoupon.Region = System.Drawing.Region.FromHrgn(Helpers.UIHelper.CreateRoundRectRgn(0, 0, pnlCoupon.Width, pnlCoupon.Height, 15, 15));
            
            Label lblCouponTitle = new Label { Text = "🎟️ Have a Coupon?", Location = new System.Drawing.Point(10, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(51, 65, 85) };
            TextBox txtCoupon = new TextBox { Name = "txtCoupon", Location = new System.Drawing.Point(10, 35), Width = 160, Font = new System.Drawing.Font("Segoe UI", 10F) };
            Button btnApply = new Button { Name = "btnApply", Text = "Apply", Location = new System.Drawing.Point(180, 33), Size = new System.Drawing.Size(90, 32), Cursor = Cursors.Hand };
            UIHelper.StyleButton(btnApply, "secondary");
            
            btnApply.Click += (s, e) =>
            {
                var c = couponBLL.GetCouponByCode(txtCoupon.Text.Trim());
                if (c != null && c.IsActive)
                {
                    appliedDiscountPercentage = c.DiscountPercentage;
                    appliedCouponCode = c.Code;
                    MessageBox.Show($"Coupon Applied: {c.DiscountPercentage}% off!", "Coupon Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlCoupon.BackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Light green
                    UpdateEstimatedCost();
                }
                else
                {
                    MessageBox.Show("Invalid or expired coupon.", "Coupon Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appliedDiscountPercentage = 0;
                    appliedCouponCode = "";
                    pnlCoupon.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
                    UpdateEstimatedCost();
                }
            };
            
            pnlCoupon.Controls.Add(lblCouponTitle);
            pnlCoupon.Controls.Add(txtCoupon);
            pnlCoupon.Controls.Add(btnApply);
            cardBooking.Controls.Add(pnlCoupon);
        }

        private async void frmMakeBooking_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnConfirmBooking, "primary");
            
            UIHelper.ApplyFocusBorder(pnlSearchWrapper, txtSearch);
            
            await LoadAvailableCarsAsync();

            if (preSelectedCar != null)
            {
                Card_OnSelectCar(this, preSelectedCar);
            }
        }

        private async System.Threading.Tasks.Task LoadAvailableCarsAsync()
        {
            try
            {
                availableCarsTable = await carBLL.GetAvailableCarsAsync();
                ComboBox cmbBrand = null;
                foreach(Control c in this.Controls) { if (c.Name == "cmbBrand" && c is ComboBox cb) { cmbBrand = cb; break; } }
                if (cmbBrand != null)
                {
                    cmbBrand.Items.Clear();
                    cmbBrand.Items.Add("All Brands");
                    foreach (DataRow r in availableCarsTable.Rows)
                    {
                        string b = r["Brand"].ToString();
                        if (!cmbBrand.Items.Contains(b)) cmbBrand.Items.Add(b);
                    }
                    cmbBrand.SelectedIndex = 0;
                }
                ApplyFilters();
                selectedCarId = 0;
                selectedCarRate = 0;
                cardBooking.Enabled = false;
                lblSelectedCar.Text = "Selected Car: None";
                UpdateEstimatedCost();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (availableCarsTable == null) return;
            string search = txtSearch.Text.Trim().ToLower();
            string filterStr = "";
            DataView dv = availableCarsTable.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                string safeSearch = search.Replace("'", "''");
                filterStr = $"(Brand LIKE '%{safeSearch}%' OR Model LIKE '%{safeSearch}%' OR PlateNumber LIKE '%{safeSearch}%')";
            }
            
            ComboBox cmbBrand = null;
            foreach(Control c in this.Controls) { if (c.Name == "cmbBrand" && c is ComboBox cb) { cmbBrand = cb; break; } }
            if (cmbBrand != null && cmbBrand.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(filterStr)) filterStr += " AND ";
                filterStr += $"Brand = '{cmbBrand.SelectedItem.ToString().Replace("'", "''")}'";
            }

            if (!string.IsNullOrEmpty(filterStr)) dv.RowFilter = filterStr;
            else dv.RowFilter = "1=1";

            ComboBox cmbSort = null;
            foreach (Control c in this.Controls) { if (c.Name == "cmbSort" && c is ComboBox cb) { cmbSort = cb; break; } }
            if (cmbSort != null)
            {
                if (cmbSort.SelectedIndex == 1) dv.Sort = "DailyRate ASC";
                else if (cmbSort.SelectedIndex == 2) dv.Sort = "DailyRate DESC";
                else dv.Sort = "";
            }

            flpCars.Controls.Clear();
            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                Car car = new Car
                {
                    CarID = Convert.ToInt32(row["CarID"]),
                    Brand = row["Brand"].ToString(),
                    Model = row["Model"].ToString(),
                    Year = Convert.ToInt32(row["Year"]),
                    Color = row["Color"].ToString(),
                    PlateNumber = row["PlateNumber"].ToString(),
                    DailyRate = Convert.ToDecimal(row["DailyRate"]),
                    ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : null
                };

                CarCard card = new CarCard(car);
                card.OnSelectCar += Card_OnSelectCar;
                card.OnCompareCar += Card_OnCompareCar;
                flpCars.Controls.Add(card);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
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

        private void Card_OnSelectCar(object sender, Car car)
        {
            selectedCarId = car.CarID;
            selectedCarRate = car.DailyRate;
            string carDetails = $"{car.Brand} {car.Model} ({car.PlateNumber})";
            
            lblSelectedCar.Text = $"Selected Car: {carDetails}";
            cardBooking.Enabled = true;
            UpdateEstimatedCost();
        }

        private void Card_OnCompareCar(object sender, Car car)
        {
            frmCarComparison compare = new frmCarComparison(this, car);
            compare.Show();
            this.Hide();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate.Value <= dtpPickupDate.Value)
            {
                dtpReturnDate.Value = dtpPickupDate.Value.AddDays(1);
            }
            UpdateEstimatedCost();
        }

        private void UpdateEstimatedCost()
        {
            if (selectedCarId > 0)
            {
                int days = (dtpReturnDate.Value.Date - dtpPickupDate.Value.Date).Days;
                if (days < 1) days = 1;
                decimal cost = days * selectedCarRate;
                decimal discountAmount = cost * (appliedDiscountPercentage / 100m);
                cost -= discountAmount;
                lblEstimatedCost.Text = $"Estimated Cost: BDT {cost:F2} " + (discountAmount > 0 ? $"(Saved: BDT {discountAmount:F2})" : "");
            }
            else
            {
                lblEstimatedCost.Text = "Estimated Cost: BDT 0.00";
            }
        }

        private async void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (selectedCarId == 0)
            {
                MessageBox.Show("Please select a car.");
                return;
            }

            try
            {
                DateTime pickup = dtpPickupDate.Value.Date;
                DateTime retDate = dtpReturnDate.Value.Date;

                int days = (retDate - pickup).Days;
                if (days < 1) days = 1;
                decimal cost = days * selectedCarRate;
                decimal discountAmount = cost * (appliedDiscountPercentage / 100m);
                cost -= discountAmount;

                string paymentMethod = "Not Selected";
                string bookingStatus = "Pending";
                
                RadioButton rdoCard = cardBooking.Controls["rdoCard"] as RadioButton;
                RadioButton rdoLate = cardBooking.Controls["rdoLate"] as RadioButton;

                if (rdoCard != null && rdoCard.Checked)
                {
                    paymentMethod = "Card (Full Payment)";
                    // Open Dummy Payment Gateway
                    frmPaymentGateway gateway = new frmPaymentGateway(cost);
                    if (gateway.ShowDialog() != DialogResult.OK)
                    {
                        return; // Payment cancelled
                    }
                    bookingStatus = "Active"; // Auto Approve
                }
                else if (rdoLate != null && rdoLate.Checked)
                {
                    paymentMethod = "Late Payment";
                    bookingStatus = "Pending";
                }

                if (bookingBLL.CreateBooking(SessionManager.CurrentUser.UserID, selectedCarId, pickup, retDate, bookingStatus, paymentMethod, appliedCouponCode, discountAmount))
                {
                    string msg = bookingStatus == "Active" 
                        ? "Booking confirmed and AUTO-APPROVED since full payment was made!" 
                        : "Booking submitted successfully! It is currently pending manager approval.";
                        
                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    appliedDiscountPercentage = 0; 
                    appliedCouponCode = "";
                    TextBox txtCoupon = (this.Controls["pnlCoupon"] as Panel)?.Controls["txtCoupon"] as TextBox;
                    if (txtCoupon != null) txtCoupon.Clear();
                    
                    await LoadAvailableCarsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to submit booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
