namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmAdminChat
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        // Chat area
        private System.Windows.Forms.RichTextBox rtbChat;

        // Divider
        private System.Windows.Forms.Panel pnlInputArea;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.btnBack     = new System.Windows.Forms.Button();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.rtbChat     = new System.Windows.Forms.RichTextBox();
            this.pnlInputArea = new System.Windows.Forms.Panel();
            this.txtInput    = new System.Windows.Forms.TextBox();
            this.btnSend     = new System.Windows.Forms.Button();
            this.btnClear    = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlInputArea.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(820, 72);

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

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(130, 10);
            this.lblTitle.Text = "💬 AI Business Chat";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(132, 46);
            this.lblSubtitle.Text = "Powered by Ollama · qwen2.5:0.5b — loaded with your live fleet & revenue data";

            // ── rtbChat ───────────────────────────────────────────────────────
            this.rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.ReadOnly = true;
            this.rtbChat.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.WordWrap = true;
            this.rtbChat.Padding = new System.Windows.Forms.Padding(12);

            // ── pnlInputArea ─────────────────────────────────────────────────
            this.pnlInputArea.BackColor = System.Drawing.Color.White;
            this.pnlInputArea.Controls.Add(this.txtInput);
            this.pnlInputArea.Controls.Add(this.btnSend);
            this.pnlInputArea.Controls.Add(this.btnClear);
            this.pnlInputArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInputArea.Height = 80;
            this.pnlInputArea.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            this.txtInput.Location = new System.Drawing.Point(12, 14);
            this.txtInput.Size = new System.Drawing.Size(550, 52);
            this.txtInput.Multiline = true;
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.PlaceholderText = "Ask anything about your business... (Enter to send, Shift+Enter for new line)";
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);

            this.btnSend.Location = new System.Drawing.Point(575, 14);
            this.btnSend.Size = new System.Drawing.Size(120, 52);
            this.btnSend.Text = "Send ➤";
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.btnClear.Location = new System.Drawing.Point(708, 14);
            this.btnClear.Size = new System.Drawing.Size(100, 52);
            this.btnClear.Text = "🗑 Clear";
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 1;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── frmAdminChat ──────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(820, 660);
            this.Controls.Add(this.rtbChat);     // Fill — sits between top and bottom
            this.Controls.Add(this.pnlInputArea); // Bottom
            this.Controls.Add(this.pnlHeader);   // Top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdminChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow — AI Business Chat";
            this.Load += new System.EventHandler(this.frmAdminChat_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInputArea.ResumeLayout(false);
            this.pnlInputArea.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
