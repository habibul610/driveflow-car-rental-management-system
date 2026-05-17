namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmAIInsights
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel cardContent;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox rtbInsights;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader  = new System.Windows.Forms.Panel();
            this.btnBack    = new System.Windows.Forms.Button();
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.cardContent = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rtbInsights = new System.Windows.Forms.RichTextBox();

            this.pnlHeader.SuspendLayout();
            this.cardContent.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(820, 70);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Size = new System.Drawing.Size(90, 32);
            this.btnBack.Text = "← Back";
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnBack.FlatAppearance.BorderSize = 1;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(130, 12);
            this.lblTitle.Text = "✨ AI Business Insights";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(132, 46);
            this.lblSubtitle.Text = "Powered by Ollama · qwen2.5:0.5b";

            // ── cardContent ───────────────────────────────────────────────────
            this.cardContent.BackColor = System.Drawing.Color.White;
            this.cardContent.Controls.Add(this.btnGenerate);
            this.cardContent.Controls.Add(this.rtbInsights);
            this.cardContent.Location = new System.Drawing.Point(20, 90);
            this.cardContent.Size = new System.Drawing.Size(780, 530);
            this.cardContent.Padding = new System.Windows.Forms.Padding(10);

            // btnGenerate
            this.btnGenerate.Location = new System.Drawing.Point(20, 16);
            this.btnGenerate.Size = new System.Drawing.Size(220, 42);
            this.btnGenerate.Text = "✨ Generate Insights";
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // rtbInsights
            this.rtbInsights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInsights.Location = new System.Drawing.Point(20, 75);
            this.rtbInsights.Size = new System.Drawing.Size(740, 440);
            this.rtbInsights.ReadOnly = true;
            this.rtbInsights.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.rtbInsights.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbInsights.WordWrap = true;

            // ── frmAIInsights ─────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(820, 640);
            this.Controls.Add(this.cardContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAIInsights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow — AI Business Insights";
            this.Load += new System.EventHandler(this.frmAIInsights_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
