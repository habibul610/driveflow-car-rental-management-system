using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    // Structure demonstrating Value Type usage
    public struct GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Lat: {Latitude}, Lon: {Longitude}";
        }
    }
}
