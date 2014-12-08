using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;

namespace Auction
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if ((context.Request.HttpMethod == "POST") && (string)context.Request.Form["action"] == "item_add")
            {
                //db.addItem((string)Request.Form["item_name"],(string)Request.Form["item_condition"],(string)Request.Form["item_initial_price"],(string)Request.Form["item_description"],Request.Form["item_quantity"] );
                //context.Response.Write(context.Request.Form.ToString());
                for (int i = 0; i < 1; i++)
                {
                    HttpPostedFile file = context.Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        //var str = new StreamReader(file.InputStream).ReadToEnd();
                        //var bin = new BinaryReader(file.InputStream).ReadBytes(int.MaxValue);
                        //var bin = ReadAllBytes(new BinaryReader(file.InputStream));
                        byte[] fileData = null;
                        var binaryReader = new BinaryReader(file.InputStream);
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                        context.Response.BinaryWrite(fileData);
                        context.Response.ContentType = "image/jpeg";
                        break;
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}