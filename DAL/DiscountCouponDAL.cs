using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class DiscountCouponDAL
    {
        public bool CreateCoupon(DiscountCoupon coupon)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO DiscountCoupons (Code, DiscountPercentage, IsActive) VALUES (@Code, @DiscountPercentage, @IsActive)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Code", coupon.Code.ToUpper());
                        cmd.Parameters.AddWithValue("@DiscountPercentage", coupon.DiscountPercentage);
                        cmd.Parameters.AddWithValue("@IsActive", coupon.IsActive);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating coupon: " + ex.Message);
            }
        }

        public DataTable GetAllCoupons()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM DiscountCoupons ORDER BY CreatedDate DESC";
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
                throw new Exception("Error fetching coupons: " + ex.Message);
            }
            return dt;
        }

        public DiscountCoupon GetCouponByCode(string code)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM DiscountCoupons WHERE Code = @Code";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Code", code.ToUpper());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DiscountCoupon
                                {
                                    CouponID = Convert.ToInt32(reader["CouponID"]),
                                    Code = reader["Code"].ToString(),
                                    DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool UpdateCouponStatus(int couponId, bool isActive)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE DiscountCoupons SET IsActive = @IsActive WHERE CouponID = @CouponID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.Parameters.AddWithValue("@CouponID", couponId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating coupon: " + ex.Message);
            }
        }
    }
}
