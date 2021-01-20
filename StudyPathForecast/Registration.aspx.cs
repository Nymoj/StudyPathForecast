﻿using System;
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
            
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudyPathForecastDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", pwdPassword.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("~/Default.aspx");
        }
    }
}