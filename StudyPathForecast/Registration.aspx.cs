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
using StudyPathForecast.Database.CSModels;
using StudyPathForecast.Database;

namespace StudyPathForecast
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            if (Connections.UsernameExists(txtUsername.Text))
            {
                registrationError.Text = String.Format("שם משתמש \"{0}\" כבר נמצא בשימוש", txtUsername.Text);
                return;
            }

            User user = new User(txtUsername.Text, pwdPassword.Text, txtEmail.Text);
            if (!Connections.InsertUser(user))
            {
                registrationError.Text = "קרתה תקלה בתהליך ההרשמה, תחכה ותנסה שוב";
                return;
            }

            // getting the id of the user assigned by the DB
            UserData userData = new UserData(Connections.GetUser(user.Username).Id);

            if (!Connections.InsertUserData(userData))
            {
                registrationError.Text = "קרתה תקלה בתהליך ההרשמה, תחכה ותנסה שוב";
                return;
            }

            //Session["Username"] = txtUsername.Text;
            Session["User"] = Connections.GetUser(txtUsername.Text);

            Response.Redirect("~/Default.aspx");
        }
    }
}