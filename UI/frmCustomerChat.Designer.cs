namespace CAR_RENTAL_MANAGEMENT_SYSTEM.UI
{
    partial class frmCustomerChat
    {
        private System.ComponentModel.IContainer components = null;

        // ── Header ───────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblStatus;

        // ── Left sidebar (session list) ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarTop;
        private System.Windows.Forms.Label lblChatsTitle;
        private System.Windows.Forms.Button btnNewChat;
        private System.Windows.Forms.ListBox lstSessions;

        // ── Right panel (active chat) ────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlChatHeader;
        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.Panel pnlMessages;  // scrollable chat area
        private System.Windows.Forms.Panel pnlInputBar;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader     = new System.Windows.Forms.Panel();
            this.btnBack       = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblStatus     = new System.Windows.Forms.Label();

            this.pnlSidebar    = new System.Windows.Forms.Panel();
            this.pnlSidebarTop = new System.Windows.Forms.Panel();
            this.lblChatsTitle = new System.Windows.Forms.Label();
            this.btnNewChat    = new System.Windows.Forms.Button();
            this.lstSessions   = new System.Windows.Forms.ListBox();

            this.pnlRight      = new System.Windows.Forms.Panel();
            this.pnlChatHeader = new System.Windows.Forms.Panel();
            this.lblChatName   = new System.Windows.Forms.Label();
            this.pnlMessages   = new System.Windows.Forms.Panel();
            this.pnlInputBar   = new System.Windows.Forms.Panel();
            this.txtInput      = new System.Windows.Forms.TextBox();
            this.btnSend       = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarTop.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlChatHeader.SuspendLayout();
            this.pnlInputBar.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader (Dock Top, 65px) ────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 65;

            this.btnBack.Location = new System.Drawing.Point(12, 16);
            this.btnBack.Size = new System.Drawing.Size(90, 32);
            this.btnBack.Text = "← Back";
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnBack.FlatAppearance.BorderSize = 1;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(115, 10);
            this.lblHeaderTitle.Text = "🤖 DriveFlow AI Assistant";

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblStatus.Location = new System.Drawing.Point(117, 42);
            this.lblStatus.Text = "Connecting...";

            // ── pnlSidebar (Dock Left, 230px) ─────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlSidebar.Controls.Add(this.lstSessions);
            this.pnlSidebar.Controls.Add(this.pnlSidebarTop);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 230;

            this.pnlSidebarTop.BackColor = System.Drawing.Color.White;
            this.pnlSidebarTop.Controls.Add(this.lblChatsTitle);
            this.pnlSidebarTop.Controls.Add(this.btnNewChat);
            this.pnlSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebarTop.Height = 52;

            this.lblChatsTitle.AutoSize = true;
            this.lblChatsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChatsTitle.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblChatsTitle.Location = new System.Drawing.Point(14, 14);
            this.lblChatsTitle.Text = "💬 Chats";

            this.btnNewChat.Location = new System.Drawing.Point(153, 11);
            this.btnNewChat.Size = new System.Drawing.Size(65, 30);
            this.btnNewChat.Text = "+ New";
            this.btnNewChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewChat.FlatAppearance.BorderSize = 0;
            this.btnNewChat.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNewChat.ForeColor = System.Drawing.Color.White;
            this.btnNewChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewChat.Click += new System.EventHandler(this.btnNewChat_Click);

            this.lstSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSessions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstSessions.ItemHeight = 48;
            this.lstSessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSessions.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lstSessions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSessions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstSessions_DrawItem);
            this.lstSessions.SelectedIndexChanged += new System.EventHandler(this.lstSessions_SelectedIndexChanged);
            // Required for variable height
            this.lstSessions.MeasureItem += (s, e) => e.ItemHeight = 48;

            // ── pnlRight (Fill) ────────────────────────────────────────────────────
            this.pnlRight.Controls.Add(this.pnlMessages);
            this.pnlRight.Controls.Add(this.pnlInputBar);
            this.pnlRight.Controls.Add(this.pnlChatHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            // pnlChatHeader (Dock Top, 46px)
            this.pnlChatHeader.BackColor = System.Drawing.Color.White;
            this.pnlChatHeader.Controls.Add(this.lblChatName);
            this.pnlChatHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChatHeader.Height = 46;

            this.lblChatName.AutoSize = true;
            this.lblChatName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChatName.ForeColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.lblChatName.Location = new System.Drawing.Point(16, 13);
            this.lblChatName.Text = "Chat 1";

            // pnlInputBar (Dock Bottom, 78px)
            this.pnlInputBar.BackColor = System.Drawing.Color.White;
            this.pnlInputBar.Controls.Add(this.txtInput);
            this.pnlInputBar.Controls.Add(this.btnSend);
            this.pnlInputBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInputBar.Height = 78;
            this.pnlInputBar.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Size = new System.Drawing.Size(530, 54);
            this.txtInput.Multiline = true;
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.PlaceholderText = "Ask about cars, or say 'book a Toyota for next week'...  (Enter to send)";
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);

            this.btnSend.Location = new System.Drawing.Point(556, 12);
            this.btnSend.Size = new System.Drawing.Size(105, 54);
            this.btnSend.Text = "Send ➤";
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(27, 58, 107);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // pnlMessages (Fill — sits between Top and Bottom docked panels)
            this.pnlMessages.AutoScroll = true;
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessages.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlMessages.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);

            // ── frmCustomerChat ────────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1020, 680);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCustomerChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriveFlow — AI Car Assistant";
            this.Load += new System.EventHandler(this.frmCustomerChat_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarTop.ResumeLayout(false);
            this.pnlSidebarTop.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlChatHeader.ResumeLayout(false);
            this.pnlChatHeader.PerformLayout();
            this.pnlInputBar.ResumeLayout(false);
            this.pnlInputBar.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
