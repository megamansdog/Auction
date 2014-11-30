using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prevent logged in users from accessing the registration page
            if (Session["id"] != null) { Response.Redirect("./index.aspx"); return; }

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                AuctionDB db = new AuctionDB();
                try
                {
                    db.CreateUser(Request.Form["username"], Request.Form["password"], Request.Form["email"]);
                    Response.Write("Username " + Request.Form["username"] + " was added to the database.");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                /*
                foreach (string key in Request.Form.AllKeys)
                {
                    
                }
                 */
            }
        }

            
        // Submit Button
        protected void SubmitForm(object sender, EventArgs e)
        {
            //Response.Write("Test");
        }
    }
}