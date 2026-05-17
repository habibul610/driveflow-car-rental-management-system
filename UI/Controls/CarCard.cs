using System;
using System.Drawing;
using System.Windows.Forms;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI.Controls
{
    public partial class CarCard : UserControl
    {
        private Car _car;
        
        public event EventHandler<Car> OnSelectCar;
        public event EventHandler<Car> OnCompareCar;

        public CarCard(Car car)
        {
            InitializeComponent();
            _car = car;
            LoadCarData();
            ApplyStyling();
        }

        private void LoadCarData()
        {
            lblBrandModel.Text = $"{_car.Brand} {_car.Model}";
            lblYear.Text = $"Year: {_car.Year}";
            lblRate.Text = $"BDT {_car.DailyRate:F2} / day";
            
            // Handle Image loading
            string imgPath = _car.ImagePath;
            if (!string.IsNullOrEmpty(imgPath))
            {
                // Try absolute or current relative path
                if (!System.IO.File.Exists(imgPath))
                {
                    // Try relative to app base
                    imgPath = System.IO.Path.Combine(Application.StartupPath, imgPath);
                }

                if (System.IO.File.Exists(imgPath))
                {
                    try
                    {
                        // Use Image.FromFile — it handles its own buffering safely.
                        // Using a FileStream with Image.FromStream causes GDI+ errors
                        // because the stream is needed for the image lifetime, not just load.
                        picCar.Image = Image.FromFile(imgPath);
                    }
                    catch
                    {
                        picCar.BackColor = Color.LightGray;
                    }
                }
                else
                {
                    SetNoImage();
                }
            }
            else
            {
                SetNoImage();
            }
        }

        private void SetNoImage()
        {
            picCar.BackColor = Color.FromArgb(226, 232, 240);
            Label lblNoImage = new Label()
            {
                Text = "No Image",
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent
            };
            picCar.Controls.Add(lblNoImage);
        }

        private void ApplyStyling()
        {
            this.BackColor = Color.White;
            // A subtle border effect is applied by putting it in a panel or drawing
            UIHelper.StyleButton(btnSelect, "primary");
            UIHelper.StyleButton(btnCompare, "neutral");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OnSelectCar?.Invoke(this, _car);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            OnCompareCar?.Invoke(this, _car);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw a subtle border
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, 
                Color.FromArgb(226, 232, 240), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(226, 232, 240), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(226, 232, 240), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(226, 232, 240), 1, ButtonBorderStyle.Solid);
        }
    }
}
