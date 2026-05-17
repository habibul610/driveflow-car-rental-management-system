using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    public static class AppConstants
    {
        // Demonstrating const (compile-time constant)
        public const string SystemName = "DriveFlow System";
        public const int MaxRentalDays = 30;

        // Demonstrating readonly (run-time constant)
        public static readonly DateTime SystemStartDate = new DateTime(2023, 1, 1);
        public static readonly string DefaultCurrency = "USD";
    }
}
