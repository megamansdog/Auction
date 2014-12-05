using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public AuctionDB db = new AuctionDB();
        public List<CCInfo> CCList = new List<CCInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page is only for logged in users
            if (Session["id"] == null)
            {
                Response.Redirect("index.aspx");
            }

            // Acquire list of current credit cards owned by this user
            CCList = db.GetCCList((int)Session["id"]);


            // If there is a post request that contains Form["action"] == "createCC"
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "createCC")
            {
                db.CreateCC((int)Session["id"], (string)Request.Form["owner"], (string)Request.Form["number"], Convert.ToDateTime(Request.Form["expiration"]));
                Response.Write("Credit Card Added!");
            }
        }
    }
}