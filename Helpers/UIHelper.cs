using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    public static class UIHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        // Apply modern DataGridView styling — call this once per form on Load
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(248, 250, 252);  // #F8FAFC
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240);  // #E2E8F0
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Font = new Font("Segoe UI", 9F);

            // Column Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);  // #1E3A5F
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;

            // Default Row Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);  // #0F172A
            dgv.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254); // #DBEAFE
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 255); // #F0F7FF

            // Row Height
            dgv.RowTemplate.Height = 40;
        }

        // Apply status badge coloring to a cell
        public static void ApplyStatusColor(DataGridViewCellFormattingEventArgs e, string status)
        {
            switch (status)
            {
                case "Available":
                case "Active":
                case "Paid":
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);   // #16A34A green
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // #DCFCE7
                    break;
                case "Rented":
                case "Pending":
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);   // #D97706 amber
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // #FEF3C7
                    break;
                case "Maintenance":
                case "Cancelled":
                case "Unpaid":
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);   // #991B1B red
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // #FEE2E2
                    break;
                case "Completed":
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);   // #2563EB blue
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254); // #DBEAFE
                    break;
            }
        }

        // Style a button
        public static void StyleButton(Button btn, string type)
        {
            btn.Height = Math.Max(btn.Height, 38);
            btn.Padding = new Padding(10, 0, 10, 0);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.ForeColor = Color.White;

            Color baseColor = Color.White;

            switch (type.ToLower())
            {
                case "primary":
                    baseColor = Color.FromArgb(27, 58, 107); // #1B3A6B
                    break;
                case "accent":
                    baseColor = Color.FromArgb(37, 99, 235); // #2563EB
                    break;
                case "success":
                    baseColor = Color.FromArgb(22, 163, 74); // #16A34A
                    break;
                case "warning":
                    baseColor = Color.FromArgb(217, 119, 6); // #D97706
                    break;
                case "danger":
                    baseColor = Color.FromArgb(153, 27, 27); // #991B1B
                    break;
                case "neutral":
                    baseColor = Color.FromArgb(100, 116, 139); // #64748B
                    break;
            }

            btn.BackColor = baseColor;
            
            // Generate darker hover color (approx 15% darker)
            Color hoverColor = Color.FromArgb(
                Math.Max(0, baseColor.R - 38),
                Math.Max(0, baseColor.G - 38),
                Math.Max(0, baseColor.B - 38)
            );

            // Prevent duplicate event handlers (Q-4)
            if (btn.Tag == null || btn.Tag.ToString() != "HoverEnabled")
            {
                btn.MouseEnter += (s, e) => { btn.Tag = btn.BackColor; btn.BackColor = hoverColor; };
                btn.MouseLeave += (s, e) => { if (btn.Tag is Color old) btn.BackColor = old; };
                btn.Tag = "HoverEnabled";
            }
        }

        // Draw avatar circle with initials
        public static void DrawAvatar(Panel panel, string fullName)
        {
            // Q-1: Prevent duplicate Paint registration
            if (panel.Tag != null && panel.Tag.ToString() == "AvatarPainted") return;

            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(27, 58, 107))) // #1B3A6B
                {
                    e.Graphics.FillEllipse(brush, 0, 0, panel.Width, panel.Height);
                }

                string initials = "";
                if (!string.IsNullOrEmpty(fullName))
                {
                    var parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 0) initials += parts[0][0];
                    if (parts.Length > 1) initials += parts[1][0];
                }
                else
                {
                    initials = "U";
                }
                
                initials = initials.ToUpper();

                using (Font font = new Font("Segoe UI", 24F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(initials, font, textBrush, new Rectangle(0, 0, panel.Width, panel.Height), sf);
                }
            };
            panel.Tag = "AvatarPainted";
            panel.Invalidate();
        }

        // Apply border color on TextBox focus (using wrapper Panel)
        public static void ApplyFocusBorder(Panel wrapper, TextBox txt)
        {
            wrapper.BackColor = Color.FromArgb(226, 232, 240); // #E2E8F0
            wrapper.Padding = new Padding(1, 1, 1, 2);
            
            txt.BackColor = Color.White;
            txt.BorderStyle = BorderStyle.None;
            txt.Margin = new Padding(0);

            txt.Enter += (s, e) => { wrapper.BackColor = Color.FromArgb(37, 99, 235); txt.BackColor = Color.White; };
            txt.Leave += (s, e) => { wrapper.BackColor = Color.FromArgb(226, 232, 240); txt.BackColor = Color.White; };
        }

        // Format currency
        public static string FormatBDT(decimal amount) => $"BDT {amount:N2}";
        
        // Setup Form
        public static void SetupForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.FromArgb(248, 250, 252); // #F8FAFC
            form.Font = new Font("Segoe UI", 10F);
        }
    }
}
