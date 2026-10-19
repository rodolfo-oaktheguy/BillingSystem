using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BillingSystem.Database;
using BillingSystem.Utils;
using MySql.Data.MySqlClient;

namespace BillingSystem
{
    public partial class frmManagePermissions : Form
    {
        private readonly Dictionary<string, CheckBox> permissionChecks;

        public frmManagePermissions()
        {
            InitializeComponent();
            permissionChecks = new Dictionary<string, CheckBox>(StringComparer.OrdinalIgnoreCase)
            {
                ["AddCustomer"] = chkAddCustomer,
                ["EditCustomer"] = chkEditCustomer,
                ["DeleteCustomer"] = chkDeleteCustomer,
                ["Analytics"] = chkAnalytics,
                ["ExportExcel"] = chkExportExcel,
                ["ExportPdf"] = chkExportPdf,
                ["AuditLogs"] = chkAuditLogs
            };
            AppTheme.Apply(this);
        }

        private void frmManagePermissions_Load(object sender, EventArgs e)
        {
            if (!string.Equals(AppSession.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only an Admin can manage permissions.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            cmbRole.SelectedIndex = 0;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPermissionsForSelectedRole();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadPermissionsForSelectedRole()
        {
            if (cmbRole.SelectedItem == null)
            {
                return;
            }

            string role = cmbRole.SelectedItem.ToString() ?? string.Empty;
            var permissions = LoadPermissionsForRole(role);

            foreach (var permission in permissionChecks)
            {
                permission.Value.Checked = permissions.TryGetValue(permission.Key, out int allowed) && allowed == 1;
            }
        }

        private Dictionary<string, int> LoadPermissionsForRole(string role)
        {
            var result = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT PermissionName, IsAllowed FROM UserPermissions WHERE Role = @Role;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", role);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string permission = reader.GetString("PermissionName");
                                int enabled = reader.GetInt32("IsAllowed");
                                result[permission] = enabled;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load permissions.\n\n" + ex.Message, "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem == null)
            {
                return;
            }

            string role = cmbRole.SelectedItem.ToString() ?? string.Empty;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    foreach (var permission in permissionChecks)
                    {
                        const string sql = @"INSERT INTO UserPermissions (Role, PermissionName, IsAllowed)
                                             VALUES (@Role, @PermissionName, @IsAllowed)
                                             ON DUPLICATE KEY UPDATE IsAllowed = VALUES(IsAllowed);";

                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Role", role);
                            cmd.Parameters.AddWithValue("@PermissionName", permission.Key);
                            cmd.Parameters.AddWithValue("@IsAllowed", permission.Value.Checked ? 1 : 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                AuditLogger.LogAction("ManagePermissions", $"Updated permissions for role {role}.");
                MessageBox.Show("Permissions saved successfully.", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save permission changes.\n\n" + ex.Message, "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
