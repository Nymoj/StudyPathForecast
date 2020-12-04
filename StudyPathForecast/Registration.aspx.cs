using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StudyPathForecast
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }

            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false);

            if (string.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }

            Response.Redirect(continueUrl);
        }
    }
}