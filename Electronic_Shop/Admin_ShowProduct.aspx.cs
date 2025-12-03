using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Electronic_Shop
{
    public partial class Admin_ShowProduct : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT ProductID, ProductName, Price, Quantity FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int productId = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Edit")
                {
                    Response.Redirect($"Admin_AddProduct.aspx?product_id={productId}");
                }
                else if (e.CommandName == "Delete")
                {
                    DeleteProduct(productId);
                }
            }
        }

        //private void DeleteProduct(int productId)
        
            private void DeleteProduct(int productId)
            {
                string connString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    try
                    {
                        // Step 1: Delete related OrderDetails
                        string deleteOrderDetailsQuery = "DELETE FROM OrderDetails WHERE ProductID = @ProductID";
                        using (SqlCommand cmd = new SqlCommand(deleteOrderDetailsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            cmd.ExecuteNonQuery();
                        }

                        // Step 2: Delete the Product
                        string deleteProductQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                        using (SqlCommand cmd = new SqlCommand(deleteProductQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            cmd.ExecuteNonQuery();
                        }

                        LoadProducts(); // Refresh GridView
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error deleting product: {ex.Message}');</script>");
                    }
                }
            }

        }
    }

