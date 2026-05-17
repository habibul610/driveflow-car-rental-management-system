using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class UserDAL
    {
        public User GetUserByUsername(string username)
        {
            User user = null;
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                if (role == "Admin")
                                {
                                    user = new Admin();
                                }
                                else if (role == "Manager")
                                {
                                    user = new Manager();
                                }
                                else
                                {
                                    user = new Customer();
                                }
                                
                                user.UserID = Convert.ToInt32(reader["UserID"]);
                                user.FullName = reader["FullName"].ToString();
                                user.Username = reader["Username"].ToString();
                                user.Email = reader["Email"].ToString();
                                user.Phone = reader["Phone"].ToString();
                                user.PasswordHash = reader["PasswordHash"].ToString();
                                user.Role = role;
                                user.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                                user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUserByUsername: " + ex.Message);
            }
            return user;
        }

        public User GetUserByID(int userId)
        {
            User user = null;
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                if (role == "Admin")
                                {
                                    user = new Admin();
                                }
                                else if (role == "Manager")
                                {
                                    user = new Manager();
                                }
                                else
                                {
                                    user = new Customer();
                                }
                                
                                user.UserID = Convert.ToInt32(reader["UserID"]);
                                user.FullName = reader["FullName"].ToString();
                                user.Username = reader["Username"].ToString();
                                user.Email = reader["Email"].ToString();
                                user.Phone = reader["Phone"].ToString();
                                user.PasswordHash = reader["PasswordHash"].ToString();
                                user.Role = role;
                                user.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                                user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUserByID: " + ex.Message);
            }
            return user;
        }

        public bool UsernameExists(string username)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error checking username availability: " + ex.Message);
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash, Role) 
                                     VALUES (@FullName, @Username, @Email, @Phone, @PasswordHash, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Phone", user.Phone);
                        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        cmd.Parameters.AddWithValue("@Role", user.Role);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertUser: " + ex.Message);
            }
        }

        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FullName, Username, Email, Phone, RegistrationDate FROM Users WHERE Role = 'Customer' AND IsActive = 1";
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
                throw new Exception("Error in GetAllCustomers: " + ex.Message);
            }
            return dt;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteUser: " + ex.Message);
            }
        }

        public bool UpdateUserProfile(int userId, string fullName, string email, string phone, string passwordHash)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Users SET FullName = @FullName, Email = @Email, Phone = @Phone";
                    if (!string.IsNullOrEmpty(passwordHash))
                    {
                        query += ", PasswordHash = @PasswordHash";
                    }
                    query += " WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        if (!string.IsNullOrEmpty(passwordHash))
                        {
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        }

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateUserProfile: " + ex.Message);
            }
        }
    }
}
