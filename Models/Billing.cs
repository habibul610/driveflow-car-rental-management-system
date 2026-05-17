using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class Billing
    {
        public int BillID { get; set; }
        public int BookingID { get; set; }
        public int DaysRented { get; set; }
        public decimal DailyRate { get; set; }
        public decimal BaseCost { get; set; }
        public decimal LateFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string PaymentStatus { get; set; } = "Unpaid";
    }
}
