using StudyPathForecast.Database;
using StudyPathForecast.Database.CSModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyPathForecast.Stats.Grades
{
    public partial class Math5Points : System.Web.UI.Page
    {
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["User"];    

            if (user == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            SqlDataReader dr;

            using (SqlCommand cmd = new SqlCommand("SELECT Grade, Date FROM Grades WHERE UserID=@UserID AND Subject=@Subject;", Connections.Connection))
            {
                cmd.Parameters.AddWithValue("@UserID", user.Id);
                cmd.Parameters.AddWithValue("@Subject", "Math5Points");
                dr = cmd.ExecuteReader();
                gvGrades.DataSource = dr;
                gvGrades.DataBind();
            }

            dr.Close();

            lblAvg.Text = Connections.CalculateGradeAvg(user.Id, "Math5Points");
        }

        protected void btnSubmitGrade_Click(object sender, EventArgs e)
        {
            int grade = 0;

            if (string.IsNullOrEmpty(txtGrade.Text))
            {
                errorMessage.Text = "חובה להזין ציון";
                return;
            }
            
            if (!int.TryParse(txtGrade.Text, out grade))
            {
                errorMessage.Text = "חובה להזין מספר (בין 0 ל100)";
                return;
            }

            if (grade < 0 || grade > 100)
            {
                errorMessage.Text = "חובה להזין מספר בין 0 ל100";
                return;
            }

            errorMessage.Text = "";

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Grades (UserID, Subject, Grade, Date) VALUES (@UserID, @Subject, @Grade, @Date);", Connections.Connection))
            {
                cmd.Parameters.AddWithValue("@UserID", user.Id);
                cmd.Parameters.AddWithValue("@Subject", "Math5Points");
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Date", DateTime.Today);

                cmd.ExecuteNonQuery();
            }

            txtGrade.Text = string.Empty;
            Response.Redirect("Math5Points.aspx", false);
        }
    }
}