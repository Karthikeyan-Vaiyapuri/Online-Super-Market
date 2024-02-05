using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Fresh_Express.Models
{
    public static class DbHelper
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-PHJ7G0T\SQLEXPRESS;Initial Catalog=Fresh_Express;Integrated Security=True";

        public static int InsertUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password); ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}