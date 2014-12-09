using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;

namespace Auction
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public AuctionDB db = new AuctionDB();
        public void ProcessRequest(HttpContext context)
        {
            int imageid;
            Int32.TryParse(context.Request.QueryString["imageid"], out imageid);
            if ((context.Request.HttpMethod == "GET") && (imageid > 0))
            {
                Picture currentPic = db.GetItemPicture(imageid);
                if (currentPic == null) { context.Response.StatusCode = 404; context.Response.End(); }
                context.Response.BinaryWrite(currentPic.image_data);
                context.Response.ContentType = "image/jpeg";
            }
            else
            {
                context.Response.StatusCode = 404;
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