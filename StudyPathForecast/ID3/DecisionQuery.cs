using StudyPathForecast.Database.CSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast.ID3
{
    public class DecisionQuery : Decision
    {
        public string Title { get; set; }
        public Decision Positive { get; set; }
        public Decision Negative { get; set; }
        public Func<User, bool> Test { get; set; }

        public override void Evaluate(UserData user)
        {
            throw new NotImplementedException();
        }
    }
}