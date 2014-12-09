﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction
{
    public partial class index : System.Web.UI.Page
    {
        public List<Item> ItemList = new List<Item>();
        public AuctionDB db = new AuctionDB();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                this.MasterPageFile = "~/blank.master";
            }
            else
            {
                ItemList = db.GetAllItemList();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /*
        protected void SubmitForm(object sender, EventArgs e)
        {
            Session["username"] = username.Value;
            Session.Timeout = 1;
        }
         * */

    }
}