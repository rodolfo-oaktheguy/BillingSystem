using System;
using System.Data;
using System.Windows.Forms;
using BillingSystem.Database;
using BillingSystem.Utils;
using MySql.Data.MySqlClient;

namespace BillingSystem
{
    public partial class frmAuditLogs : Form
    {
        public frmAuditLogs()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
            AppTheme.Apply(this);
        }

        private void frmAuditLogs_Load(object sender, EventArgs e)
        {
            LoadAuditLogs(dtpFrom.Value, dtpTo.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAuditLogs(dtpFrom.Value, dtpTo.Value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadAuditLogs(DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
            {
                MessageBox.Show("The From date cannot be later than the To date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT LogDate, Username, Role, Action, Details
                                   FROM AuditLogs
                                   WHERE LogDate >= @FromDate AND LogDate < @ToDateExclusive
                                   ORDER BY LogDate DESC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@ToDateExclusive", toDate.Date.AddDays(1));

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            var table = new DataTable();
                            adapter.Fill(table);
                            dgvAuditLogs.DataSource = table;
                            lblRecordCount.Text = $"{table.Rows.Count} record(s)";

                            if (dgvAuditLogs.Columns.Contains("LogDate"))
                            {
                                dgvAuditLogs.Columns["LogDate"].HeaderText = "Date / Time";
                                dgvAuditLogs.Columns["LogDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                            }

                            dgvAuditLogs.Columns["Username"].HeaderText = "Username";
                            dgvAuditLogs.Columns["Role"].HeaderText = "Role";
                            dgvAuditLogs.Columns["Action"].HeaderText = "Action";
                            dgvAuditLogs.Columns["Details"].HeaderText = "Details";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audit Logs could not be loaded.\n\n" + ex.Message, "Audit Logs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
