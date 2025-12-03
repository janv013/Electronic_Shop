using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electronic_Shop
{
    public partial class orderconfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["order_id"] != null)
                {
                    lblOrderID.Text = Request.QueryString["order_id"];
                }
                else
                {
                    lblOrderID.Text = "N/A";
                }
            }
        }
    }
}