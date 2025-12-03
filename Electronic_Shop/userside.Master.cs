using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electronic_Shop
{
    public partial class userside : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            {
             //   if (litUserOptions != null) // ✅ Check if it is not null
                {
               //     LoadUserOptions();
                }
            }
        }
        protected string GetActiveClass(string pageName)
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return currentPage.Equals(pageName, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }

        private void LoadUserOptions()
        {
            if (Session["UserID"] != null && Session["UserName"] != null)
            {
                string userName = Session["UserName"].ToString();
                litUserOptions.Text = $@"
            <div class='dropdown'>
                <button class='btn btn-secondary dropdown-toggle' type='button' id='dropdownMenuButton' data-bs-toggle='dropdown' aria-expanded='false'>
                    {userName}
                </button>
                <ul class='dropdown-menu' aria-labelledby='dropdownMenuButton'>
                    <li><a class='dropdown-item' href='userprofile.aspx'>Profile</a></li>
                    <li><a class='dropdown-item' href='orderhistory.aspx'>My Order History</a></li>
                    <li><a class='dropdown-item' href='Logout.aspx'>Logout</a></li>
                </ul>
            </div>";
            }
            else
            {
                litUserOptions.Text = "<a href='Login.aspx' class='btn btn-primary'>Login</a>";
            }
        }
    }
}