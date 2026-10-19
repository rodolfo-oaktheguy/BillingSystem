using System;
using BillingSystem.Database;
using MySql.Data.MySqlClient;

namespace BillingSystem.Utils
{
    public static class AuditLogger
    {
        public static void LogAction(string action, string details)
        {
            if (!AppSession.IsAuthenticated)
            {
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO AuditLogs (UserID, Username, Role, Action, Details)
                                   VALUES (@UserID, @Username, @Role, @Action, @Details);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                        cmd.Parameters.AddWithValue("@Username", AppSession.CurrentUsername);
                        cmd.Parameters.AddWithValue("@Role", AppSession.CurrentRole);
                        cmd.Parameters.AddWithValue("@Action", action ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Details", details ?? string.Empty);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Ignore logging issues so the app remains usable even if the table is missing.
            }
        }
    }
}
