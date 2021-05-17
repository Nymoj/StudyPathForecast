using StudyPathForecast.Database;
using StudyPathForecast.Database.CSModels;
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
            if (Session["User"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            user = Connections.GetUser(((User)Session["User"])?.Username);
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (pwdPassword.Text != user.Password)
            {
                errorMessage.Text = "סיסמה שגויה";
                return;
            }


            if (!string.IsNullOrEmpty(txtNewEmail.Text))
            {
                Connections.UpdateUserEmail(user.Username, txtNewEmail.Text);
            }

            if (!string.IsNullOrEmpty(pwdNewPassword.Text))
            {
                Connections.UpdateUserPassword(user.Username, pwdNewPassword.Text);
            }
        }
    }
}