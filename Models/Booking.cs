using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
        public string Notes { get; set; }
        public string CouponCode { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
