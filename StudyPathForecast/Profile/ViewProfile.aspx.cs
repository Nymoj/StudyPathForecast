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
    public partial class ViewProfile : System.Web.UI.Page
    {
        public User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            user = Connections.GetUser(((User)Session["User"])?.Username);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}