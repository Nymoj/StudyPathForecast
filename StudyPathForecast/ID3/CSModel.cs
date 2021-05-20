using StudyPathForecast.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyPathForecast.ID3
{
    public class CSModel
    {
        public string Is5PointsMathStudent { get; set; }
        public string Is4PointsMathStudent { get; set; }

        public string Is5PointsEnglishStudent { get; set; }
        public string Is4PointsEnglishStudent { get; set; }

        public string IsPhysicsStudent { get; set; }
        public string IsArtStudent { get; set; }

        public string ChosenPath { get; set; }

        // the attributes (columns) used by ID3 to predict the target variable
        public static List<string> PredictiveProperties = new List<string>() {
            "Is5PointsMathStudent",
            "Is4PointsMathStudent",
            "Is5PointsEnglishStudent",
            "Is4PointsEnglishStudent",
            "IsPhysicsStudent",
            "IsArtStudent"
        };
        // Used to check if a CSModel stands for the desired value
        // In our case, the succes is when student has chosen the CS path
        public static Func<CSModel, bool> Success = (x => x.ChosenPath == "CS");
        // Used in the tree as an indicator
        public static string Positive = "Yes";
        public static string Negative = "No";

        public string ValueByField(string field)
        {
            switch (field)
            {
                case "Is5PointsMathStudent":
                    return Is5PointsMathStudent;
                case "Is4PointsMathStudent":
                    return Is4PointsMathStudent;

                case "Is5PointsEnglishStudent":
                    return Is5PointsEnglishStudent;
                case "Is4PointsEnglishStudent":
                    return Is4PointsEnglishStudent;

                case "IsPhysicsStudent":
                    return IsPhysicsStudent;
                case "IsArtStudent":
                    return IsArtStudent;

                default:
                    return "Error";
            }
        }

        private static List<CSModel> InitData()
        {
            List<CSModel> data = new List<CSModel>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE ChosenPath IS NOT NULL;", Connections.Connection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    CSModel model = new CSModel();

                    // assigning math
                    model.Is5PointsMathStudent = BoolToString(dr["Is5PointsMathStudent"]);
                    model.Is4PointsMathStudent = BoolToString(dr["Is4PointsMathStudent"]);
                    // assigning english
                    model.Is5PointsEnglishStudent = BoolToString(dr["Is5PointsEnglishStudent"]);
                    model.Is4PointsEnglishStudent = BoolToString(dr["Is4PointsEnglishStudent"]);
                    // assigning physics
                    model.IsPhysicsStudent = BoolToString(dr["IsPhysicsStudent"]);
                    // assigning art
                    model.IsArtStudent = BoolToString(dr["IsArtStudent"]);

                    model.ChosenPath = Convert.ToString(dr["ChosenPath"]);

                    data.Add(model);
                }
            }

            return data;
        }

        /// <summary>
        /// Converts boolean to yes or no (Implementation techs)
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string BoolToString(object val)
        {
            return Convert.ToBoolean(val) ? "Yes" : "No";
        }

        public static List<CSModel> GetData()
        {
            return InitData();
        }
    }
}