using StudyPathForecast.Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyPathForecast.Database
{
    public static class Connections
    {
        public static SqlConnection Connection { get; set; }

        public static void Initiate()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudyPathForecastDB"].ConnectionString);
            Connection.Open();
        }

        public static void Destroy()
        {
            Connection.Close();
        }

        public static bool InsertUser(User user)
        {
            using (SqlCommand cmd = new SqlCommand("InsertUser", Connections.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }

            return true;
        }

        public static bool UserExists(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("UserExists", Connections.Connection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}