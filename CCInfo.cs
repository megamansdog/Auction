using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    public class CCInfo
    {
        public int userid { get; set; }
        public string owner { get; set; }
        public string number { get; set; }
        public DateTime expiration { get; set; }

        //Constructor
        public CCInfo(int userid, string owner, string number, DateTime expiration)
        {
            this.userid = userid;
            this.owner = owner;
            this.number = number;
            this.expiration = expiration.Date;
        }
    }
}