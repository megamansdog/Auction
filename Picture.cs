using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction
{
    public class Picture
    {
        public int id;
        public string image_name;
        public byte[] image_data;
        public int itemid;

        public Picture(int id, string image_name, byte[] image_data, int itemid)
        {
            this.id         = id;
            this.image_name = image_name;
            this.image_data = image_data;
            this.itemid     = itemid;
        }
    }
}