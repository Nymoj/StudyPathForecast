using StudyPathForecast.Database;
using StudyPathForecast.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyPathForecast.Stats
{
    public partial class Forecast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            if (user == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            UserData userData = Connections.GetUserData(user);
            HyperLink link = null;
            string linkFormat = "~/Stats/Grades/{0}";

            if (userData.Is5PointsMathStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "Math5Points");
                link.Text = "מתמטיקה 5 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is4PointsMathStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "Math4Points");
                link.Text = "מתמטיקה 4 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is5PointsEnglishStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "English5Points");
                link.Text = "אנגלית 5 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is4PointsEnglishStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "English4Points");
                link.Text = "אנגלית 4 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.IsPhysicsStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "Physics");
                link.Text = "פיזיקה";
                gradeLinks.Controls.Add(link);
            }

            if (userData.IsArtStudent)
            {
                link = new HyperLink();
                link.NavigateUrl = string.Format(linkFormat, "Art");
                link.Text = "אמנות";
                gradeLinks.Controls.Add(link);
            }
        }
    }
}