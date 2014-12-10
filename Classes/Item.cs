using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string condition { get; set; }
        public int initial_price { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }

        public Item(int id, string name, string condition, int initial_price, string description, int quantity, DateTime start_time, DateTime end_time)
        {
            this.id = id;
            this.name = name;
            this.condition = condition;
            this.initial_price = initial_price;
            this.description = description;
            this.quantity = quantity;
            this.start_time = start_time;
            this.end_time = end_time;
        }
    }
}