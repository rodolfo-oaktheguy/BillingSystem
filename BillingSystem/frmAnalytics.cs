using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using ScottPlot;


namespace BillingSystem
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();
            // Ensure dgvTop5 exists and only touch named columns if they are present
            if (dgvTop5 != null)
            {
                dgvTop5.AutoGenerateColumns = false;
                if (dgvTop5.Columns.Contains("FullName"))
                    dgvTop5.Columns["FullName"].DataPropertyName = "FullName";
                if (dgvTop5.Columns.Contains("TotalConsumption"))
                    dgvTop5.Columns["TotalConsumption"].DataPropertyName = "TotalConsumption";
                if (dgvTop5.Columns.Contains("TotalBilled"))
                    dgvTop5.Columns["TotalBilled"].DataPropertyName = "TotalBilled";
            }
        }
        private void LoadTop5Customers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT c.FullName,
                                  SUM(b.Consumption)  AS TotalConsumption,
                                  SUM(b.TotalAmount)  AS TotalBilled
                           FROM   Customers c
                           INNER JOIN Billing b ON c.CustomerID = b.CustomerID
                           GROUP  BY c.CustomerID, c.FullName
                           ORDER  BY TotalConsumption DESC
                           LIMIT  5;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // The designer has no columns, so generate them from the query results.
                        dgvTop5.AutoGenerateColumns = true;
                        dgvTop5.ReadOnly = true;
                        dgvTop5.AllowUserToAddRows = false;
                        dgvTop5.RowHeadersVisible = false;
                        dgvTop5.DataSource = dt;

                        if (dgvTop5.Columns.Contains("FullName"))
                        {
                            dgvTop5.Columns["FullName"].HeaderText = "Customer Name";
                            dgvTop5.Columns["TotalConsumption"].HeaderText = "Total Consumption (kWh)";
                            dgvTop5.Columns["TotalBilled"].HeaderText = "Total Billed (₱)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Top 5 customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadPaidUnpaidChart()
        {
            try
            {
                int paidCount = 0;
                int unpaidCount = 0;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Count bills grouped by status
                    string sql = @"SELECT Status, COUNT(*) AS StatusCount
                                   FROM Billing
                                   GROUP BY Status;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.IsDBNull(0) ? string.Empty : reader.GetString("Status");
                            int count = reader.GetInt32("StatusCount");

                            if (string.Equals(status, "Paid", StringComparison.OrdinalIgnoreCase)) paidCount = count;
                            else if (string.Equals(status, "Unpaid", StringComparison.OrdinalIgnoreCase)) unpaidCount = count;
                        }
                    }
                }

                plotPaidUnpaid.Plot.Clear();

                double[] values = { paidCount, unpaidCount };
                string[] labels = { "Paid", "Unpaid" };
                double total = paidCount + unpaidCount;

                var pie = plotPaidUnpaid.Plot.Add.Pie(values);
                for (int i = 0; i < pie.Slices.Count; i++)
                {
                    double percentage = total > 0 ? values[i] / total : 0;
                    pie.Slices[i].Label = $"{labels[i]} ({percentage:P0})";
                }
                pie.SliceLabelDistance = 0.5;
                plotPaidUnpaid.Plot.Title("Paid vs Unpaid Bills");
                plotPaidUnpaid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Paid/Unpaid chart:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMonthlyRevenueChart()
        {
            try
            {
                // Prepare containers for Jan..Jun 2026
                string[] monthLabels = { "Jan 2026", "Feb 2026", "Mar 2026", "Apr 2026", "May 2026", "Jun 2026" };
                double[] amounts = new double[6];

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Sum paid bills grouped by month for Jan-Jun 2026
                    string sql = @"SELECT MONTH(BillingDate) AS m, IFNULL(SUM(TotalAmount),0) AS MonthlyTotal
                                   FROM Billing
                                   WHERE Status = 'Paid' AND BillingDate >= '2026-01-01' AND BillingDate < '2026-07-01'
                                   GROUP BY MONTH(BillingDate);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int m = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            decimal total = reader.IsDBNull(1) ? 0m : reader.GetDecimal(1);
                            if (m >= 1 && m <= 6)
                                amounts[m - 1] = (double)total;
                        }
                    }
                }

                plotMonthlyRevenue.Plot.Clear();
                double[] positions = { 0, 1, 2, 3, 4, 5 };
                var barPlot = plotMonthlyRevenue.Plot.Add.Bars(amounts, positions);

                // If there is no data for Jan–Jun 2026, warn so you can check the DB; otherwise draw chart.
                double totalAmounts = 0;
                foreach (var v in amounts) totalAmounts += v;
                if (totalAmounts == 0)
                {
                    // Informative but non-fatal: likely no paid bills in Jan–Jun 2026
                    MessageBox.Show("No paid billing data found for Jan–Jun 2026. Monthly chart will be empty.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Note: for ScottPlot v5 the axis/tick APIs differ; leave default styling so code compiles across versions.

                plotMonthlyRevenue.Plot.Title("Monthly Revenue (Jan–Jun 2026)");
                plotMonthlyRevenue.Plot.YLabel("Revenue (₱)");
                plotMonthlyRevenue.Plot.XLabel("Month");
                plotMonthlyRevenue.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly revenue chart:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Called when form is shown: load charts and save screenshots
        private void frmAnalytics_Shown(object sender, EventArgs e)
        {
            try
            {
                // Save screenshots of both plots to working directory
                SaveControlScreenshot(plotMonthlyRevenue, "frmAnalytics_MonthlyRevenue.png");
                SaveControlScreenshot(plotPaidUnpaid, "frmAnalytics_PaidVsUnpaid.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during chart capture: " + ex.Message);
            }
        }

        private void SaveControlScreenshot(Control ctrl, string path)
        {
            if (ctrl == null) return;
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using (var bmp = new System.Drawing.Bitmap(ctrl.Width, ctrl.Height))
            {
                ctrl.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void LoadKpiSummary()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // 1) Total number of customers
                    string sqlCustomers = "SELECT COUNT(*) FROM Customers;";
                    using (var cmd = new MySqlCommand(sqlCustomers, conn))
                    {
                        int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                        lblKpiCustomersValue.Text = totalCustomers.ToString();
                    }

                    // 2) Total revenue — sum of all PAID bills
                    string sqlRevenue = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                  FROM   Billing
                                  WHERE  Status = 'Paid';";
                    using (var cmd = new MySqlCommand(sqlRevenue, conn))
                    {
                        decimal totalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblKpiRevenueValue.Text = totalRevenue.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-PH"));
                    }

                    // 3) Total unpaid — sum of all UNPAID bills
                    string sqlUnpaid = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                 FROM   Billing
                                 WHERE  Status = 'Unpaid';";
                    using (var cmd = new MySqlCommand(sqlUnpaid, conn))
                    {
                        decimal totalUnpaid = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblKpiUnpaidValue.Text = totalUnpaid.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-PH"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading KPI summary:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            LoadKpiSummary();
            LoadMonthlyRevenueChart();
            LoadPaidUnpaidChart();
            LoadTop5Customers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAnalytics()
        {
            try
            {
                using (var conn = Database.DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Total customers
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Customers;", conn))
                    {
                        var o = cmd.ExecuteScalar();
                        int total = 0;
                        if (o != null && o != DBNull.Value) total = Convert.ToInt32(o);
                        lblKpiCustomersValue.Text = total.ToString();
                    }

                    // Total revenue (sum of Balance)
                    using (var cmd = new MySqlCommand("SELECT SUM(Balance) FROM Customers;", conn))
                    {
                        var o = cmd.ExecuteScalar();
                        decimal totalRevenue = 0m;
                        if (o != null && o != DBNull.Value) totalRevenue = Convert.ToDecimal(o);
                        lblKpiRevenueValue.Text = totalRevenue.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-PH"));
                    }

                    // Total unpaid from Billing, consistent with the Paid/Unpaid chart
                    using (var cmd = new MySqlCommand("SELECT IFNULL(SUM(TotalAmount), 0) FROM Billing WHERE Status = 'Unpaid';", conn))
                    {
                        var o = cmd.ExecuteScalar();
                        decimal totalUnpaid = 0m;
                        if (o != null && o != DBNull.Value) totalUnpaid = Convert.ToDecimal(o);
                        lblKpiUnpaidValue.Text = totalUnpaid.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-PH"));
                    }

                    // Top 5 by Balance as fallback for consumption
                    using (var cmd = new MySqlCommand(@"SELECT FullName, Balance AS TotalConsumption, Balance AS TotalBilled
                                                          FROM Customers
                                                          ORDER BY Balance DESC
                                                          LIMIT 5;", conn))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Top 5 query returned no rows. Check Customers data/Balance values.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            // If designer columns with the expected names are not present,
                            // allow the grid to auto-generate columns from the DataTable so rows are visible.
                            if (dgvTop5 != null)
                            {
                                if (!dgvTop5.Columns.Contains("FullName"))
                                    dgvTop5.AutoGenerateColumns = true;
                                else
                                    dgvTop5.AutoGenerateColumns = false;

                                dgvTop5.ReadOnly = true;
                                dgvTop5.RowHeadersVisible = false;
                                dgvTop5.AllowUserToAddRows = false;
                            }

                            dgvTop5.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
