using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*using System.Web.UI;
using System.Web.UI.WebControls;*/

namespace Auction
{
    /// <summary>
    /// Summary description for login
    /// </summary>
    public class login : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod != "POST") { 
                context.Response.End();
            }
            else
            {
                // User has already authenticated
                if (context.Session["id"] != null) { 
                    context.Response.Redirect("index.aspx");             
                    return;
                }

                 // Determine if authentication is successful
                AuctionDB db = new AuctionDB();
                int userid = db.Authenticate(context.Request.Form["username"], context.Request.Form["password"]);
                if (userid > -1)
                {
                     // User successfully authenticated, log them in by adding the username key to our session
                    context.Session.Add("id", userid);
                    context.Session.Add("username", context.Request.Form["username"]);
                    context.Response.Redirect("index.aspx");
                    return;
                }
                else
                {
                    // User failed to authenticate, kick them out
                    context.Session.Abandon();
                    context.Response.Redirect("index.aspx");   
                    return;
                }
                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}