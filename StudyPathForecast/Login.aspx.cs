﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StudyPathForecast.Database;

namespace StudyPathForecast
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            if (!Connections.UserExists(txtUsername.Text, pwdPassword.Text))
            {
                errorMessage.Text = "פרטים שגויים";
                return;
            }

            Session["Username"] = txtUsername.Text;

            Response.Redirect("~/Default.aspx");
        }
    }
}