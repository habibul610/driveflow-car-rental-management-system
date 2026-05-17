using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class BookingDAL
    {
        public bool InsertBooking(Booking booking)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO Bookings (UserID, CarID, PickupDate, ExpectedReturnDate, Status, CouponCode, DiscountAmount, PaymentMethod) 
                                     VALUES (@UserID, @CarID, @PickupDate, @ExpectedReturnDate, @Status, @CouponCode, @DiscountAmount, @PaymentMethod)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", booking.UserID);
                        cmd.Parameters.AddWithValue("@CarID", booking.CarID);
                        cmd.Parameters.AddWithValue("@PickupDate", booking.PickupDate);
                        cmd.Parameters.AddWithValue("@ExpectedReturnDate", booking.ExpectedReturnDate);
                        cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(booking.Status) ? "Pending" : booking.Status);
                        cmd.Parameters.AddWithValue("@CouponCode", string.IsNullOrEmpty(booking.CouponCode) ? (object)DBNull.Value : booking.CouponCode);
                        cmd.Parameters.AddWithValue("@DiscountAmount", booking.DiscountAmount.HasValue ? booking.DiscountAmount.Value : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PaymentMethod", string.IsNullOrEmpty(booking.PaymentMethod) ? (object)DBNull.Value : booking.PaymentMethod);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertBooking: " + ex.Message);
            }
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Bookings SET Status = @Status WHERE BookingID = @BookingID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateBookingStatus: " + ex.Message);
                return false;
            }
        }

        public bool CompleteBooking(int bookingId, DateTime actualReturnDate, decimal totalAmount)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    // Guard: only update if booking is still Active (prevents double-return)
                    string query = "UPDATE Bookings SET Status = 'Completed', ActualReturnDate = @ActualReturnDate, TotalAmount = @TotalAmount WHERE BookingID = @BookingID AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CompleteBooking: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Processes a car return atomically — completes the booking, marks car as Available,
        /// and inserts the billing record all within a single SQL transaction.
        /// If any step fails, the entire operation is rolled back.
        /// </summary>
        public bool ProcessReturnAtomic(int bookingId, int carId, DateTime actualReturnDate,
            decimal totalAmount, int daysRented, decimal dailyRate, decimal baseCost, decimal lateFee)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Complete booking (guard: only if still Active)
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Bookings SET Status='Completed', ActualReturnDate=@ActualReturnDate, TotalAmount=@TotalAmount WHERE BookingID=@BookingID AND Status='Active'",
                            con, tx))
                        {
                            cmd.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate);
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmd.Parameters.AddWithValue("@BookingID", bookingId);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                tx.Rollback();
                                throw new Exception("This booking has already been returned or is not Active.");
                            }
                        }

                        // Step 2: Mark car as Available
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Cars SET Status='Available' WHERE CarID=@CarID",
                            con, tx))
                        {
                            cmd.Parameters.AddWithValue("@CarID", carId);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                tx.Rollback();
                                throw new Exception("Failed to update car status. Car ID not found.");
                            }
                        }

                        // Step 3: Insert billing record
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Billing (BookingID, DaysRented, DailyRate, BaseCost, LateFee, TotalAmount) VALUES (@BookingID, @DaysRented, @DailyRate, @BaseCost, @LateFee, @TotalAmount)",
                            con, tx))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", bookingId);
                            cmd.Parameters.AddWithValue("@DaysRented", daysRented);
                            cmd.Parameters.AddWithValue("@DailyRate", dailyRate);
                            cmd.Parameters.AddWithValue("@BaseCost", baseCost);
                            cmd.Parameters.AddWithValue("@LateFee", lateFee);
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                tx.Rollback();
                                throw new Exception("Failed to create billing record.");
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        public DataTable GetAllBookings()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT b.BookingID, u.FullName as CustomerName, c.Brand + ' ' + c.Model + ' (' + c.PlateNumber + ')' as CarDetails,
                                            b.PickupDate, b.ExpectedReturnDate, b.ActualReturnDate, b.Status, b.TotalAmount, b.CarID, b.CouponCode, b.DiscountAmount, b.PaymentMethod 
                                     FROM Bookings b 
                                     INNER JOIN Users u ON b.UserID = u.UserID
                                     INNER JOIN Cars c ON b.CarID = c.CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllBookings: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetBookingsByUserID(int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT b.BookingID, c.Brand + ' ' + c.Model + ' (' + c.PlateNumber + ')' as CarDetails,
                                            b.PickupDate, b.ExpectedReturnDate, b.ActualReturnDate, b.Status, b.TotalAmount, b.CarID, b.CouponCode, b.DiscountAmount, b.PaymentMethod  
                                     FROM Bookings b 
                                     INNER JOIN Cars c ON b.CarID = c.CarID
                                     WHERE b.UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetBookingsByUserID: " + ex.Message);
            }
            return dt;
        }

        public bool HasActiveBooking(int userId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Bookings WHERE UserID = @UserID AND Status IN ('Pending', 'Active')";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error checking active bookings: " + ex.Message);
            }
        }

        public decimal GetDiscountAmountForBooking(int bookingId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT ISNULL(DiscountAmount, 0) FROM Bookings WHERE BookingID = @BookingID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public decimal GetEarnings(DateTime? startDate = null)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Bookings WHERE Status = 'Completed'";
                    if (startDate.HasValue)
                    {
                        query += " AND ActualReturnDate >= @StartDate";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (startDate.HasValue)
                            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);

                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
