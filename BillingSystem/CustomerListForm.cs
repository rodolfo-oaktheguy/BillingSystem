using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;
using ClosedXML.Excel;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;





namespace BillingSystem
{
    public partial class CUSTOMERLISTATUN : Form
    {
        private int _selectedCustomerId = 0;
        private Button _btnAuditLogs;
        private Button _btnManagePermissions;

        private void AddDynamicButtons()
        {
            _btnAuditLogs = new Button
            {
                Name = "btnAuditLogs",
                Text = "Audit Logs",
                Size = new Size(110, 22),
                Location = new Point(440, 286),
                Enabled = false
            };
            _btnAuditLogs.Click += btnAuditLogs_Click;

            _btnManagePermissions = new Button
            {
                Name = "btnManagePermissions",
                Text = "Manage Permissions",
                Size = new Size(130, 22),
                Location = new Point(560, 286),
                Enabled = false
            };
            _btnManagePermissions.Click += btnManagePermissions_Click;

            Controls.Add(_btnAuditLogs);
            Controls.Add(_btnManagePermissions);
        }

        private void InitStatusStrip()
        {
            lblStatusUser.Text = $"User: {AppSession.CurrentUsername}  |  Role: {AppSession.CurrentRole}";
            UpdateClock();
        }

        private void UpdateClock()
        {
            lblStatusTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy   hh:mm:ss tt");
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // SELECT all customers, most recently added first
                    string sql = @"SELECT CustomerID,
                                  FullName,
                                  Address,
                                  ContactNumber,
                                  Email,
                                  Balance,
                                  Status
                           FROM   Customers
                           ORDER  BY FullName ASC;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to the grid
                        dgvCustomers.DataSource = dt;

                        // Improve column headers for readability
                        if (dgvCustomers.Columns.Count > 0)
                        {
                            dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                            dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                            dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact No.";
                            dgvCustomers.Columns["Balance"].HeaderText = "Balance (₱)";
                        }

                        lblTitle.Text = $"Customer List  ({dt.Rows.Count} record(s))";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCustomers(string keyword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized SELECT with WHERE ... LIKE
                    string sql = @"SELECT CustomerID,
                                  FullName,
                                  Address,
                                  ContactNumber,
                                  Email,
                                  Balance,
                                  Status
                           FROM   Customers
                           WHERE  FullName      LIKE @keyword
                              OR  Address       LIKE @keyword
                              OR  ContactNumber LIKE @keyword
                           ORDER  BY FullName ASC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // %keyword% matches the search text anywhere in the column
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvCustomers.DataSource = dt;
                            lblTitle.Text = $"Customer List  ({dt.Rows.Count} result(s))";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers:\n{ex.Message}",
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1_TextChanged(sender, e);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
            dgvCustomers.Columns["FullName"].DataPropertyName = "FullName";
            dgvCustomers.Columns["Address"].DataPropertyName = "Address";
            dgvCustomers.Columns["ContactNumber"].DataPropertyName = "ContactNumber";
            dgvCustomers.Columns["Email"].DataPropertyName = "Email";
            dgvCustomers.Columns["Balance"].DataPropertyName = "Balance";
            dgvCustomers.Columns["Status"].DataPropertyName = "Status";
        }
        private void DeleteCustomer(int customerId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Parameterized DELETE — removes exactly one row
                    string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.",
                                "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadCustomers();   // Refresh the grid
                            _selectedCustomerId = 0;   // Clear selection tracker
                        }
                        else
                        {
                            MessageBox.Show("Customer could not be deleted. It may no longer exist.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // If no row is selected (e.g., grid is empty), do nothing
            if (dgvCustomers.CurrentRow == null) return;

            // Read the CustomerID value from the selected row
            var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;

            if (idCell != null && int.TryParse(idCell.ToString(), out int id))
            {
                _selectedCustomerId = id;
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex is -1 when the header row is double-clicked — ignore it
            if (e.RowIndex < 0) return;

            OpenEditForm();
        }

        private void OpenEditForm()
        {
            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to edit.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open AddCustomerForm in EDIT mode, passing the selected CustomerID
            AddCustomerFormRei editForm = new AddCustomerFormRei(_selectedCustomerId);

            // Refresh the grid automatically once the edit form closes
            editForm.FormClosed += (s, args) => LoadCustomers();

            editForm.ShowDialog(this);
        }


        public CUSTOMERLISTATUN()
        {
            InitializeComponent();
            ConfigureDataGridView();
            AddDynamicButtons();
            dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
            AppTheme.Apply(this);
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadCustomers();
            ApplyRolePermissions();
            InitStatusStrip();
        }

        private void ApplyTheme()
        {
            AppTheme.Apply(this);
            BackColor = AppTheme.Background;
            button1.BackColor = AppTheme.Success;
            btnDelete.BackColor = AppTheme.Danger;
            btnAnalytics.BackColor = AppTheme.Primary;
            btnExportExcel.BackColor = AppTheme.Secondary;
            btnExportPdf.BackColor = AppTheme.Secondary;
            _btnAuditLogs.BackColor = AppTheme.Secondary;
            _btnManagePermissions.BackColor = AppTheme.Danger;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.Primary;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void ApplyRolePermissions()
        {
            button1.Enabled = PermissionService.HasPermission("AddCustomer");
            btnDelete.Enabled = PermissionService.HasPermission("DeleteCustomer");
            btnAnalytics.Enabled = PermissionService.HasPermission("Analytics");
            btnExportExcel.Enabled = PermissionService.HasPermission("ExportExcel");
            btnExportPdf.Enabled = PermissionService.HasPermission("ExportPdf");
            _btnAuditLogs.Enabled = PermissionService.HasPermission("AuditLogs");
            _btnManagePermissions.Enabled = PermissionService.HasPermission("ManagePermissions");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission("AddCustomer"))
            {
                MessageBox.Show("You do not have permission to add customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddCustomerFormRei addCustomerForm = new AddCustomerFormRei();
            addCustomerForm.FormClosed += (_, __) => LoadCustomers();
            addCustomerForm.ShowDialog(this);
            AuditLogger.LogAction("AddCustomer", "Opened Add Customer form.");
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission("AuditLogs"))
            {
                MessageBox.Show("You do not have permission to view audit logs.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AuditLogger.LogAction("OpenAuditLogs", "Opened Audit Logs form.");
            using (var auditForm = new frmAuditLogs())
            {
                auditForm.ShowDialog(this);
            }
        }

        private void btnManagePermissions_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission("ManagePermissions"))
            {
                MessageBox.Show("You do not have permission to manage permissions.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AuditLogger.LogAction("OpenManagePermissions", "Opened Manage Permissions form.");
            using (var permissionForm = new frmManagePermissions())
            {
                permissionForm.ShowDialog(this);
            }
        }

        private void dvgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvCustomers.Rows[e.RowIndex].DataBoundItem is not DataRowView rowData ||
                !rowData.Row.Table.Columns.Contains("Status"))
            {
                return;
            }

            string status = rowData["Status"]?.ToString() ?? string.Empty;
            if (string.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = AppTheme.InactiveRowColor;
            }
            else if (string.Equals(status, "Active", StringComparison.OrdinalIgnoreCase) &&
                     dgvCustomers.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                e.CellStyle.BackColor = AppTheme.ActiveRowColor;
            }
        }



        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Empty search box → show all customers again
                LoadCustomers();
            }
            else
            {
                SearchCustomers(keyword);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission("DeleteCustomer"))
            {
                MessageBox.Show("You do not have permission to delete customers.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this customer?\nAll billing records for this customer will also be deleted.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DeleteCustomer(_selectedCustomerId);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuditLogger.LogAction("Logout", $"User {AppSession.CurrentUsername} logged out.");
            AppSession.Clear();

            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission("Analytics"))
            {
                MessageBox.Show("You do not have permission to view analytics.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AuditLogger.LogAction("OpenAnalytics", "Opened Analytics dashboard.");
            frmAnalytics analyticsForm = new frmAnalytics();
            analyticsForm.ShowDialog(this);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Make sure there is something to export
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Let the user choose where to save the file
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveDialog.FileName = "CustomerList.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Customers");

                        // Write column headers in row 1
                        for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dgvCustomers.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                        }

                        // Write each data row starting from row 2
                        for (int row = 0; row < dgvCustomers.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                            {
                                var cellValue = dgvCustomers.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 2, col + 1).Value = cellValue?.ToString() ?? "";
                            }
                        }

                        // Auto-adjust column widths to fit the content
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show("Customer list exported successfully to Excel.",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to Excel:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            // Make sure there is something to export
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Document (*.pdf)|*.pdf";
                saveDialog.FileName = "CustomerList.pdf";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (PdfDocument document = new PdfDocument())
                    {
                        // Create a new page set to Landscape orientation
                        PdfPage page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        {
                            XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                            XFont cellFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                            // Title
                            gfx.DrawString("Customer List Report", titleFont, XBrushes.Black,
                                new XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter);

                            int columnCount = dgvCustomers.Columns.Count;
                            double margin = 30;
                            double tableWidth = page.Width.Point - (margin * 2);
                            double colWidth = tableWidth / columnCount;
                            double rowHeight = 22;
                            double y = 60;

                            // Draw column headers
                            double x = margin;
                            for (int col = 0; col < columnCount; col++)
                            {
                                gfx.DrawString(dgvCustomers.Columns[col].HeaderText, headerFont,
                                    XBrushes.Black, new XRect(x, y, colWidth, rowHeight),
                                    XStringFormats.CenterLeft);
                                x += colWidth;
                            }

                            y += rowHeight;
                            gfx.DrawLine(XPens.Black, margin, y, page.Width.Point - margin, y);

                            // Draw each data row
                            foreach (DataGridViewRow row in dgvCustomers.Rows)
                            {
                                x = margin;
                                y += rowHeight;

                                // Start a new page if we run out of vertical space
                                if (y > page.Height.Point - margin)
                                {
                                    page = document.AddPage();
                                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                                    gfx.Dispose();
                                    gfx = XGraphics.FromPdfPage(page);
                                    y = 40;
                                }

                                for (int col = 0; col < columnCount; col++)
                                {
                                    string text = row.Cells[col].Value?.ToString() ?? "";
                                    gfx.DrawString(text, cellFont, XBrushes.Black,
                                        new XRect(x, y, colWidth, rowHeight),
                                        XStringFormats.CenterLeft);
                                    x += colWidth;
                                }
                            }
                        }

                        gfx.Dispose();   // finish drawing before saving
                        document.Save(saveDialog.FileName);
                    }

                    MessageBox.Show("Customer list exported successfully to PDF.",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to PDF:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}



