using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    public class Bid
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int itemid { get; set; }
        public double bid_amount { get; set; }
        public DateTime bid_time { get; set; }

        public Bid(int id, int userid, int itemid, double bid_amount, DateTime bid_time)
        {
            this.id = id;
            this.userid = userid;
            this.itemid = itemid;
            this.bid_amount = bid_amount;
            this.bid_time = bid_time;
        }
    }
}