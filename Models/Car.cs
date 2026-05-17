using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Car : IVehicle
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public DateTime AddedDate { get; set; }
        public string ImagePath { get; set; }
        public string CarDetails { get; set; }  // Rich description: engine, seats, fuel, features etc.
        
        // Demonstrating Enum usage
        public VehicleType Type { get; set; }

        // Demonstrating Nullable types
        public DateTime? LastServiceDate { get; set; }

        // Demonstrating Interface Implementation
        public string GetVehicleDescription()
        {
            return $"{Brand} {Model} ({Year}) - {Type}";
        }

        public bool IsAvailableForRent()
        {
            return Status == "Available";
        }
    }
}
