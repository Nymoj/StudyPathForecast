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

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static bool UsernameExists(string username)
        {
            SqlCommand cmd = new SqlCommand("UsernameExists", Connections.Connection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static User GetUser(string username)
        {
            User user = new User();

            SqlCommand cmd = new SqlCommand("GetUser", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    user.Username = dr["Username"].ToString();
                    user.Password = dr["Password"].ToString();
                    user.Email = dr["Email"].ToString();
                    user.CreatedAt = Convert.ToDateTime(dr["CreatedAt"]);
                }
            }

            return user;
        }

        /// <summary>
        /// Checks if provided password matches user's password
        /// </summary>
        /// <param name="username">The user to be checked</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        public static bool UserPasswordMatch(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("userPasswordMatches", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        #region Updating User's Data Methods

        /// <summary>
        /// Updates user's email
        /// </summary>
        /// <param name="username">The user to be updated</param>
        /// <param name="email">The new email</param>
        /// <returns></returns>
        public static bool UpdateUserEmail(string username, string email)
        {
            SqlCommand cmd = new SqlCommand("UpdateEmail", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates user's email
        /// </summary>
        /// <param name="username">The user to be updated</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool UpdateUserPassword(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("UpdatePassword", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        #endregion
    }
}