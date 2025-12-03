using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Electronic_Shop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPassword.Attributes["type"] = "password"; // Hide password by default
            }
        }

        protected void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Attributes["type"] = chkShowPassword.Checked ? "text" : "password";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id, user_name FROM register WHERE email_id = @Email AND password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string userName = reader["user_name"].ToString();

                    // Store user session
                    Session["UserID"] = userId;
                    Session["UserName"] = userName;

                    // Redirect to dashboard
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }

                reader.Close();
            }
        }
    }
}