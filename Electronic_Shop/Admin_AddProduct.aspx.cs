using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Electronic_Shop
{
    public partial class Admin_AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["product_id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["product_id"]);
                    LoadProductDetails(productId);
                    btnAddProduct.Text = "Update Product"; // Change button text to 'Update'
                }
                else
                {
                    btnAddProduct.Text = "Add Product"; // Set button text to 'Add'
                }
            }
        }

        // Load product details into the form
        private void LoadProductDetails(int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductName, Price, Quantity FROM Products WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtProductName.Text = reader["ProductName"].ToString();
                        txtPrice.Text = reader["Price"].ToString();
                        txtQuantity.Text = reader["Quantity"].ToString();
                    }
                }
            }
        }
            protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["es"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Check if we are updating an existing product
                if (Request.QueryString["product_id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["product_id"]);
                    cmd.CommandText = @"UPDATE Products 
                                        SET ProductName = @ProductName, 
                                            Price = @Price, 
                                            Quantity = @Quantity, 
                                            ImageUrl = @ImageUrl 
                                        WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Products (ProductName, Price, Quantity, ImageUrl) 
                                        VALUES (@ProductName, @Price, @Quantity, @ImageUrl)";
                }

                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@ImageUrl", txtImageUrl.Text);

                cmd.ExecuteNonQuery();

                if (Request.QueryString["product_id"] != null)
                {
                    Response.Write("<script>alert('Product updated successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Product added successfully!');</script>");
                }

                // Redirect back to product list page
                Response.Redirect("Admin_ShowProduct.aspx");
            }
        }
    }
}