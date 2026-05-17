using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmManageCars : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private int selectedCarId = 0;
        private DataTable allCarsTable;

        public frmManageCars(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmManageCars_Load(object sender, EventArgs e)
        {
            // Apply modern UI styling
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnAdd, "success");
            UIHelper.StyleButton(btnUpdate, "warning");
            UIHelper.StyleButton(btnDelete, "danger");
            UIHelper.StyleButton(btnClear, "neutral");
            
            UIHelper.ApplyFocusBorder(pnlBrandWrapper, txtBrand);
            UIHelper.ApplyFocusBorder(pnlModelWrapper, txtModel);
            UIHelper.ApplyFocusBorder(pnlYearWrapper, txtYear);
            UIHelper.ApplyFocusBorder(pnlColorWrapper, txtColor);
            UIHelper.ApplyFocusBorder(pnlPlateWrapper, txtPlateNumber);
            UIHelper.ApplyFocusBorder(pnlRateWrapper, txtDailyRate);
            UIHelper.ApplyFocusBorder(pnlSearchWrapper, txtSearch);

            UIHelper.StyleDataGridView(dgvCars);
            dgvCars.CellFormatting += (s, ev) => 
            {
                if (dgvCars.Columns[ev.ColumnIndex].Name == "Status" && ev.Value != null)
                {
                    UIHelper.ApplyStatusColor(ev, ev.Value.ToString());
                }
            };
            
            LoadCars();
        }

        private void LoadCars()
        {
            try
            {
                allCarsTable = carBLL.GetAllCars();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (allCarsTable == null) return;
            
            string search = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString();

            DataView dv = allCarsTable.DefaultView;
            string filter = "1=1";

            // Only apply status filter if a specific status (not null and not "All") is selected
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                filter += $" AND Status = '{statusFilter}'";
            }

            if (!string.IsNullOrEmpty(search))
            {
                string safeSearch = search.Replace("'", "''");
                filter += $" AND (Brand LIKE '%{safeSearch}%' OR Model LIKE '%{safeSearch}%' OR PlateNumber LIKE '%{safeSearch}%')";
            }

            dv.RowFilter = filter;
            dgvCars.DataSource = dv;
            
            if (dgvCars.Columns.Contains("ImagePath"))
            {
                dgvCars.Columns["ImagePath"].Visible = false;
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

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];
                selectedCarId = Convert.ToInt32(row.Cells["CarID"].Value);
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtYear.Text = row.Cells["Year"].Value.ToString();
                txtColor.Text = row.Cells["Color"].Value.ToString();
                txtPlateNumber.Text = row.Cells["PlateNumber"].Value.ToString();
                txtDailyRate.Text = row.Cells["DailyRate"].Value.ToString();
                
                // L-8: Robust selection to handle case mismatch or string assignment issues
                string status = row.Cells["Status"].Value.ToString();
                int index = cmbStatus.FindStringExact(status);
                if (index != -1) cmbStatus.SelectedIndex = index;
                else cmbStatus.Text = status;
                
                txtImagePath.Text = row.Cells["ImagePath"]?.Value?.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedCarId = 0;
            txtBrand.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtColor.Clear();
            txtPlateNumber.Clear();
            txtDailyRate.Clear();
            txtImagePath.Clear();
            cmbStatus.SelectedIndex = 0;
            dgvCars.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out int year, out decimal rate))
            {
                Car car = new Car
                {
                    Brand = txtBrand.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = year,
                    Color = txtColor.Text.Trim(),
                    PlateNumber = txtPlateNumber.Text.Trim(),
                    DailyRate = rate,
                    Status = cmbStatus.SelectedItem.ToString(),
                    ImagePath = txtImagePath.Text.Trim()
                };

                if (carBLL.InsertCar(car))
                {
                    MessageBox.Show("Car added successfully!");
                    LoadCars();
                    btnClear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to add car. Plate number must be unique.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCarId == 0)
            {
                MessageBox.Show("Please select a car from the list to update.");
                return;
            }

            Car existingCar = carBLL.GetCarByID(selectedCarId);
            if (existingCar != null && existingCar.Status == "Rented" && txtPlateNumber.Text.Trim() != existingCar.PlateNumber)
            {
                MessageBox.Show("Cannot change plate number of a rented car.");
                return;
            }

            if (ValidateInputs(out int year, out decimal rate))
            {
                Car car = new Car
                {
                    CarID = selectedCarId,
                    Brand = txtBrand.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = year,
                    Color = txtColor.Text.Trim(),
                    PlateNumber = txtPlateNumber.Text.Trim(),
                    DailyRate = rate,
                    Status = cmbStatus.SelectedItem.ToString(),
                    ImagePath = txtImagePath.Text.Trim()
                };

                if (carBLL.UpdateCar(car))
                {
                    MessageBox.Show("Car updated successfully!");
                    LoadCars();
                    btnClear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to update car.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCarId == 0)
            {
                MessageBox.Show("Please select a car from the list to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this car?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (carBLL.DeleteCar(selectedCarId))
                    {
                        MessageBox.Show("Car deleted successfully!");
                        LoadCars();
                        btnClear_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete car.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs(out int year, out decimal rate)
        {
            year = 0;
            rate = 0;

            if (string.IsNullOrWhiteSpace(txtBrand.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text) ||
                string.IsNullOrWhiteSpace(txtPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(txtDailyRate.Text))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }

            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Year must be a valid number.");
                return false;
            }

            int currentYear = DateTime.Now.Year;
            if (year < 1886 || year > currentYear + 1)
            {
                MessageBox.Show($"Year must be between 1886 and {currentYear + 1}.");
                return false;
            }

            if (!decimal.TryParse(txtDailyRate.Text, out rate))
            {
                MessageBox.Show("Daily rate must be a valid number.");
                return false;
            }

            if (rate <= 0)
            {
                MessageBox.Show("Daily rate must be greater than 0.");
                return false;
            }

            return true;
        }
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Select Car Image";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = System.IO.Path.GetFileName(ofd.FileName);
                        string targetDir = System.IO.Path.Combine(Application.StartupPath, "images");
                        if (!System.IO.Directory.Exists(targetDir)) System.IO.Directory.CreateDirectory(targetDir);
                        
                        string targetPath = System.IO.Path.Combine(targetDir, fileName);
                        if (ofd.FileName != targetPath)
                        {
                            System.IO.File.Copy(ofd.FileName, targetPath, true);
                        }
                        
                        // Store relative path (Q-5)
                        txtImagePath.Text = "images/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying image: " + ex.Message);
                        txtImagePath.Text = ofd.FileName; // Fallback
                    }
                }
            }
        }
    }
}
