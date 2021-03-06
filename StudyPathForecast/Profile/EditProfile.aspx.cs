using StudyPathForecast.Database;
using StudyPathForecast.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyPathForecast.Profile
{
    public partial class EditProfile : System.Web.UI.Page
    {
        public User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            user = Connections.GetUser(Session["Username"].ToString());
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (pwdPassword.Text != user.Password)
            {
                errorMessage.Text = "סיסמה שגויה";
                return;
            }
        }
    }
}