using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class BillingDAL
    {
        public bool InsertBilling(Billing billing)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO Billing (BookingID, DaysRented, DailyRate, BaseCost, LateFee, TotalAmount) 
                                     VALUES (@BookingID, @DaysRented, @DailyRate, @BaseCost, @LateFee, @TotalAmount)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", billing.BookingID);
                        cmd.Parameters.AddWithValue("@DaysRented", billing.DaysRented);
                        cmd.Parameters.AddWithValue("@DailyRate", billing.DailyRate);
                        cmd.Parameters.AddWithValue("@BaseCost", billing.BaseCost);
                        cmd.Parameters.AddWithValue("@LateFee", billing.LateFee);
                        cmd.Parameters.AddWithValue("@TotalAmount", billing.TotalAmount);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertBilling: " + ex.Message);
            }
        }

        public DataTable GetAllBillingRecords()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT bl.BillID, u.FullName as CustomerName, c.Brand + ' ' + c.Model + ' (' + c.PlateNumber + ')' as CarDetails,
                                            bk.PickupDate as RentStart, bk.ActualReturnDate as RentEnd, 
                                            bl.DaysRented, bl.DailyRate, bl.LateFee, bl.TotalAmount, bl.BillDate, bl.PaymentStatus
                                     FROM Billing bl
                                     INNER JOIN Bookings bk ON bl.BookingID = bk.BookingID
                                     INNER JOIN Users u ON bk.UserID = u.UserID
                                     INNER JOIN Cars c ON bk.CarID = c.CarID";
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
                throw new Exception("Error in GetAllBillingRecords: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetBillingRecordsByUserID(int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT bl.BillID, c.Brand + ' ' + c.Model + ' (' + c.PlateNumber + ')' as CarDetails,
                                            bk.PickupDate as RentStart, bk.ActualReturnDate as RentEnd, 
                                            bl.DaysRented, bl.DailyRate, bl.LateFee, bl.TotalAmount, bl.BillDate, bl.PaymentStatus
                                     FROM Billing bl
                                     INNER JOIN Bookings bk ON bl.BookingID = bk.BookingID
                                     INNER JOIN Cars c ON bk.CarID = c.CarID
                                     WHERE bk.UserID = @UserID";
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
                throw new Exception("Error in GetBillingRecordsByUserID: " + ex.Message);
            }
            return dt;
        }

        public bool UpdatePaymentStatus(int billId, string status)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Billing SET PaymentStatus = @PaymentStatus WHERE BillID = @BillID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PaymentStatus", status);
                        cmd.Parameters.AddWithValue("@BillID", billId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdatePaymentStatus: " + ex.Message);
            }
        }
    }
}
