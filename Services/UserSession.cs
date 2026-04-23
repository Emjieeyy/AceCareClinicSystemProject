using System;

namespace AceCareClinicSystem.Services
{
    public static class UserSession
    {
        public static int UserId { get; set; } = 0;
        public static string Username { get; set; } = "Guest";
        public static string FullName { get; set; } = "Guest User";
        public static string Role { get; set; } = "None";
        public static bool IsLoggedIn { get; set; } = false;  // NEW

        public static void Clear()
        {
            UserId = 0;
            Username = "Guest";
            FullName = "Guest User";
            Role = "None";
            IsLoggedIn = false;  // NEW
        }
    }
}