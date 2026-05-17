using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class ReviewDAL
    {
        public bool CreateReview(Review review)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO Reviews (CarID, UserID, Rating, Comment) 
                                     VALUES (@CarID, @UserID, @Rating, @Comment)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", review.CarID);
                        cmd.Parameters.AddWithValue("@UserID", review.UserID);
                        cmd.Parameters.AddWithValue("@Rating", review.Rating);
                        cmd.Parameters.AddWithValue("@Comment", string.IsNullOrEmpty(review.Comment) ? (object)DBNull.Value : review.Comment);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating review: " + ex.Message);
            }
        }

        public List<Review> GetAllReviews()
        {
            var list = new List<Review>();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT r.*, u.FullName as UserName, c.Brand + ' ' + c.Model as CarName 
                                     FROM Reviews r 
                                     INNER JOIN Users u ON r.UserID = u.UserID
                                     INNER JOIN Cars c ON r.CarID = c.CarID
                                     ORDER BY r.ReviewDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Review
                                {
                                    ReviewID = Convert.ToInt32(reader["ReviewID"]),
                                    CarID = Convert.ToInt32(reader["CarID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Rating = Convert.ToInt32(reader["Rating"]),
                                    Comment = reader["Comment"] != DBNull.Value ? reader["Comment"].ToString() : "",
                                    ReviewDate = Convert.ToDateTime(reader["ReviewDate"]),
                                    UserName = reader["UserName"].ToString(),
                                    CarName = reader["CarName"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching reviews: " + ex.Message);
            }
            return list;
        }

        public bool UpdateReview(int reviewId, int rating, string comment)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Reviews SET Rating = @Rating, Comment = @Comment WHERE ReviewID = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Rating", rating);
                        cmd.Parameters.AddWithValue("@Comment", string.IsNullOrEmpty(comment) ? (object)DBNull.Value : comment);
                        cmd.Parameters.AddWithValue("@Id", reviewId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating review: " + ex.Message);
            }
        }

        public bool DeleteReview(int reviewId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Reviews WHERE ReviewID = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", reviewId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting review: " + ex.Message);
            }
        }
    }
}
