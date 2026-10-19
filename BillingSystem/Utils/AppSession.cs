using System;

namespace BillingSystem.Utils
{
    public static class AppSession
    {
        public static int CurrentUserID { get; private set; }
        public static string CurrentUsername { get; private set; } = string.Empty;
        public static string CurrentFullName { get; private set; } = string.Empty;
        public static string CurrentRole { get; private set; } = string.Empty;
        public static bool IsAuthenticated => CurrentUserID > 0;

        public static void SetCurrentUser(int userId, string username, string fullName, string role)
        {
            CurrentUserID = userId;
            CurrentUsername = username ?? string.Empty;
            CurrentFullName = fullName ?? string.Empty;
            CurrentRole = role ?? string.Empty;
        }

        public static void Clear()
        {
            CurrentUserID = 0;
            CurrentUsername = string.Empty;
            CurrentFullName = string.Empty;
            CurrentRole = string.Empty;
        }
    }
}
