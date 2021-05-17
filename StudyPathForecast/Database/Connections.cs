using StudyPathForecast.Database.CSModels;
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
            // SELECT * FROM Users WHERE Username=@Username;
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
                    user.Id = Convert.ToInt32(dr["ID"]);
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
            // SELECT * FROM Users WHERE Username=@Username AND Password=@Password;
            SqlCommand cmd = new SqlCommand("userPasswordMatches", Connection);
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

        public static UserData GetUserData(User user)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE UserID=(SELECT ID FROM Users WHERE Username=@Username)", Connection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Username", user.Username);

            UserData userData = new UserData(user.Id);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    // assigning math
                    userData.Is5PointsMathStudent = Convert.ToBoolean(dr["Is5PointsMathStudent"]);
                    userData.Is4PointsMathStudent = Convert.ToBoolean(dr["Is4PointsMathStudent"]);
                    // assigning english
                    userData.Is5PointsEnglishStudent = Convert.ToBoolean(dr["Is5PointsEnglishStudent"]);
                    userData.Is4PointsEnglishStudent = Convert.ToBoolean(dr["Is4PointsEnglishStudent"]);
                    // assigning physics
                    userData.IsPhysicsStudent = Convert.ToBoolean(dr["IsPhysicsStudent"]);
                    // assigning art
                    userData.IsArtStudent = Convert.ToBoolean(dr["IsArtStudent"]);
                    // assigning user id
                    userData.UserId = Convert.ToInt32(dr["UserID"]);
                }
            }

            return userData;
        }

        public static bool InsertUserData(UserData userData)
        {
            SqlCommand cmd = new SqlCommand("InsertUserData", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userData.UserId);
            // math
            cmd.Parameters.AddWithValue("@Is5PointsMathStudent", userData.Is5PointsMathStudent);
            cmd.Parameters.AddWithValue("@Is4PointsMathStudent", userData.Is4PointsMathStudent);
            // english
            cmd.Parameters.AddWithValue("@Is5PointsEnglishStudent", userData.Is5PointsEnglishStudent);
            cmd.Parameters.AddWithValue("@Is4PointsEnglishStudent", userData.Is4PointsEnglishStudent);
            // physics
            cmd.Parameters.AddWithValue("@IsPhysicsStudent", userData.IsPhysicsStudent);
            // art
            cmd.Parameters.AddWithValue("@IsArtStudent", userData.IsArtStudent);

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

        public static bool UpdateUserData(UserData userData)
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserData SET Is5PointsMathStudent=@Is5PointsMathStudent, Is4PointsMathStudent=@Is4PointsMathStudent, Is5PointsEnglishStudent=@Is5PointsEnglishStudent, Is4PointsEnglishStudent=@Is4PointsEnglishStudent, IsPhysicsStudent=@IsPhysicsStudent, IsArtStudent=@IsArtStudent WHERE UserID=@ID;", Connection);

            cmd.Parameters.AddWithValue("@ID", userData.UserId);
            // math
            cmd.Parameters.AddWithValue("@Is5PointsMathStudent", userData.Is5PointsMathStudent);
            cmd.Parameters.AddWithValue("@Is4PointsMathStudent", userData.Is4PointsMathStudent);
            // english
            cmd.Parameters.AddWithValue("@Is5PointsEnglishStudent", userData.Is5PointsEnglishStudent);
            cmd.Parameters.AddWithValue("@Is4PointsEnglishStudent", userData.Is4PointsEnglishStudent);
            // physics
            cmd.Parameters.AddWithValue("@IsPhysicsStudent", userData.IsPhysicsStudent);
            // art
            cmd.Parameters.AddWithValue("@IsArtStudent", userData.IsArtStudent);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            SqlCommand updateGrades = new SqlCommand("DELETE FROM Grades WHERE UserId=@UserId AND Subject=@Subject;", Connections.Connection);

            updateGrades.Parameters.Add("@UserId", typeof(int));
            updateGrades.Parameters.Add("@Subject", typeof(string));

            if (!userData.Is5PointsMathStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "Math5Points";
                updateGrades.ExecuteNonQuery();
            }
            if (!userData.Is4PointsMathStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "Math4Points";
                updateGrades.ExecuteNonQuery();
            }

            if (!userData.Is5PointsEnglishStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "English5Points";
            }
            if (!userData.Is4PointsEnglishStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "English4Points";
            }

            if (!userData.IsPhysicsStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "Physics";
            }
            if (!userData.IsArtStudent)
            {
                updateGrades.Parameters["@UserID"].Value = userData.UserId;
                updateGrades.Parameters["@Subject"].Value = "Art";
            }

            return true;
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