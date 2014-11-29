using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    /// <summary>
    /// Summary description for login
    /// </summary>
    public class login : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            if (context.Request.HttpMethod != "POST") { context.Response.Write("You made a non-post request."); }
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