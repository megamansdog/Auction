using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization;

namespace Auction
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public AuctionDB db = new AuctionDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "item_add")
            {
                //db.addItem((string)Request.Form["item_name"],(string)Request.Form["item_condition"],(string)Request.Form["item_initial_price"],(string)Request.Form["item_description"],Request.Form["item_quantity"] );
                DateTime end_time = DateTime.Now;
                switch (Request.Form["item_duration_type"])
                {
                    case "minutes":
                        end_time = end_time.AddMinutes(Int32.Parse(Request.Form["item_duration"]));
                        break;
                    case "hours":
                        end_time = end_time.AddHours(Int32.Parse(Request.Form["item_duration"]));
                        break;
                    case "days":
                        end_time = end_time.AddDays(Int32.Parse(Request.Form["item_duration"]));
                        break;
                    default:
                        Response.End();
                        break;
                }

                int itemid = db.CreateItem((int)Session["id"], (string)Request.Form["item_name"], (string)Request.Form["item_condition"], (int)Int32.Parse(Request.Form["item_initial_price"]), (string)Request.Form["item_description"], (int)Int32.Parse(Request.Form["item_quantity"]), end_time);
                
                // Create the pictures...
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile file = Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        byte[] fileData = null;
                        var binaryReader = new BinaryReader(file.InputStream);
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                        db.CreateItemPicture(itemid, file.FileName, fileData);
                    }
                }
            }
            else
            {
                //Response.Redirect("index.aspx");
                
            }
        }
    }
}