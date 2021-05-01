
using StudyPathForecast.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast
{
    public abstract class Decision
    {
        public abstract void Evaluate(User user);
    }
}