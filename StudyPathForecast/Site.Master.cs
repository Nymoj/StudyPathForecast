using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Web.Security;

namespace StudyPathForecast
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                unauthenticatedMenu.Visible = false;
            }
            else
            {
                authenticatedMenu.Visible = false;
            }
        }
    }
}