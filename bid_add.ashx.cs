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
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "POST" && (string)context.Request.Form["action"] == "bid_add")
            {
                try
                {
                    db.CreateBid((int)context.Session["id"], (int)Int32.Parse(context.Request.Form["itemid"]), (double)Double.Parse(context.Request.Form["bid_amount"]), DateTime.Now);
                }
                catch (SqlException SqlEx)
                {
                    if (SqlEx.Number == 2627)
                    {
                        context.Response.Write("You have already created a bid for this item. Your bid has been updated.");
                        db.UpdateBid((int)context.Session["id"], (int)Int32.Parse(context.Request.Form["itemid"]), (double)Double.Parse(context.Request.Form["bid_amount"]), DateTime.Now);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Write("Caught Exception: " + SqlEx.ToString());
                        context.Response.End();
                        return;
                    }
                }
                catch (Exception e)
                {
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Write("Caught Exception: " + e.Message + ":<br>" + e.StackTrace.ToString());
                        context.Response.End();
                        return;
                    }
                }
                finally
                {
                    context.Response.Write("Your bid was successful");
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