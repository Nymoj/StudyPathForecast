using StudyPathForecast.Database;
using StudyPathForecast.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyPathForecast.Stats.Questions
{
    public partial class Preferences : System.Web.UI.Page
    {
        private UserData userData;

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            if (user == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            userData = Connections.GetUserData(user);

            // showing the stored settings
            Math5.SelectedIndex = userData.Is5PointsMathStudent ? 0 : 1;
            Math4.SelectedIndex = userData.Is4PointsMathStudent ? 0 : 1;

            English5.SelectedIndex = userData.Is5PointsEnglishStudent ? 0 : 1;
            English4.SelectedIndex = userData.Is4PointsEnglishStudent ? 0 : 1;

            Physics.SelectedIndex = userData.IsPhysicsStudent ? 0 : 1;

            Art.SelectedIndex = userData.IsArtStudent ? 0 : 1;
        }

        protected void Math5_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.Is5PointsMathStudent = Convert.ToBoolean(Math5.SelectedIndex);
        }

        protected void Math4_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.Is4PointsMathStudent = Convert.ToBoolean(Math4.SelectedIndex);
        }

        protected void English5_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.Is5PointsEnglishStudent = Convert.ToBoolean(English5.SelectedIndex);
        }

        protected void English4_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.Is4PointsEnglishStudent = Convert.ToBoolean(English4.SelectedIndex);
        }

        protected void Physics_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.IsPhysicsStudent = Convert.ToBoolean(Physics.SelectedIndex);
        }

        protected void Art_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData.IsArtStudent = Convert.ToBoolean(Art.SelectedIndex);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!Connections.InsertUserData(userData))
            {
                return;
            }

            Response.Redirect("~/Stats/Forecast.aspx");
        }
    }
}