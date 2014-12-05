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
        public List<ContactInfo> ContactList = new List<ContactInfo>();
        public List<Address> AddressList = new List<Address>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page is only for logged in users
            if (Session["id"] == null)
            {
                Response.Redirect("index.aspx");
            }

            // If there is a post request that contains Form["action"] == "createCC"
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "createCC")
            {
                db.CreateCC((int)Session["id"], (string)Request.Form["owner"], (string)Request.Form["number"], Convert.ToDateTime(Request.Form["expiration"]));
                Response.Write("Credit Card Added!");
            }

            // If there is a post request that contains Form["action"] == "createContactInfo"
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "createContactInfo")
            {
                db.CreateContact((int)Session["id"], (string)Request.Form["phone_number"]);
                Response.Write("Contact Info Added!");
            }

            // If there is a post request that contains Form["action"] == "createAddress"
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "createAddress")
            {
                db.CreateAddress((int)Session["id"], (string)Request.Form["street_number"], (string)Request.Form["street_name"], (string)Request.Form["city"], (string)Request.Form["state"], (string)Request.Form["zip"]);
                Response.Write("Address Added!");
            }

            // Acquire list of current credit cards owned by this user
            CCList = db.GetCCList((int)Session["id"]);

            // Acquire list of current Contact Information owned by this user
            ContactList = db.GetContactList((int)Session["id"]);

            AddressList = db.GetAddressList((int)Session["id"]);

        }
    }
}