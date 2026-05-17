using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class GPSLog
    {
        public int LogID { get; set; }
        public int CarID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Speed { get; set; }
        public DateTime LogDate { get; set; }

        // For display
        public string CarDetails { get; set; } = string.Empty;
    }
}
