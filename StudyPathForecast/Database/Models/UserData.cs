using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast.Database.CSModels
{
    public class UserData
    {
        public int UserId { get; set; }
        
        // Studied subjects
        public bool Is5PointsMathStudent { get; set; }
        public bool Is4PointsMathStudent { get; set; }

        public bool Is5PointsEnglishStudent { get; set; }
        public bool Is4PointsEnglishStudent { get; set; }

        public bool IsPhysicsStudent { get; set; }
        public bool IsArtStudent { get; set; }

        public UserData(int userId)
        {
            UserId = userId;

            Is5PointsMathStudent = false;
            Is4PointsMathStudent = false;

            Is5PointsEnglishStudent = false;
            Is4PointsEnglishStudent = false;

            IsPhysicsStudent = false;
            IsArtStudent = false;
        }
    }
}