using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class FeedbackDAL
    {
        public bool InsertFeedback(Feedback feedback)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO Feedback (UserID, Rating, Comments) VALUES (@UserID, @Rating, @Comments)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", feedback.UserID);
                        cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                        cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertFeedback: " + ex.Message);
            }
        }

        public DataTable GetAllFeedback()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT f.FeedbackID, u.FullName as UserName, f.Rating, f.Comments, f.FeedbackDate 
                                     FROM Feedback f 
                                     JOIN Users u ON f.UserID = u.UserID 
                                     ORDER BY f.FeedbackDate DESC";
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
                throw new Exception("Error in GetAllFeedback: " + ex.Message);
            }
            return dt;
        }

        public bool DeleteFeedback(int feedbackId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Feedback WHERE FeedbackID = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", feedbackId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting feedback: " + ex.Message);
            }
        }
    }
}
