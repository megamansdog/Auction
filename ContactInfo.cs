using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    public class ContactInfo
    {
        public int      userid          { get; set; }
        public string   phone_number    { get; set; }

        //Constructor
        public ContactInfo(int userid, string phone_number)
        {
            this.userid         = userid;
            this.phone_number   = phone_number;
        }
    }

    public class Address
    {
        public int      userid          { get; set; }
        public string   street_number   { get; set; }
        public string   street_name     { get; set; }
        public string   city            { get; set; }
        public string   state           { get; set; }
        public string   zip             { get; set; }

        public Address(int userid, string street_number, string street_name, string city, string state, string zip)
        {
            this.userid         = userid;
            this.street_number  = street_number;
            this.street_name    = street_name;
            this.city           = city;
            this.state          = state;
            this.zip            = zip;
        }

    }
}