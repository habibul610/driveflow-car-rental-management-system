using CAR_RENTAL_MANAGEMENT_SYSTEM.DAL;
using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.BLL
{
    public class BookingBLL
    {
        // Demonstrating Delegates and Events
        public delegate void BookingActionHandler(string actionDetails);
        public event BookingActionHandler OnBookingAction;

        private BookingDAL bookingDAL = new BookingDAL();
        private CarDAL carDAL = new CarDAL();
        private BillingDAL billingDAL = new BillingDAL();

        // Demonstrating Built-in delegates (Func) and Lambda expressions
        public decimal CalculateDynamicDiscount(decimal baseCost, Func<decimal, decimal> discountLogic)
        {
            return discountLogic != null ? discountLogic(baseCost) : baseCost;
        }

        public void ValidateUserRole(User user)
        {
            // Demonstrating 'is' and 'as' operators
            if (user is Admin)
            {
                Admin adminUser = user as Admin;
                OnBookingAction?.Invoke($"Admin {adminUser.Username} validated.");
            }
            else if (user is Customer customer)
            {
                OnBookingAction?.Invoke($"Customer {customer.Username} validated.");
            }
        }

        public bool CreateBooking(int userId, int carId, DateTime pickupDate, DateTime expectedReturnDate, string status = "Pending", string paymentMethod = "Not Selected", string couponCode = null, decimal? discountAmount = null)
        {
            Car car = carDAL.GetCarByID(carId);
            if (car == null || car.Status != "Available")
            {
                throw new Exception("Car is no longer available.");
            }

            if (bookingDAL.HasActiveBooking(userId))
            {
                throw new Exception("You already have an active booking.");
            }

            Booking booking = new Booking
            {
                UserID = userId,
                CarID = carId,
                PickupDate = pickupDate,
                ExpectedReturnDate = expectedReturnDate,
                Status = status,
                PaymentMethod = paymentMethod,
                CouponCode = couponCode,
                DiscountAmount = discountAmount
            };

            bool inserted = bookingDAL.InsertBooking(booking);
            if (inserted && status == "Active")
            {
                carDAL.UpdateCarStatus(carId, "Rented");
                
                // Demonstrating Event Invocation and Lambda expression (Action delegate usage)
                Action<string> logAction = msg => OnBookingAction?.Invoke(msg);
                logAction($"Booking created and car {carId} rented by user {userId}.");
            }
            return inserted;
        }

        public bool ApproveBooking(int bookingId, int carId)
        {
            bool bookingUpdated = bookingDAL.UpdateBookingStatus(bookingId, "Active");
            if (bookingUpdated)
            {
                return carDAL.UpdateCarStatus(carId, "Rented");
            }
            return false;
        }

        public bool CancelBooking(int bookingId, int carId = 0, string currentStatus = "")
        {
            bool cancelled = bookingDAL.UpdateBookingStatus(bookingId, "Cancelled");
            if (cancelled && currentStatus == "Active" && carId > 0)
            {
                return carDAL.UpdateCarStatus(carId, "Available");
            }
            return cancelled;
        }

        public bool ProcessReturn(int bookingId, int carId, DateTime pickupDate, DateTime expectedReturnDate, DateTime actualReturnDate, decimal dailyRate, decimal discountAmount = 0)
        {
            // If no discount was passed in, retrieve it from the stored booking record
            if (discountAmount == 0)
            {
                decimal storedDiscount = bookingDAL.GetDiscountAmountForBooking(bookingId);
                if (storedDiscount > 0) discountAmount = storedDiscount;
            }

            int daysRented = (actualReturnDate - pickupDate).Days;
            if (daysRented < 1) daysRented = 1;

            decimal baseCost = daysRented * dailyRate;
            baseCost -= discountAmount;
            if (baseCost < 0) baseCost = 0;

            int lateDays = (actualReturnDate - expectedReturnDate).Days;
            if (lateDays < 0) lateDays = 0;

            decimal lateFee = lateDays * dailyRate * 1.5m;
            decimal totalAmount = baseCost + lateFee;

            // Use atomic DAL method: all 3 DB operations in a single transaction.
            // If any step fails, everything is rolled back to prevent corrupt state.
            return bookingDAL.ProcessReturnAtomic(
                bookingId, carId, actualReturnDate,
                totalAmount, daysRented, dailyRate, baseCost, lateFee);
        }

        public DataTable GetAllBookings()
        {
            return bookingDAL.GetAllBookings();
        }

        public DataTable GetBookingsByUserID(int userId)
        {
            return bookingDAL.GetBookingsByUserID(userId);
        }

        public decimal GetEarnings(DateTime? startDate = null)
        {
            return bookingDAL.GetEarnings(startDate);
        }
    }
}
