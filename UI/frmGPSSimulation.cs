using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public partial class frmGPSSimulation : Form
    {
        private Form parentForm;
        private CarBLL carBLL = new CarBLL();
        private GPSBLL gpsBLL = new GPSBLL();
        private Random rnd = new Random();
        
        private double currentLat = 23.8103;
        private double currentLng = 90.4125;
        private double currentSpeed = 0;
        private bool isTracking = false;
        private bool isOutOfBounds = false;
        
        // Geofence bounds (approx 1km area)
        private const double fenceLat = 23.8103;
        private const double fenceLng = 90.4125;
        private const double fenceRadius = 0.003; 

        public frmGPSSimulation(Form parent)
        {
            InitializeComponent();
            parentForm = parent;

            this.Load += frmGPSSimulation_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnToggleSim.Click += btnToggleSim_Click;
            this.simTimer.Tick += simTimer_Tick;
            this.pnlMap.Paint += pnlMap_Paint;
        }

        private void frmGPSSimulation_Load(object sender, EventArgs e)
        {
            UIHelper.SetupForm(this);
            UIHelper.StyleButton(btnBack, "neutral");
            UIHelper.StyleButton(btnToggleSim, "primary");
            
            LoadCars();
        }

        private void LoadCars()
        {
            DataTable dt = carBLL.GetAllCars();
            
            // Filter for Booked (Rented) cars only
            var rentedCars = dt.AsEnumerable().Where(r => r["Status"].ToString() == "Rented");
            DataTable filteredDt;
            if (rentedCars.Any())
                filteredDt = rentedCars.CopyToDataTable();
            else
                filteredDt = dt.Clone();

            // Ambiguity fix (Q-6)
            if (filteredDt.Columns.Contains("Brand") && filteredDt.Columns.Contains("Model") && filteredDt.Columns.Contains("PlateNumber"))
            {
                filteredDt.Columns.Add("CarDisplay", typeof(string), "Brand + ' ' + Model + ' [' + PlateNumber + ']'");
                cmbCars.DisplayMember = "CarDisplay";
            }
            else
            {
                cmbCars.DisplayMember = "Brand";
            }
            
            cmbCars.DataSource = filteredDt;
            cmbCars.ValueMember = "CarID";
            cmbCars.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            simTimer.Stop();
            parentForm.Show();
            this.Close();
        }

        private void btnToggleSim_Click(object sender, EventArgs e)
        {
            if (cmbCars.SelectedValue == null)
            {
                MessageBox.Show("Please select a car to track.");
                return;
            }

            isTracking = !isTracking;
            if (isTracking)
            {
                btnToggleSim.Text = "⏹ Stop Tracking";
                UIHelper.StyleButton(btnToggleSim, "danger");
                simTimer.Start();
            }
            else
            {
                btnToggleSim.Text = "▶ Start Tracking";
                UIHelper.StyleButton(btnToggleSim, "primary");
                simTimer.Stop();
            }
        }

        private void simTimer_Tick(object sender, EventArgs e)
        {
            // Simulate movement
            // Sometimes move faster to trigger out-of-bounds
            double drift = (rnd.NextDouble() - 0.5) * 0.0008;
            if (rnd.Next(1, 10) > 8) drift *= 5; // Occasional jump
            
            currentLat += drift;
            currentLng += (rnd.NextDouble() - 0.5) * 0.0008;
            currentSpeed = rnd.NextDouble() * 110; // 0-110 km/h

            // Check geofence
            isOutOfBounds = Math.Abs(currentLat - fenceLat) > fenceRadius || 
                            Math.Abs(currentLng - fenceLng) > fenceRadius;

            lblLat.Text = $"LAT: {currentLat:F7}°";
            lblLng.Text = $"LNG: {currentLng:F7}°";
            lblSpeed.Text = $"SPD: {currentSpeed:F1} km/h";
            
            if (isOutOfBounds)
            {
                lblLat.ForeColor = Color.Red;
                lblLng.ForeColor = Color.Red;
                lblSpeed.ForeColor = Color.Red;
            }
            else
            {
                lblLat.ForeColor = Color.Black;
                lblLng.ForeColor = Color.Black;
                lblSpeed.ForeColor = Color.Black;
            }

            // Save to DB
            int carId = (int)cmbCars.SelectedValue;
            gpsBLL.LogPosition(carId, (decimal)currentLat, (decimal)currentLng, (decimal)currentSpeed);

            pnlMap.Invalidate(); 
        }

        private void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw grid
            using (Pen gridPen = new Pen(Color.FromArgb(30, 41, 59), 1))
            {
                for (int i = 0; i < pnlMap.Width; i += 40) g.DrawLine(gridPen, i, 0, i, pnlMap.Height);
                for (int i = 0; i < pnlMap.Height; i += 40) g.DrawLine(gridPen, 0, i, pnlMap.Width, i);
            }

            if (isTracking)
            {
                // Draw Geofence Boundary
                using (Pen fencePen = new Pen(isOutOfBounds ? Color.Red : Color.FromArgb(100, 22, 163, 74), 2))
                {
                    fencePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    int fenceSize = 250;
                    g.DrawRectangle(fencePen, (pnlMap.Width - fenceSize) / 2, (pnlMap.Height - fenceSize) / 2, fenceSize, fenceSize);
                    
                    using (Font fenceFont = new Font("Segoe UI", 8, FontStyle.Italic))
                    {
                        g.DrawString("GEOFENCE AREA", fenceFont, Brushes.Gray, (pnlMap.Width - fenceSize) / 2, (pnlMap.Height - fenceSize) / 2 - 20);
                    }
                }

                // Calculate relative position based on center
                // 0.001 degree ~ 100 meters
                // Scale: 1 pixel = 1 meter approx? 
                // Let's just use a relative offset for visualization
                int centerX = pnlMap.Width / 2;
                int centerY = pnlMap.Height / 2;
                
                int offsetX = (int)((currentLng - fenceLng) * 50000); // Scale factor
                int offsetY = (int)((fenceLat - currentLat) * 50000);
                
                int x = centerX + offsetX;
                int y = centerY + offsetY;

                // Pulsing effect
                int pulseSize = 20 + (DateTime.Now.Millisecond / 50);
                Color blipColor = isOutOfBounds ? Color.Red : Color.LimeGreen;
                
                using (SolidBrush pulseBrush = new SolidBrush(Color.FromArgb(50, blipColor)))
                {
                    g.FillEllipse(pulseBrush, x - pulseSize/2, y - pulseSize/2, pulseSize, pulseSize);
                }
                
                using (SolidBrush dotBrush = new SolidBrush(blipColor))
                {
                    g.FillEllipse(dotBrush, x - 5, y - 5, 10, 10);
                }
                
                if (isOutOfBounds)
                {
                    using (Font warnFont = new Font("Segoe UI", 14, FontStyle.Bold))
                    {
                        g.DrawString("⚠️ OUT OF BOUNDS!", warnFont, Brushes.Red, 10, 10);
                    }
                }

                using (Font font = new Font("Consolas", 10, FontStyle.Bold))
                {
                    g.DrawString("LIVE", font, new SolidBrush(blipColor), x + 15, y - 10);
                }
            }
            else
            {
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("SELECT A CAR AND START TRACKING", font, Brushes.Gray,
                        new RectangleF(0, 0, pnlMap.Width, pnlMap.Height), sf);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            simTimer.Stop();
            simTimer.Dispose(); // L-4 Disposal
            base.OnFormClosed(e);
        }
    }
}
