namespace BillingSystem
{
    partial class frmAuditLogs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblRecordCount = new Label();
            lblFrom = new Label();
            lblTo = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnSearch = new Button();
            dgvAuditLogs = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Audit Log Report";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecordCount.Location = new Point(730, 26);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(144, 18);
            lblRecordCount.TabIndex = 1;
            lblRecordCount.Text = "0 record(s)";
            lblRecordCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(26, 76);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(270, 76);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(23, 15);
            lblTo.TabIndex = 3;
            lblTo.Text = "To:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(75, 72);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(170, 23);
            dtpFrom.TabIndex = 4;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(305, 72);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(170, 23);
            dtpTo.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(495, 71);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 25);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.AllowUserToAddRows = false;
            dgvAuditLogs.AllowUserToDeleteRows = false;
            dgvAuditLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Location = new Point(24, 120);
            dgvAuditLogs.MultiSelect = false;
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.ReadOnly = true;
            dgvAuditLogs.RowHeadersVisible = false;
            dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLogs.Size = new Size(850, 360);
            dgvAuditLogs.TabIndex = 7;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(784, 510);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmAuditLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(btnClose);
            Controls.Add(dgvAuditLogs);
            Controls.Add(btnSearch);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblRecordCount);
            Controls.Add(lblTitle);
            MinimumSize = new Size(700, 450);
            Name = "frmAuditLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audit Log Report";
            Load += frmAuditLogs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblRecordCount;
        private Label lblFrom;
        private Label lblTo;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnSearch;
        private DataGridView dgvAuditLogs;
        private Button btnClose;
    }
}
