using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class MessageDAL
    {
        public bool SendMessage(CAR_RENTAL_MANAGEMENT_SYSTEM.Models.Message msg)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO Messages (SenderID, ReceiverID, Subject, MessageBody) 
                                     VALUES (@SenderID, @ReceiverID, @Subject, @MessageBody)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SenderID", msg.SenderID);
                        cmd.Parameters.AddWithValue("@ReceiverID", msg.ReceiverID);
                        cmd.Parameters.AddWithValue("@Subject", msg.Subject);
                        cmd.Parameters.AddWithValue("@MessageBody", msg.MessageBody);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SendMessage: " + ex.Message);
            }
        }

        public DataTable GetMessagesForUser(int userId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT m.MessageID, m.SenderID, m.ReceiverID, m.Subject, m.MessageBody, m.SentDate, m.IsRead, u.FullName as SenderName 
                                     FROM Messages m 
                                     JOIN Users u ON m.SenderID = u.UserID 
                                     WHERE m.ReceiverID = @UserID 
                                     ORDER BY m.SentDate DESC";
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
                throw new Exception("Error in GetMessagesForUser: " + ex.Message);
            }
            return dt;
        }

        public bool MarkAsRead(int messageId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Messages SET IsRead = 1 WHERE MessageID = @MessageID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MessageID", messageId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in MarkAsRead: " + ex.Message);
            }
        }

        public int GetUnreadCount(int userId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Messages WHERE ReceiverID = @UserID AND IsRead = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUnreadCount: " + ex.Message);
            }
        }

        public DataTable GetAllUsersForMessaging()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FullName, Role FROM Users WHERE IsActive = 1 ORDER BY FullName";
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
                throw new Exception("Error in GetAllUsersForMessaging: " + ex.Message);
            }
            return dt;
        }
    }
}
