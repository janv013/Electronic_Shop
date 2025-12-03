using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Electronic_Shop
{
    public partial class orderhistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect if user is not logged in
                }
                else
                {
                    LoadOrderHistory();
                }
            }
        }

        private void LoadOrderHistory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;
            int userId = Convert.ToInt32(Session["userid"]);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        o.OrderID, 
                        o.TotalAmount, 
                        o.OrderDate, 
                        o.Status, 
                        od.Quantity, 
                        od.Price, 
                        p.ProductName, 
                        p.ImageURL 
                    FROM Orders o
                    JOIN OrderDetails od ON o.OrderID = od.OrderID
                    JOIN Products p ON od.ProductID = p.ProductID
                    WHERE o.UserID = @UserID
                    ORDER BY o.OrderDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rptOrderHistory.DataSource = dt;
                    rptOrderHistory.DataBind();
                }
            }
        }

        protected string GetStatusClass(string status)
        {
            switch (status.ToLower())
            {
                case "pending": return "status-pending";
                case "completed": return "status-completed";
                case "cancelled": return "status-cancelled";
                default: return "";
            }
        }

    }
}