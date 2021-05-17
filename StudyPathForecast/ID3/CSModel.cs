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

        // None (No grades or doesn't learn the subject)| Low (0-60) | Normal (60-80) | High (80-100)
        public string Math5Avg { get; set; }
        public string Math4Avg { get; set; }

        public string English5Avg { get; set; }
        public string English4Avg { get; set; }

        public string PhysicsAvg { get; set; }
        public string ArtAvg { get; set; }

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
        public static Func<CSModel, bool> Success = (x => x.ChosenPath == "CS");
        // Used in the tree as an indicator
        public static string Positive = "Yes";
        public static string Negative = "No";

        public CSModel()
        {

        }

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

                case "Math5Avg":
                    return Math5Avg;
                case "Math4Avg":
                    return Math4Avg;

                case "English5Avg":
                    return English5Avg;
                case "English4Avg":
                    return English4Avg;

                case "PhysicsAvg":
                    return PhysicsAvg;
                case "ArtAvg":
                    return ArtAvg;

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
        private static string BoolToString(object val)
        {
            return Convert.ToBoolean(val) ? "Yes" : "No";
        }

        public static List<CSModel> GetData()
        {
            return InitData();
        }
    }
}