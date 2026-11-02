using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        private const int MinLength = 8;

        public frmChangePassword()
        {
            InitializeComponent();
            AppTheme.Apply(this);
        }

        // Validation order (fail fast, cheapest / most fundamental first):
        //   1. Current password   - confirms identity before anything else is evaluated.
        //   2. Retype match       - simple typo check, no reason to judge complexity of a mistyped value.
        //   3. Complexity         - all unmet rules are shown AT ONCE so the user can fix them in one go.
        //   4. Save               - only reached when 1-3 pass.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated)
            {
                MessageBox.Show("No user is logged in.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string retype = txtRetypePassword.Text;

            if (string.IsNullOrEmpty(current))
            {
                MessageBox.Show("Please enter your current password.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // 1. Current password check
                    if (!IsCurrentPasswordCorrect(conn, current))
                    {
                        MessageBox.Show("The current password is incorrect.\nYour password was not changed.",
                            "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCurrentPassword.Clear();
                        txtCurrentPassword.Focus();
                        return;
                    }

                    // 2. Retype match check (exact, case-sensitive)
                    if (!string.Equals(newPass, retype, StringComparison.Ordinal))
                    {
                        MessageBox.Show("New Password and Retype Password do not match.\nYour password was not changed.",
                            "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRetypePassword.Clear();
                        txtRetypePassword.Focus();
                        return;
                    }

                    // 3. Complexity check
                    List<string> missing = GetMissingRequirements(newPass);
                    if (missing.Count > 0)
                    {
                        MessageBox.Show(
                            "The new password does not meet the following requirements:\n\n• " +
                            string.Join("\n• ", missing) +
                            "\n\nYour password was not changed.",
                            "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPassword.Focus();
                        txtNewPassword.SelectAll();
                        return;
                    }

                    // 4. All checks passed - update only the logged-in user's row
                    const string sql = "UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID;";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", newPass);
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);

                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("The password could not be updated. Your account was not found.",
                                "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                AuditLogger.LogAction("ChangePassword", $"User {AppSession.CurrentUsername} changed their password.");
                MessageBox.Show("Your password has been changed successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password:\n{ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsCurrentPasswordCorrect(MySqlConnection conn, string typedPassword)
        {
            // Fetch the stored value by UserID and compare in code so the check is case-sensitive
            // (MySQL's default collation would treat 'ABC' and 'abc' as equal).
            const string sql = "SELECT Password FROM Users WHERE UserID = @UserID;";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                object? result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value &&
                       string.Equals(result.ToString(), typedPassword, StringComparison.Ordinal);
            }
        }

        private static List<string> GetMissingRequirements(string password)
        {
            var missing = new List<string>();

            if (password.Length < MinLength)
                missing.Add($"At least {MinLength} characters long");
            if (!password.Any(c => c >= 'A' && c <= 'Z'))
                missing.Add("At least one uppercase letter (A-Z)");
            if (!password.Any(c => c >= 'a' && c <= 'z'))
                missing.Add("At least one lowercase letter (a-z)");
            if (!password.Any(c => c >= '0' && c <= '9'))
                missing.Add("At least one numeric digit (0-9)");
            if (!password.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
                missing.Add("At least one special character (e.g. !@#$%^&*)");

            return missing;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
