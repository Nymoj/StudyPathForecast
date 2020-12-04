using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StudyPathForecast
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            string continueUrl = Request.QueryString["ReturnUrl"];

            FormsAuthentication.SetAuthCookie(LoginWiz.UserName, false);

            if (string.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }

            Response.Redirect(continueUrl);
        }
    }
}