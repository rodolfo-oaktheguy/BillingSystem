namespace BillingSystem
{
    partial class frmAnalytics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlKpiCustomers = new Panel();
            lblKpiCustomersValue = new Label();
            lblTotalCustomers = new Label();
            pnlKpiRevenue = new Panel();
            lblKpiRevenueValue = new Label();
            lblTotalRevenue = new Label();
            pnlKpiUnpaid = new Panel();
            lblKpiUnpaidValue = new Label();
            lblTotalUnpaid = new Label();
            plotMonthlyRevenue = new ScottPlot.WinForms.FormsPlot();
            plotPaidUnpaid = new ScottPlot.WinForms.FormsPlot();
            lblTop5Title = new Label();
            dgvTop5 = new DataGridView();
            btnCloseAnalytics = new Button();
            pnlKpiCustomers.SuspendLayout();
            pnlKpiRevenue.SuspendLayout();
            pnlKpiUnpaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTitle.Location = new Point(200, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Analytics Dashboard";
            // 
            // pnlKpiCustomers
            // 
            pnlKpiCustomers.BackColor = Color.FromArgb(240, 248, 255);
            pnlKpiCustomers.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiCustomers.Controls.Add(lblKpiCustomersValue);
            pnlKpiCustomers.Controls.Add(lblTotalCustomers);
            pnlKpiCustomers.Location = new Point(40, 60);
            pnlKpiCustomers.Name = "pnlKpiCustomers";
            pnlKpiCustomers.Size = new Size(260, 90);
            pnlKpiCustomers.TabIndex = 11;
            // 
            // lblKpiCustomersValue
            // 
            lblKpiCustomersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblKpiCustomersValue.Location = new Point(15, 10);
            lblKpiCustomersValue.Name = "lblKpiCustomersValue";
            lblKpiCustomersValue.Size = new Size(230, 40);
            lblKpiCustomersValue.TabIndex = 0;
            lblKpiCustomersValue.Text = "0";
            lblKpiCustomersValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 9F);
            lblTotalCustomers.Location = new Point(80, 50);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(93, 15);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "Total Customers";
            // 
            // pnlKpiRevenue
            // 
            pnlKpiRevenue.BackColor = Color.FromArgb(255, 250, 240);
            pnlKpiRevenue.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiRevenue.Controls.Add(lblKpiRevenueValue);
            pnlKpiRevenue.Controls.Add(lblTotalRevenue);
            pnlKpiRevenue.Location = new Point(360, 60);
            pnlKpiRevenue.Name = "pnlKpiRevenue";
            pnlKpiRevenue.Size = new Size(260, 90);
            pnlKpiRevenue.TabIndex = 10;
            // 
            // lblKpiRevenueValue
            // 
            lblKpiRevenueValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKpiRevenueValue.Location = new Point(15, 10);
            lblKpiRevenueValue.Name = "lblKpiRevenueValue";
            lblKpiRevenueValue.Size = new Size(230, 40);
            lblKpiRevenueValue.TabIndex = 0;
            lblKpiRevenueValue.Text = "₱0.00";
            lblKpiRevenueValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 9F);
            lblTotalRevenue.Location = new Point(80, 50);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(81, 15);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "Total Revenue";
            // 
            // pnlKpiUnpaid
            // 
            pnlKpiUnpaid.BackColor = Color.FromArgb(255, 240, 245);
            pnlKpiUnpaid.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiUnpaid.Controls.Add(lblKpiUnpaidValue);
            pnlKpiUnpaid.Controls.Add(lblTotalUnpaid);
            pnlKpiUnpaid.Location = new Point(680, 60);
            pnlKpiUnpaid.Name = "pnlKpiUnpaid";
            pnlKpiUnpaid.Size = new Size(260, 90);
            pnlKpiUnpaid.TabIndex = 9;
            // 
            // lblKpiUnpaidValue
            // 
            lblKpiUnpaidValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKpiUnpaidValue.Location = new Point(15, 10);
            lblKpiUnpaidValue.Name = "lblKpiUnpaidValue";
            lblKpiUnpaidValue.Size = new Size(230, 40);
            lblKpiUnpaidValue.TabIndex = 0;
            lblKpiUnpaidValue.Text = "₱0.00";
            lblKpiUnpaidValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Font = new Font("Segoe UI", 9F);
            lblTotalUnpaid.Location = new Point(80, 50);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(74, 15);
            lblTotalUnpaid.TabIndex = 1;
            lblTotalUnpaid.Text = "Total Unpaid";
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Location = new Point(80, 170);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(420, 200);
            plotMonthlyRevenue.TabIndex = 4;
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Location = new Point(520, 170);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(420, 200);
            plotPaidUnpaid.TabIndex = 5;
            // 
            // lblTop5Title
            // 
            lblTop5Title.AutoSize = true;
            lblTop5Title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTop5Title.Location = new Point(80, 385);
            lblTop5Title.Name = "lblTop5Title";
            lblTop5Title.Size = new Size(233, 19);
            lblTop5Title.TabIndex = 6;
            lblTop5Title.Text = "Top 5 Customers by Consumption";
            // 
            // dgvTop5
            // 
            dgvTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Location = new Point(80, 410);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.Size = new Size(760, 120);
            dgvTop5.TabIndex = 7;
            dgvTop5.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnCloseAnalytics
            // 
            btnCloseAnalytics.Location = new Point(860, 510);
            btnCloseAnalytics.Name = "btnCloseAnalytics";
            btnCloseAnalytics.Size = new Size(80, 30);
            btnCloseAnalytics.TabIndex = 8;
            btnCloseAnalytics.Text = "Close";
            btnCloseAnalytics.UseVisualStyleBackColor = true;
            btnCloseAnalytics.Click += button1_Click;
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 560);
            Controls.Add(btnCloseAnalytics);
            Controls.Add(dgvTop5);
            Controls.Add(lblTop5Title);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(plotMonthlyRevenue);
            Controls.Add(pnlKpiUnpaid);
            Controls.Add(pnlKpiRevenue);
            Controls.Add(pnlKpiCustomers);
            Controls.Add(lblTitle);
            Name = "frmAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Analytics Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += frmAnalytics_Load;
            // Wire Shown so charts can be populated once form is visible
            Shown += frmAnalytics_Shown;
            pnlKpiCustomers.ResumeLayout(false);
            pnlKpiCustomers.PerformLayout();
            pnlKpiRevenue.ResumeLayout(false);
            pnlKpiRevenue.PerformLayout();
            pnlKpiUnpaid.ResumeLayout(false);
            pnlKpiUnpaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlKpiCustomers;
        private Panel pnlKpiRevenue;
        private Panel pnlKpiUnpaid;
        private Label lblKpiCustomersValue;
        private Label lblKpiRevenueValue;
        private Label lblKpiUnpaidValue;
        private Label lblTotalCustomers;
        private Label lblTotalRevenue;
        private Label lblTotalUnpaid;
        private ScottPlot.WinForms.FormsPlot plotMonthlyRevenue;
        private ScottPlot.WinForms.FormsPlot plotPaidUnpaid;
        private Label lblTop5Title;
        private DataGridView dgvTop5;
        private Button btnCloseAnalytics;
    }
}