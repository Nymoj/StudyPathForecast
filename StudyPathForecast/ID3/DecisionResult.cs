using StudyPathForecast.Database.CSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast.ID3
{
    public class DecisionResult : Decision
    {
        public bool Result { get; set; }
        
        public override void Evaluate(UserData user)
        {
            
        }
    }
}