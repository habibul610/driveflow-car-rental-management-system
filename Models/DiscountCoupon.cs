using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Models
{
    public class DiscountCoupon
    {
        public int CouponID { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
