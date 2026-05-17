using CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    public class frmPaymentGateway : Form
    {
        private decimal amountToPay;

        public frmPaymentGateway(decimal amount)
        {
            this.amountToPay = amount;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Secure Payment Gateway";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            UIHelper.SetupForm(this);

            Label lblTitle = new Label { Text = "Payment Details", Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(20, 20), ForeColor = Color.FromArgb(15, 23, 42) };
            Label lblAmount = new Label { Text = $"Amount to Pay: BDT {amountToPay:N2}", Font = new Font("Segoe UI", 12, FontStyle.Regular), AutoSize = true, Location = new Point(20, 60), ForeColor = Color.FromArgb(22, 163, 74) };

            Label lblCard = new Label { Text = "Card Number", Location = new Point(20, 100), AutoSize = true, Font = new Font("Segoe UI", 9) };
            Panel pnlCard = new Panel { Location = new Point(20, 120), Width = 340, Height = 25 };
            TextBox txtCard = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            pnlCard.Controls.Add(txtCard);
            UIHelper.ApplyFocusBorder(pnlCard, txtCard);

            Label lblExp = new Label { Text = "Expiry Date (MM/YY)", Location = new Point(20, 160), AutoSize = true, Font = new Font("Segoe UI", 9) };
            Panel pnlExp = new Panel { Location = new Point(20, 180), Width = 160, Height = 25 };
            TextBox txtExp = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            pnlExp.Controls.Add(txtExp);
            UIHelper.ApplyFocusBorder(pnlExp, txtExp);

            Label lblCvv = new Label { Text = "CVV", Location = new Point(200, 160), AutoSize = true, Font = new Font("Segoe UI", 9) };
            Panel pnlCvv = new Panel { Location = new Point(200, 180), Width = 160, Height = 25 };
            TextBox txtCvv = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10), PasswordChar = '*' };
            pnlCvv.Controls.Add(txtCvv);
            UIHelper.ApplyFocusBorder(pnlCvv, txtCvv);

            Button btnPay = new Button { Text = "Pay Securely", Location = new Point(20, 230), Size = new Size(340, 40) };
            UIHelper.StyleButton(btnPay, "primary");
            btnPay.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCard.Text) || string.IsNullOrWhiteSpace(txtExp.Text) || string.IsNullOrWhiteSpace(txtCvv.Text))
                {
                    MessageBox.Show("Please enter all card details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Payment Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblAmount);
            this.Controls.Add(lblCard);
            this.Controls.Add(pnlCard);
            this.Controls.Add(lblExp);
            this.Controls.Add(pnlExp);
            this.Controls.Add(lblCvv);
            this.Controls.Add(pnlCvv);
            this.Controls.Add(btnPay);
        }
    }
}
