using StudyPathForecast.Database;
using StudyPathForecast.Database.CSModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyPathForecast.Stats
{
    public partial class Forecast : System.Web.UI.Page
    {
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["User"];

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
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "Math5Points");
                link.Text = "מתמטיקה 5 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is4PointsMathStudent)
            {
                link = new HyperLink();
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "Math4Points");
                link.Text = "מתמטיקה 4 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is5PointsEnglishStudent)
            {
                link = new HyperLink();
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "English5Points");
                link.Text = "אנגלית 5 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.Is4PointsEnglishStudent)
            {
                link = new HyperLink();
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "English4Points");
                link.Text = "אנגלית 4 יח'";
                gradeLinks.Controls.Add(link);
            }

            if (userData.IsPhysicsStudent)
            {
                link = new HyperLink();
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "Physics");
                link.Text = "פיזיקה";
                gradeLinks.Controls.Add(link);
            }

            if (userData.IsArtStudent)
            {
                link = new HyperLink();
                link.CssClass = "link";
                link.NavigateUrl = string.Format(linkFormat, "Art");
                link.Text = "אמנות";
                gradeLinks.Controls.Add(link);
            }
        }

        protected void btnSubmitChosenPath_Click(object sender, EventArgs e)
        {
            // if checked, save the choise to db
            if (hasChosenPath.Checked)
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE UserData SET ChosenPath=@ChosenPath WHERE UserID=@ID;", Connections.Connection))
                {
                    cmd.Parameters.AddWithValue("@ChosenPath", chosenPath.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID", user.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}