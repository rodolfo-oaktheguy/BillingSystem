using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private readonly int _customerId;
        private string? _customerName;
        private bool _loadFailed;

        // Only the customer's ID is passed in. The name is always read from the Customers table.
        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            AppTheme.Apply(this);
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    _customerName = GetCustomerName(conn);
                    if (_customerName == null)
                    {
                        return;
                    }

                    lblCustomerName.Text = $"Billing History — {_customerName}";
                    dgvBilling.DataSource = GetBillingRecords(conn);
                }
            }
            catch (Exception ex)
            {
                _loadFailed = true;
                MessageBox.Show($"Error loading billing records:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Runs once the form is visible, so the empty grid can be seen behind the popup.
        private void frmBillingHistory_Shown(object sender, EventArgs e)
        {
            if (_loadFailed)
            {
                Close();
                return;
            }

            if (_customerName == null)
            {
                MessageBox.Show("This customer could not be found. It may have been deleted.",
                    "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            if (dgvBilling.Rows.Count == 0)
            {
                MessageBox.Show($"No billing records were found for {_customerName}.",
                    "No Billing Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string? GetCustomerName(MySqlConnection conn)
        {
            const string sql = "SELECT FullName FROM Customers WHERE CustomerID = @CustomerID;";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", _customerId);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private DataTable GetBillingRecords(MySqlConnection conn)
        {
            // Oldest to newest, so each row's Previous Reading follows the Present Reading above it.
            // BillingMonth is text ("April 2026"), so sorting uses BillingDate instead.
            const string sql = @"SELECT BillingMonth,
                                        PreviousReading,
                                        PresentReading,
                                        Consumption,
                                        RatePerCubic,
                                        TotalAmount,
                                        Status
                                 FROM   Billing
                                 WHERE  CustomerID = @CustomerID
                                 ORDER  BY BillingDate ASC, BillingID ASC;";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", _customerId);

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
