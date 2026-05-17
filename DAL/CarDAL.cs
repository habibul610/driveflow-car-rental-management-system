using CAR_RENTAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class CarDAL
    {
        public DataTable GetAllCars()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT CarID, Brand, Model, Year, Color, PlateNumber, DailyRate, Status, ImagePath, CarDetails FROM Cars";
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
                throw new Exception("Error in GetAllCars: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetAvailableCars()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT CarID, Brand, Model, Year, Color, PlateNumber, DailyRate, ImagePath, CarDetails FROM Cars WHERE Status = 'Available'";
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
                throw new Exception("Error in GetAvailableCars: " + ex.Message);
            }
            return dt;
        }

        public async Task<DataTable> GetAvailableCarsAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    await con.OpenAsync();
                    string query = "SELECT CarID, Brand, Model, Year, Color, PlateNumber, DailyRate, ImagePath, CarDetails FROM Cars WHERE Status = 'Available'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAvailableCarsAsync: " + ex.Message);
            }
            return dt;
        }

        public Car GetCarByID(int carId)
        {
            Car car = null;
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM Cars WHERE CarID = @CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                car = new Car
                                {
                                    CarID = Convert.ToInt32(reader["CarID"]),
                                    Brand = reader["Brand"].ToString(),
                                    Model = reader["Model"].ToString(),
                                    Year = Convert.ToInt32(reader["Year"]),
                                    Color = reader["Color"].ToString(),
                                    PlateNumber = reader["PlateNumber"].ToString(),
                                    DailyRate = Convert.ToDecimal(reader["DailyRate"]),
                                    Status = reader["Status"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : null,
                                    CarDetails = reader["CarDetails"] != DBNull.Value ? reader["CarDetails"].ToString() : null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetCarByID: " + ex.Message);
            }
            return car;
        }

        public bool InsertCar(Car car)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO Cars (Brand, Model, Year, Color, PlateNumber, DailyRate, Status, ImagePath, CarDetails) VALUES (@Brand, @Model, @Year, @Color, @PlateNumber, @DailyRate, @Status, @ImagePath, @CarDetails)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Brand", car.Brand);
                        cmd.Parameters.AddWithValue("@Model", car.Model);
                        cmd.Parameters.AddWithValue("@Year", car.Year);
                        cmd.Parameters.AddWithValue("@Color", car.Color);
                        cmd.Parameters.AddWithValue("@PlateNumber", car.PlateNumber);
                        cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
                        cmd.Parameters.AddWithValue("@Status", car.Status);
                        cmd.Parameters.AddWithValue("@ImagePath", (object)car.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CarDetails", (object)car.CarDetails ?? DBNull.Value);
                        
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in InsertCar: " + ex.Message);
            }
        }

        public bool UpdateCar(Car car)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Cars SET Brand=@Brand, Model=@Model, Year=@Year, Color=@Color, PlateNumber=@PlateNumber, DailyRate=@DailyRate, Status=@Status, ImagePath=@ImagePath, CarDetails=@CarDetails WHERE CarID=@CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Brand", car.Brand);
                        cmd.Parameters.AddWithValue("@Model", car.Model);
                        cmd.Parameters.AddWithValue("@Year", car.Year);
                        cmd.Parameters.AddWithValue("@Color", car.Color);
                        cmd.Parameters.AddWithValue("@PlateNumber", car.PlateNumber);
                        cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
                        cmd.Parameters.AddWithValue("@Status", car.Status);
                        cmd.Parameters.AddWithValue("@ImagePath", (object)car.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CarDetails", (object)car.CarDetails ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CarID", car.CarID);
                        
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateCar: " + ex.Message);
            }
        }

        public bool UpdateCarStatus(int carId, string status)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Cars SET Status = @Status WHERE CarID = @CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateCarStatus: " + ex.Message);
            }
        }

        public bool DeleteCar(int carId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Cars WHERE CarID = @CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteCar: " + ex.Message);
            }
        }
        
        public bool IsCarRented(int carId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Cars WHERE CarID = @CarID AND Status = 'Rented'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error checking car rental status: " + ex.Message);
            }
        }
        public bool UpdateCarImagePath(int carId, string imagePath)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "UPDATE Cars SET ImagePath = @ImagePath WHERE CarID = @CarID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                        cmd.Parameters.AddWithValue("@CarID", carId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateCarImagePath: " + ex.Message);
            }
        }
    }
}
