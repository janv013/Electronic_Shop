using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Electronic_Shop
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is logged in
                if (Session["user_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                // Load hidden fields from query string
                if (Request.QueryString["productid"] != null && Request.QueryString["price"] != null)
                {
                    hfProductID.Value = Request.QueryString["productid"];
                    hfPrice.Value = Request.QueryString["price"];
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            string firstName = fname.Text.Trim();
            string addressText = address.Text.Trim();
            string emailText = email.Text.Trim();
            string mobile = mobileNumber.Text.Trim();

            int quantity;
            decimal price;

            // Input validation
            if (!int.TryParse(quantityTextBox.Text.Trim(), out quantity))
            {
                Response.Write("<script>alert('Invalid quantity');</script>");
                return;
            }

            if (!decimal.TryParse(hfPrice.Value, out price))
            {
                Response.Write("<script>alert('Invalid price');</script>");
                return;
            }

            int userId = Convert.ToInt32(Session["user_id"]);
            int productId = Convert.ToInt32(hfProductID.Value);
            decimal totalAmount = quantity * price;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Orders 
                                (UserID, ProductID, OrderDate, TotalAmount, Status, FirstName, Address, Email, MobileNumber, Quantity) 
                                 VALUES 
                                (@UserID, @ProductID, GETDATE(), @TotalAmount, 'Pending', @FirstName, @Address, @Email, @MobileNumber, @Quantity)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@Address", addressText);
                cmd.Parameters.AddWithValue("@Email", emailText);
                cmd.Parameters.AddWithValue("@MobileNumber", mobile);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("orderconfirmation.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error placing order: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
