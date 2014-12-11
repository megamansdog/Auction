using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Auction
{
    /// <summary>
    /// Summary description for bid_add
    /// </summary>
    public class bid_add : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        public AuctionDB db = new AuctionDB();
        public int itemid;
        public double bid_amount;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "POST" && (string)context.Request.Form["action"] == "bid_add")
            {
                string referrer = context.Request.UrlReferrer.AbsoluteUri;
                try
                {
                    if (!Int32.TryParse(context.Request.Form["itemid"], out itemid)) {
                        // If the itemid cannot be parsed into an integer, redirect the user
                        context.Response.Redirect(referrer);
                        return;
                    }
                    if (!Double.TryParse(context.Request.Form["bid_amount"],out bid_amount)){
                        // If the bid amount cannot be parsed into a Double, redirect the user
                        context.Response.Redirect(referrer);
                        return;
                    }
                    else
                    {
                        // If the bid amount is less than 0, redirect the user
                        if (bid_amount < 0) { context.Response.Redirect(referrer); }
                    }

                    // Create the bid
                    db.CreateBid((int)context.Session["id"], itemid, bid_amount, DateTime.Now);
                }
                catch (SqlException SqlEx)
                {
                    if (SqlEx.Number == 2627)
                    {
                        // User already has a bid for this item, update it with the new value
                        db.UpdateBid((int)context.Session["id"], (int)Int32.Parse(context.Request.Form["itemid"]), (double)Double.Parse(context.Request.Form["bid_amount"]), DateTime.Now);
                    }
                    else
                    {
                        // Unknown Exception in the SQL Command
                        context.Response.StatusCode = 400;
                        context.Response.Write("Caught Exception: " + SqlEx.ToString());
                        context.Response.End();
                        return;
                    }
                }
                catch (Exception e)
                {
                    {
                        // Unknown Exception in try block
                        context.Response.StatusCode = 400;
                        context.Response.Write("Caught Exception: " + e.Message + ":<br>" + e.StackTrace.ToString());
                        context.Response.End();
                        return;
                    }
                }
                finally
                {
                    // Redirect the user to the referring uri
                    context.Response.Redirect(referrer);
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