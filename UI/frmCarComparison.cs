using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmCarComparison : Form
    {
        private Form _parentForm;
        private CarBLL _carBLL = new CarBLL();
        private List<Car> _allCars = new List<Car>();
        private Car _initialCar;

        public frmCarComparison(Form parent, Car initialCar = null)
        {
            InitializeComponent();
            _parentForm = parent;
            _initialCar = initialCar;
        }

        private void frmCarComparison_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            
            LoadCars();
            
            if (_initialCar != null)
            {
                cmbCar1.SelectedValue = _initialCar.CarID;
            }
            
            // Style VS Badge (FIX 8.2)
            Panel pnlVs = new Panel();
            pnlVs.Size = new Size(50, 50);
            pnlVs.Location = new Point(375, 290);
            pnlVs.BackColor = Color.FromArgb(27, 58, 107);
            pnlVs.Paint += (senderPanel, ev) => 
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, pnlVs.Width, pnlVs.Height);
                pnlVs.Region = new Region(path);
            };
            
            lblVs.AutoSize = false;
            lblVs.Size = new Size(50, 50);
            lblVs.Location = new Point(0, 0);
            lblVs.TextAlign = ContentAlignment.MiddleCenter;
            lblVs.ForeColor = Color.White;
            lblVs.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            pnlVs.Controls.Add(lblVs);
            this.Controls.Add(pnlVs);
            pnlVs.BringToFront();
        }

        private void LoadCars()
        {
            DataTable dt = _carBLL.GetAvailableCars();
            _allCars.Clear();
            
            var dt1 = dt.Copy();
            var dt2 = dt.Copy();
            
            foreach (DataRow row in dt.Rows)
            {
                _allCars.Add(new Car
                {
                    CarID = Convert.ToInt32(row["CarID"]),
                    Brand = row["Brand"].ToString(),
                    Model = row["Model"].ToString(),
                    Year = Convert.ToInt32(row["Year"]),
                    Color = row["Color"].ToString(),
                    PlateNumber = row["PlateNumber"].ToString(),
                    DailyRate = Convert.ToDecimal(row["DailyRate"]),
                    ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : null
                });
            }

            // Bind combos
            dt1.Columns.Add("Display", typeof(string), "Brand + ' ' + Model");
            dt2.Columns.Add("Display", typeof(string), "Brand + ' ' + Model");
            
            cmbCar1.DataSource = dt1;
            cmbCar1.DisplayMember = "Display";
            cmbCar1.ValueMember = "CarID";
            cmbCar1.SelectedIndex = -1;
            
            cmbCar2.DataSource = dt2;
            cmbCar2.DisplayMember = "Display";
            cmbCar2.ValueMember = "CarID";
            cmbCar2.SelectedIndex = -1;
        }

        private void cmbCar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCar1.SelectedValue != null && int.TryParse(cmbCar1.SelectedValue.ToString(), out int id))
            {
                var car = _allCars.Find(c => c.CarID == id);
                UpdateCarCard(pnlCar1, car);
            }
            UpdateRateColors();
        }

        private void cmbCar2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCar2.SelectedValue != null && int.TryParse(cmbCar2.SelectedValue.ToString(), out int id))
            {
                var car = _allCars.Find(c => c.CarID == id);
                UpdateCarCard(pnlCar2, car);
            }
            UpdateRateColors();
        }

        private void UpdateCarCard(Panel pnl, Car car)
        {
            pnl.Controls.Clear();
            if (car == null) return;
            
            Panel picPanel = new Panel() { Dock = DockStyle.Top, Height = 150, BackColor = Color.FromArgb(226, 232, 240) };
            
            if (!string.IsNullOrEmpty(car.ImagePath) && System.IO.File.Exists(car.ImagePath))
            {
                // L-5: Load bytes into MemoryStream WITHOUT a using block.
                // Image.FromStream keeps a reference to the stream for lazy decoding;
                // disposing the stream before the image is rendered causes GDI+ errors.
                var stream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(car.ImagePath));
                PictureBox pic = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, Image = Image.FromStream(stream) };
                picPanel.Controls.Add(pic);
            }
            else
            {
                Label lblNoImg = new Label() { Text = "🚗 No Image Available", ForeColor = Color.FromArgb(148, 163, 184), Font = new Font("Segoe UI", 10, FontStyle.Italic), AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                picPanel.Controls.Add(lblNoImg);
            }
            
            Label lblBrand = new Label() { Text = $"Brand: {car.Brand}", Top = 160, Left = 10, AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            Label lblModel = new Label() { Text = $"Model: {car.Model}", Top = 190, Left = 10, AutoSize = true, Font = new Font("Segoe UI", 10) };
            Label lblYear = new Label() { Text = $"Year: {car.Year}", Top = 220, Left = 10, AutoSize = true, Font = new Font("Segoe UI", 10) };
            Label lblColor = new Label() { Text = $"Color: {car.Color}", Top = 250, Left = 10, AutoSize = true, Font = new Font("Segoe UI", 10) };
            Label lblRate = new Label() { Name = "lblRate", Text = $"Rate: BDT {car.DailyRate:F2}/day", Tag = car.DailyRate, Top = 280, Left = 10, AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(22, 163, 74) };
            
            Button btnBook = new Button() { Text = "✅ Book This Car", Top = 310, Left = 10, Width = 230, Height = 30, BackColor = Color.FromArgb(22, 163, 74), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            UIHelper.StyleButton(btnBook, "success");
            btnBook.Click += (s, e) => 
            {
                frmMakeBooking frmBook = new frmMakeBooking(_parentForm, car);
                frmBook.Show();
                this.Hide();
            };
            
            pnl.Controls.Add(btnBook);
            pnl.Controls.Add(lblRate);
            pnl.Controls.Add(lblColor);
            pnl.Controls.Add(lblYear);
            pnl.Controls.Add(lblModel);
            pnl.Controls.Add(lblBrand);
            pnl.Controls.Add(picPanel);
            
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.BackColor = Color.White;
        }

        private void UpdateRateColors()
        {
            if (pnlCar1.Controls.Count > 0 && pnlCar2.Controls.Count > 0)
            {
                Label rate1 = (Label)pnlCar1.Controls["lblRate"];
                Label rate2 = (Label)pnlCar2.Controls["lblRate"];

                if (rate1 != null && rate2 != null)
                {
                    decimal val1 = (decimal)rate1.Tag;
                    decimal val2 = (decimal)rate2.Tag;

                    if (val1 < val2)
                    {
                        rate1.ForeColor = Color.FromArgb(22, 163, 74); // Green
                        rate2.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                    }
                    else if (val2 < val1)
                    {
                        rate2.ForeColor = Color.FromArgb(22, 163, 74); // Green
                        rate1.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                    }
                    else
                    {
                        rate1.ForeColor = Color.FromArgb(22, 163, 74); // Both Green
                        rate2.ForeColor = Color.FromArgb(22, 163, 74);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_parentForm is frmCustomerHome custHome)
            {
                custHome.LoadDashboardData();
            }
            _parentForm.Show();
            this.Close();
        }
    }
}
