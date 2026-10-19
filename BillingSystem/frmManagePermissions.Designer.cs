namespace BillingSystem
{
    partial class frmManagePermissions
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
            lblRole = new Label();
            cmbRole = new ComboBox();
            grpPermissions = new GroupBox();
            chkAddCustomer = new CheckBox();
            chkEditCustomer = new CheckBox();
            chkDeleteCustomer = new CheckBox();
            chkAnalytics = new CheckBox();
            chkExportExcel = new CheckBox();
            chkExportPdf = new CheckBox();
            chkAuditLogs = new CheckBox();
            btnSave = new Button();
            btnClose = new Button();
            grpPermissions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(394, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Permissions";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(25, 59);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(68, 15);
            lblRole.TabIndex = 1;
            lblRole.Text = "Select Role:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Cashier" });
            cmbRole.Location = new Point(105, 55);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(180, 23);
            cmbRole.TabIndex = 2;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // grpPermissions
            // 
            grpPermissions.Controls.Add(chkAuditLogs);
            grpPermissions.Controls.Add(chkExportPdf);
            grpPermissions.Controls.Add(chkExportExcel);
            grpPermissions.Controls.Add(chkAnalytics);
            grpPermissions.Controls.Add(chkDeleteCustomer);
            grpPermissions.Controls.Add(chkEditCustomer);
            grpPermissions.Controls.Add(chkAddCustomer);
            grpPermissions.Location = new Point(25, 95);
            grpPermissions.Name = "grpPermissions";
            grpPermissions.Size = new Size(389, 278);
            grpPermissions.TabIndex = 3;
            grpPermissions.TabStop = false;
            grpPermissions.Text = "Permissions";
            // 
            // chkAddCustomer
            // 
            chkAddCustomer.AutoSize = true;
            chkAddCustomer.Location = new Point(24, 30);
            chkAddCustomer.Name = "chkAddCustomer";
            chkAddCustomer.Size = new Size(96, 19);
            chkAddCustomer.TabIndex = 0;
            chkAddCustomer.Text = "Add Customer";
            chkAddCustomer.UseVisualStyleBackColor = true;
            // 
            // chkEditCustomer
            // 
            chkEditCustomer.AutoSize = true;
            chkEditCustomer.Location = new Point(24, 61);
            chkEditCustomer.Name = "chkEditCustomer";
            chkEditCustomer.Size = new Size(96, 19);
            chkEditCustomer.TabIndex = 1;
            chkEditCustomer.Text = "Edit Customer";
            chkEditCustomer.UseVisualStyleBackColor = true;
            // 
            // chkDeleteCustomer
            // 
            chkDeleteCustomer.AutoSize = true;
            chkDeleteCustomer.Location = new Point(24, 92);
            chkDeleteCustomer.Name = "chkDeleteCustomer";
            chkDeleteCustomer.Size = new Size(109, 19);
            chkDeleteCustomer.TabIndex = 2;
            chkDeleteCustomer.Text = "Delete Customer";
            chkDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // chkAnalytics
            // 
            chkAnalytics.AutoSize = true;
            chkAnalytics.Location = new Point(24, 123);
            chkAnalytics.Name = "chkAnalytics";
            chkAnalytics.Size = new Size(74, 19);
            chkAnalytics.TabIndex = 3;
            chkAnalytics.Text = "Analytics";
            chkAnalytics.UseVisualStyleBackColor = true;
            // 
            // chkExportExcel
            // 
            chkExportExcel.AutoSize = true;
            chkExportExcel.Location = new Point(24, 154);
            chkExportExcel.Name = "chkExportExcel";
            chkExportExcel.Size = new Size(108, 19);
            chkExportExcel.TabIndex = 4;
            chkExportExcel.Text = "Export to Excel";
            chkExportExcel.UseVisualStyleBackColor = true;
            // 
            // chkExportPdf
            // 
            chkExportPdf.AutoSize = true;
            chkExportPdf.Location = new Point(24, 185);
            chkExportPdf.Name = "chkExportPdf";
            chkExportPdf.Size = new Size(98, 19);
            chkExportPdf.TabIndex = 5;
            chkExportPdf.Text = "Export to PDF";
            chkExportPdf.UseVisualStyleBackColor = true;
            // 
            // chkAuditLogs
            // 
            chkAuditLogs.AutoSize = true;
            chkAuditLogs.Location = new Point(24, 216);
            chkAuditLogs.Name = "chkAuditLogs";
            chkAuditLogs.Size = new Size(83, 19);
            chkAuditLogs.TabIndex = 6;
            chkAuditLogs.Text = "Audit Logs";
            chkAuditLogs.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(105, 390);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save Permissions";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(255, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 30);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmManagePermissions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 460);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(grpPermissions);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmManagePermissions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Permissions";
            Load += frmManagePermissions_Load;
            grpPermissions.ResumeLayout(false);
            grpPermissions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblRole;
        private ComboBox cmbRole;
        private GroupBox grpPermissions;
        private CheckBox chkAddCustomer;
        private CheckBox chkEditCustomer;
        private CheckBox chkDeleteCustomer;
        private CheckBox chkAnalytics;
        private CheckBox chkExportExcel;
        private CheckBox chkExportPdf;
        private CheckBox chkAuditLogs;
        private Button btnSave;
        private Button btnClose;
    }
}
