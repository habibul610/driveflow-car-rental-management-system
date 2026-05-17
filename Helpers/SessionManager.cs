using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static void ClearSession()
        {
            CurrentUser = null;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
