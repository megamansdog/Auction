using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    /// <summary>
    /// Summary description for bid_add
    /// </summary>
    public class bid_add : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        public AuctionDB db = new AuctionDB();
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "POST" && (string)context.Request.Form["action"] == "bid_add")
            {
                try
                {
                    db.CreateBid((int)context.Session["id"], (int)Int32.Parse(context.Request.Form["itemid"]), (double)Double.Parse(context.Request.Form["bid_amount"]), DateTime.Now);
                }
                catch (Exception e)
                {
                    context.Response.Write("Caught Exception: " + e.Message + ":<br>" + e.StackTrace.ToString());
                    context.Response.End();
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