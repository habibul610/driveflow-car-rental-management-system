using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class DiscountCouponBLL
    {
        private DiscountCouponDAL dal = new DiscountCouponDAL();

        public bool CreateCoupon(DiscountCoupon coupon)
        {
            if (string.IsNullOrWhiteSpace(coupon.Code)) throw new System.Exception("Coupon code cannot be empty.");
            if (GetCouponByCode(coupon.Code) != null) throw new System.Exception("A coupon with this code already exists.");
            if (coupon.DiscountPercentage <= 0 || coupon.DiscountPercentage > 100) throw new System.Exception("Invalid discount percentage.");
            return dal.CreateCoupon(coupon);
        }

        public DataTable GetAllCoupons()
        {
            return dal.GetAllCoupons();
        }

        public DiscountCoupon GetCouponByCode(string code)
        {
            return dal.GetCouponByCode(code);
        }

        public bool ToggleCouponStatus(int couponId, bool isActive)
        {
            return dal.UpdateCouponStatus(couponId, isActive);
        }
    }
}
