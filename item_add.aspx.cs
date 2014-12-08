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
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.HttpMethod == "POST") && (string)Request.Form["action"] == "item_add")
            {
                //db.addItem((string)Request.Form["item_name"],(string)Request.Form["item_condition"],(string)Request.Form["item_initial_price"],(string)Request.Form["item_description"],Request.Form["item_quantity"] );
                Response.Write(Request.Form.ToString());
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile file = Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        //var str = new StreamReader(file.InputStream).ReadToEnd();
                        //var bin = new BinaryReader(file.InputStream).ReadBytes(int.MaxValue);
                        //var bin = ReadAllBytes(new BinaryReader(file.InputStream));
                        byte[] fileData = null;
                        var binaryReader = new BinaryReader(file.InputStream);
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                        Response.BinaryWrite(fileData);
                        Response.ContentType = "image/jpeg";
                        break;
                    }
                }
            }
            else
            {
                //Response.Redirect("index.aspx");
                
            }
        }
        protected static byte[] ReadAllBytes(BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }
    }
}