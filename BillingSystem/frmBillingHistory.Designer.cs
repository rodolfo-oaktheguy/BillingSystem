namespace BillingSystem
{
    partial class frmBillingHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCustomerName = new Label();
            dgvBilling = new DataGridView();
            BillingMonth = new DataGridViewTextBoxColumn();
            PreviousReading = new DataGridViewTextBoxColumn();
            PresentReading = new DataGridViewTextBoxColumn();
            Consumption = new DataGridViewTextBoxColumn();
            RatePerCubic = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
            SuspendLayout();
            //
            // lblCustomerName
            //
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCustomerName.Location = new Point(12, 12);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(146, 25);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Billing History";
            //
            // dgvBilling
            //
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AllowUserToDeleteRows = false;
            dgvBilling.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBilling.AutoGenerateColumns = false;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBilling.Columns.AddRange(new DataGridViewColumn[] { BillingMonth, PreviousReading, PresentReading, Consumption, RatePerCubic, TotalAmount, Status });
            dgvBilling.Location = new Point(12, 50);
            dgvBilling.MultiSelect = false;
            dgvBilling.Name = "dgvBilling";
            dgvBilling.ReadOnly = true;
            dgvBilling.RowHeadersVisible = false;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.Size = new Size(736, 300);
            dgvBilling.TabIndex = 1;
            //
            // BillingMonth
            //
            BillingMonth.DataPropertyName = "BillingMonth";
            BillingMonth.HeaderText = "Billing Month";
            BillingMonth.Name = "BillingMonth";
            BillingMonth.ReadOnly = true;
            //
            // PreviousReading
            //
            PreviousReading.DataPropertyName = "PreviousReading";
            PreviousReading.HeaderText = "Previous Reading";
            PreviousReading.Name = "PreviousReading";
            PreviousReading.ReadOnly = true;
            //
            // PresentReading
            //
            PresentReading.DataPropertyName = "PresentReading";
            PresentReading.HeaderText = "Present Reading";
            PresentReading.Name = "PresentReading";
            PresentReading.ReadOnly = true;
            //
            // Consumption
            //
            Consumption.DataPropertyName = "Consumption";
            Consumption.HeaderText = "Consumption";
            Consumption.Name = "Consumption";
            Consumption.ReadOnly = true;
            //
            // RatePerCubic
            //
            RatePerCubic.DataPropertyName = "RatePerCubic";
            RatePerCubic.DefaultCellStyle.Format = "N2";
            RatePerCubic.HeaderText = "Rate Per Cubic";
            RatePerCubic.Name = "RatePerCubic";
            RatePerCubic.ReadOnly = true;
            //
            // TotalAmount
            //
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.DefaultCellStyle.Format = "N2";
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.Name = "TotalAmount";
            TotalAmount.ReadOnly = true;
            //
            // Status
            //
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(658, 362);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            //
            // frmBillingHistory
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(760, 402);
            Controls.Add(btnClose);
            Controls.Add(dgvBilling);
            Controls.Add(lblCustomerName);
            MinimizeBox = false;
            Name = "frmBillingHistory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing System - Billing History";
            Load += frmBillingHistory_Load;
            Shown += frmBillingHistory_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerName;
        private DataGridView dgvBilling;
        private DataGridViewTextBoxColumn BillingMonth;
        private DataGridViewTextBoxColumn PreviousReading;
        private DataGridViewTextBoxColumn PresentReading;
        private DataGridViewTextBoxColumn Consumption;
        private DataGridViewTextBoxColumn RatePerCubic;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn Status;
        private Button btnClose;
    }
}
