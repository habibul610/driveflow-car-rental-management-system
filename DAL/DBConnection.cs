using Microsoft.Data.SqlClient;
using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.DAL
{
    public class DBConnection
    {
        // Update the Server value to match your SSMS instance name
        private static readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=CarRentingDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
