namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmAISuggestions
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        // Input card
        private System.Windows.Forms.Panel cardInput;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtPreferences;
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.Label lblStatus;

        // AI response
        private System.Windows.Forms.RichTextBox rtbAiResponse;

        // Car grid (auto-shown after AI finishes)
        private System.Windows.Forms.DataGridView dgvSuggestions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.btnBack        = new System.Windows.Forms.Button();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblSubtitle    = new System.Windows.Forms.Label();
            this.cardInput      = new System.Windows.Forms.Panel();
            this.lblPrompt      = new System.Windows.Forms.Label();
            this.txtPreferences = new System.Windows.Forms.TextBox();
            this.btnSuggest     = new System.Windows.Forms.Button();
            this.lblStatus      = new System.Windows.Forms.Label();
            this.rtbAiResponse  = new System.Windows.Forms.RichTextBox();
            this.dgvSuggestions = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.cardInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestions)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(860, 72);

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
            this.lblTitle.Text = "🔍 AI Car Suggestions";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(132, 46);
            this.lblSubtitle.Text = "Powered by Ollama · qwen2.5:0.5b — knows your full fleet";

            // ── cardInput ─────────────────────────────────────────────────────
            this.cardInput.BackColor = System.Drawing.Color.White;
            this.cardInput.Controls.Add(this.lblPrompt);
            this.cardInput.Controls.Add(this.txtPreferences);
            this.cardInput.Controls.Add(this.btnSuggest);
            this.cardInput.Location = new System.Drawing.Point(20, 90);
            this.cardInput.Size = new System.Drawing.Size(820, 95);

            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblPrompt.Location = new System.Drawing.Point(15, 12);
            this.lblPrompt.Text = "What kind of car are you looking for?";

            this.txtPreferences.Location = new System.Drawing.Point(15, 38);
            this.txtPreferences.Size = new System.Drawing.Size(620, 42);
            this.txtPreferences.Multiline = true;
            this.txtPreferences.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPreferences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreferences.PlaceholderText = "e.g. a big SUV, something cheap, a black car for family trip...";

            this.btnSuggest.Location = new System.Drawing.Point(650, 35);
            this.btnSuggest.Size = new System.Drawing.Size(155, 48);
            this.btnSuggest.Text = "🔍 Ask AI";
            this.btnSuggest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSuggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuggest.FlatAppearance.BorderSize = 0;
            this.btnSuggest.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.btnSuggest.ForeColor = System.Drawing.Color.White;
            this.btnSuggest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);

            // ── lblStatus ─────────────────────────────────────────────────────
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatus.Location = new System.Drawing.Point(22, 196);
            this.lblStatus.Text = "Loading...";

            // ── rtbAiResponse ─────────────────────────────────────────────────
            // Streams AI text live — becomes visible as soon as AI starts responding
            this.rtbAiResponse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAiResponse.Location = new System.Drawing.Point(20, 216);
            this.rtbAiResponse.Size = new System.Drawing.Size(820, 160);
            this.rtbAiResponse.ReadOnly = true;
            this.rtbAiResponse.BackColor = System.Drawing.Color.FromArgb(240, 247, 255);
            this.rtbAiResponse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtbAiResponse.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.rtbAiResponse.WordWrap = true;
            this.rtbAiResponse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbAiResponse.Padding = new System.Windows.Forms.Padding(8);

            // ── dgvSuggestions ────────────────────────────────────────────────
            // Hidden initially — auto-shown after AI completes
            this.dgvSuggestions.Location = new System.Drawing.Point(20, 392);
            this.dgvSuggestions.Size = new System.Drawing.Size(820, 240);
            this.dgvSuggestions.AllowUserToAddRows = false;
            this.dgvSuggestions.ReadOnly = true;
            this.dgvSuggestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuggestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuggestions.Visible = false; // shown programmatically after AI done

            // ── frmAISuggestions ──────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(860, 648);
            this.Controls.Add(this.dgvSuggestions);
            this.Controls.Add(this.rtbAiResponse);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cardInput);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAISuggestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow — AI Car Suggestions";
            this.Load += new System.EventHandler(this.frmAISuggestions_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardInput.ResumeLayout(false);
            this.cardInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
