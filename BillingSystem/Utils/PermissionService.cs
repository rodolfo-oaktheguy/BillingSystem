using System;
using BillingSystem.Database;
using MySql.Data.MySqlClient;

namespace BillingSystem.Utils
{
    public static class PermissionService
    {
        public static bool HasPermission(string permissionName)
        {
            if (!AppSession.IsAuthenticated)
            {
                return false;
            }

            if (string.Equals(AppSession.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT IsAllowed
                                   FROM UserPermissions
                                   WHERE Role = @Role AND PermissionName = @PermissionName;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", AppSession.CurrentRole);
                        cmd.Parameters.AddWithValue("@PermissionName", permissionName);

                        var result = cmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            return false;
                        }

                        return Convert.ToInt32(result) == 1;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
