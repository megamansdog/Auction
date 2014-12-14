using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;
using System.Data;

namespace Auction
{
    public class AuctionDB
    {
        private System.Data.SqlClient.SqlConnection con;

        // Constructor: 
        public AuctionDB()
        {
            this.con = new System.Data.SqlClient.SqlConnection();
            this.con.ConnectionString = @"Data Source=(localdb)\ProjectsV12;AttachDbFilename=|DataDirectory|\DATABASE1.MDF;Integrated Security=True;MultipleActiveResultSets=True;";
            //this.con.ConnectionString = @"Server=JASON-PC\SQLEXPRESS;Database=D:\REPOS\AUCTION\APP_DATA\DATABASE1.MDF;Integrated Security=true;MultipleActiveResultSets=True;";
            this.con.Open();
        }

        // Printing method: 
        public void CreateUser(string username, string password, string email )
        {
            String query = "INSERT INTO dbo.users (username,password,email) VALUES(@username,@password, @email)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@username",username);
            command.Parameters.AddWithValue("@password", Public.GetMD5Hash(password));
            command.Parameters.AddWithValue("@email",email);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string eMessage = "Error Creating User: " + e.Message + " " + e.GetType();
                throw new Exception(eMessage);
            }
        }


        public int Authenticate(string username, string password)
        {
            String query = "SELECT * FROM dbo.users WHERE username='" + username + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText =query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {
                while (reader.Read())
                {
                    if ((username == reader["username"].ToString()) && (Public.GetMD5Hash(password) == reader["password"].ToString()))
                    {
                        // User Exists
                        return (int) reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB Authenticate Exception: " + e.Message );
            }
            // User did not exist
            return -1;
        }

        public void CreateCC(int userid, string owner, string number, DateTime expiration)
        {
            String query = "INSERT INTO dbo.credit_card (userid,owner,number,expiration) VALUES(@userid,@owner,@number, @expiration)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@owner", owner);
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@expiration", expiration);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Credit Card: " + e.Message + " " + e.GetType());
            }
        }
        
        public List<CCInfo> GetCCList(int usersid)
        {
            List<CCInfo> CCList = new List<CCInfo>();
            String query = "SELECT * FROM dbo.credit_card WHERE userid='" + usersid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {
                
                while (reader.Read())
                {
                    CCList.Add(new CCInfo((int)reader["userid"],(string)reader["owner"],(string)reader["number"],(DateTime)reader["expiration"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetCCList Exception: " + e.Message);
            }
            // User did not exist
            return CCList;
        }


        public void CreateContact(int userid, string phone_number)
        {
            String query = "INSERT INTO dbo.contact_info (userid,phone_number) VALUES(@userid,@phone_number)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@phone_number", phone_number);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Contact Info: " + e.Message + " " + e.GetType());
            }
        }

        public List<ContactInfo> GetContactList(int usersid)
        {
            List<ContactInfo> ContactList = new List<ContactInfo>();
            String query = "SELECT * FROM dbo.contact_info WHERE userid='" + usersid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {

                while (reader.Read())
                {
                    ContactList.Add(new ContactInfo((int)reader["userid"], (string)reader["phone_number"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetContactList Exception: " + e.Message);
            }
            // User did not exist
            return ContactList;
        }

        public void CreateAddress(int userid, string street_number, string street_name, string city, string state, string zip)
        {
            String query = "INSERT INTO dbo.address (userid,street_number,street_name,city,state,zip) VALUES(@userid,@street_number,@street_name,@city,@state,@zip)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@street_number", street_number);
            command.Parameters.AddWithValue("@street_name", street_name);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@state", state);
            command.Parameters.AddWithValue("@zip", zip);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Address: " + e.Message + " " + e.GetType());
            }
        }

        public List<Address> GetAddressList(int usersid)
        {
            List<Address> AddressList = new List<Address>();
            String query = "SELECT * FROM dbo.address WHERE userid='" + usersid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {

                while (reader.Read())
                {
                    AddressList.Add(new Address((int)reader["userid"], (string)reader["street_number"], (string)reader["street_name"], (string)reader["city"], (string)reader["state"], (string)reader["zip"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetAddressList Exception: " + e.Message);
            }
            // User did not exist
            return AddressList;
        }

        public int CreateItem(int userid, string name, string condition, int initial_price, string description, int quantity, DateTime end_time )
        {
            String query = "INSERT INTO dbo.items (userid,name,condition,initial_price,description,quantity,start_time,end_time) VALUES(@userid,@name,@condition,@initial_price,@description,@quantity,@start_time,@end_time); SELECT @Id = SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@condition", condition);
            command.Parameters.AddWithValue("@initial_price", initial_price);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@start_time", (DateTime) DateTime.Now);
            command.Parameters.AddWithValue("@end_time", end_time);

            //Obtain the ID of the item that was created
            command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating sContact Info: " + e.Message + " " + e.GetType());
            }
            int itemid = Convert.ToInt32(command.Parameters["@Id"].Value);
            return itemid;
        }

        public Item GetItem(int itemid)
        {
            String query = "SELECT TOP(1) * FROM dbo.items WHERE Id='" + itemid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    return new Item((int)reader["Id"], (int)reader["userid"], (string)reader["name"], (string)reader["condition"], (int)reader["initial_price"], (string)reader["description"], (int)reader["quantity"],(DateTime)reader["start_time"],(DateTime)reader["end_time"]);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetItem Exception: " + e.Message);
            }
            return null;
        }

        public List<Item> GetItemList(int userid)
        {
            List<Item> ItemList = new List<Item>();
            String query = "SELECT * FROM dbo.items WHERE userid='" + userid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {

                while (reader.Read())
                {
                    ItemList.Add(new Item((int)reader["Id"], (int)reader["userid"], (string)reader["name"], (string)reader["condition"], (int)reader["initial_price"], (string)reader["description"], (int)reader["quantity"],(DateTime)reader["start_time"],(DateTime)reader["end_time"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetItemList Exception: " + e.Message);
            }
            // User did not exist
            return ItemList;
        }
        public List<Item> GetAllItemList()
        {
            List<Item> ItemList = new List<Item>();
            String query = "SELECT * FROM dbo.items";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {

                while (reader.Read())
                {
                    ItemList.Add(new Item((int)reader["Id"], (int)reader["userid"], (string)reader["name"], (string)reader["condition"], (int)reader["initial_price"], (string)reader["description"], (int)reader["quantity"], (DateTime)reader["start_time"], (DateTime)reader["end_time"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetItemList Exception: " + e.Message);
            }
            // User did not exist
            return ItemList;
        }
        public void CreateItemPicture(int itemid, string image_name, byte[] image_data)
        {
            String query = "INSERT INTO dbo.item_pictures (itemid,image_name,image_data) VALUES(@itemid,@image_name,@image_data)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@image_name", image_name);
            command.Parameters.AddWithValue("@image_data", image_data);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Item Picture: " + e.Message + " " + e.GetType());
            }

        }

        public List<Picture> GetItemPictureList(int itemid)
        {
            List<Picture> ItemPictureList = new List<Picture>();
            String query = "SELECT * FROM dbo.item_pictures WHERE itemid='" + itemid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            try
            {
                while (reader.Read())
                {
                    ItemPictureList.Add(new Picture((int)reader["Id"], (string)reader["image_name"], (byte[])reader["image_data"], (int)reader["itemid"]));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetItemPictureList Exception: " + e.Message);
            }

            return ItemPictureList;
        }

        public Picture GetItemPicture(int imageid)
        {
            String query = "SELECT * FROM dbo.item_pictures WHERE Id='" + imageid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();

            try
            {
                while(reader.Read())
                {
                    byte[] image_data = (byte[])reader["image_data"];
                    return new Picture((int)reader["Id"],(string)reader["image_name"], image_data, (int)reader["itemid"]);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetItemPictureList Exception: " + e.Message);
            }
            return null;
        }

        public int GetFirstItemPicture(int itemid)
        {
            String query = "SELECT TOP(1) id FROM dbo.item_pictures WHERE itemid='" + itemid + "'";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    return (int)reader["Id"];
                }

            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetFirstItemPicture Exception: " + e.Message);
            }
            return 0;
        }

        public void CreateBid(int userid, int itemid, double bid_amount, DateTime bid_time)
        {
            String query = "INSERT INTO dbo.bids (userid,itemid,bid_amount,bid_time) VALUES(@userid,@itemid,@bid_amount, @bid_time)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@bid_amount", bid_amount);
            command.Parameters.AddWithValue("@bid_time", bid_time);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Bid: " + e.Message + " " + e.GetType());
            }
        }

        public void UpdateBid(int userid, int itemid, double bid_amount, DateTime bid_time)
        {
            String query = "UPDATE dbo.bids SET bid_amount=@bid_amount,bid_time=@bid_time WHERE userid=@userid AND itemid=@itemid";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@bid_amount", bid_amount);
            command.Parameters.AddWithValue("@bid_time", bid_time);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error Creating Bid: " + e.Message + " " + e.GetType());
            }
        }

        public Bid GetHighestBid(int itemid)
        {
            String query = "SELECT TOP(1) * FROM dbo.bids WHERE itemid='" + itemid + "' ORDER BY bid_amount DESC";
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlDataReader reader;

            cmd.CommandText = query;

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    return new Bid((int)reader["Id"], (int)reader["userid"], (int)reader["itemid"], (double) Convert.ToDouble(reader["bid_amount"]), (DateTime)reader["bid_time"]);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Auction DB GetHighestBid Exception: " + e.ToString());
            }
            return null;
        }

    }

}