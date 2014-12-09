using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        public AuctionDB db = new AuctionDB();
        public Item item;
        public List<Picture> ItemPictureList;

        protected void Page_Load(object sender, EventArgs e)
        {
            int itemid;
            Int32.TryParse(Request.QueryString["itemid"], out itemid);
            if ((Request.HttpMethod == "GET") && (itemid > 0))
            {
                item = db.GetItem(itemid);
                if ( item == null ) { Response.StatusCode = 404; Response.End(); }
                ItemPictureList = db.GetItemPictureList(itemid);
                Page.Title = item.name;
            } else {
                Response.StatusCode = 404;
                Response.End();
            }
        }
    }
}