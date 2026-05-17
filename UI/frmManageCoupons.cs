using CAR_RENTAL_MANAGEMENT_SYSTEM.BLL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public class frmManageCoupons : Form
    {
        private Form parentForm;
        private DiscountCouponBLL couponBLL = new DiscountCouponBLL();
        private DataGridView dgvCoupons;
        private TextBox txtCode;
        private NumericUpDown numDiscount;

        public frmManageCoupons(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Manage Discount Coupons";
            this.Size = new Size(800, 540);
            this.StartPosition = FormStartPosition.CenterScreen;

            UIHelper.SetupForm(this);

            Label lblTitle = new Label { Text = "Manage Coupons", Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(20, 20), ForeColor = Color.FromArgb(15, 23, 42) };
            
            Button btnBack = new Button { Text = "Back", Location = new Point(680, 20), Size = new Size(80, 30), Cursor = Cursors.Hand };
            UIHelper.StyleButton(btnBack, "neutral");
            btnBack.Click += (s, e) => { parentForm.Show(); this.Close(); };

            Panel pnlCreate = new Panel { Location = new Point(20, 60), Size = new Size(740, 80), BackColor = Color.White };
            
            Label lblCode = new Label { Text = "Coupon Code:", Location = new Point(20, 27), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            txtCode = new TextBox { Location = new Point(135, 24), Width = 160, Font = new Font("Segoe UI", 10) };
            
            Label lblDiscount = new Label { Text = "Discount (%):", Location = new Point(320, 27), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            numDiscount = new NumericUpDown { Location = new Point(435, 24), Width = 90, Minimum = 1, Maximum = 100, Font = new Font("Segoe UI", 10) };

            Button btnCreate = new Button { Text = "Create Coupon", Location = new Point(555, 22), Size = new Size(160, 32), Cursor = Cursors.Hand };
            UIHelper.StyleButton(btnCreate, "primary");
            btnCreate.Click += BtnCreate_Click;

            pnlCreate.Controls.Add(lblCode);
            pnlCreate.Controls.Add(txtCode);
            pnlCreate.Controls.Add(lblDiscount);
            pnlCreate.Controls.Add(numDiscount);
            pnlCreate.Controls.Add(btnCreate);

            dgvCoupons = new DataGridView
            {
                Location = new Point(20, 160),
                Size = new Size(740, 270),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            UIHelper.StyleDataGridView(dgvCoupons);

            Button btnToggle = new Button { Text = "Toggle Active Status", Location = new Point(20, 445), Size = new Size(200, 32), Cursor = Cursors.Hand };
            UIHelper.StyleButton(btnToggle, "secondary");
            btnToggle.Click += BtnToggle_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnBack);
            this.Controls.Add(pnlCreate);
            this.Controls.Add(dgvCoupons);
            this.Controls.Add(btnToggle);

            this.Load += (s, e) => LoadCoupons();
        }

        private void LoadCoupons()
        {
            dgvCoupons.DataSource = couponBLL.GetAllCoupons();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var coupon = new DiscountCoupon
                {
                    Code = txtCode.Text.Trim(),
                    DiscountPercentage = numDiscount.Value,
                    IsActive = true
                };
                if (couponBLL.CreateCoupon(coupon))
                {
                    MessageBox.Show("Coupon created successfully.");
                    txtCode.Clear();
                    LoadCoupons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            if (dgvCoupons.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCoupons.SelectedRows[0].Cells["CouponID"].Value);
                bool isActive = Convert.ToBoolean(dgvCoupons.SelectedRows[0].Cells["IsActive"].Value);
                couponBLL.ToggleCouponStatus(id, !isActive);
                LoadCoupons();
            }
        }
    }
}
