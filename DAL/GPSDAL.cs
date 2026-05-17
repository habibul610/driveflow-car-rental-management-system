using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class GPSDAL
    {
        public bool InsertLog(GPSLog log)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"INSERT INTO GPSLogs (CarID, Latitude, Longitude, Speed) 
                                     VALUES (@CarID, @Latitude, @Longitude, @Speed)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", log.CarID);
                        cmd.Parameters.AddWithValue("@Latitude", log.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", log.Longitude);
                        cmd.Parameters.AddWithValue("@Speed", log.Speed);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertLog: " + ex.Message);
            }
        }

        public DataTable GetLatestLogs()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT g.*, c.Brand + ' ' + c.Model as CarDetails 
                                     FROM GPSLogs g 
                                     JOIN Cars c ON g.CarID = c.CarID 
                                     WHERE g.LogDate = (SELECT MAX(LogDate) FROM GPSLogs WHERE CarID = g.CarID)
                                     ORDER BY g.LogDate DESC";
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
                throw new Exception("Error in GetLatestLogs: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetHistoryForCar(int carId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM GPSLogs WHERE CarID = @CarID ORDER BY LogDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetHistoryForCar: " + ex.Message);
            }
            return dt;
        }
    }
}
