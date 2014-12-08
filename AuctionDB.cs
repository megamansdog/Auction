using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;

namespace Auction
{
    public class AuctionDB
    {
        private System.Data.SqlClient.SqlConnection con;

        // Constructor: 
        public AuctionDB()
        {
            this.con = new System.Data.SqlClient.SqlConnection();
            //this.con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Documents\Visual Studio 2013\Projects\Auction\App_Data\Database1.mdf;Integrated Security=True";
            this.con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DATABASE1.MDF;Integrated Security=True;MultipleActiveResultSets=True;";
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

        public void CreateItem(int userid, string name, string condition, int initial_price, string description, int quantity, string picture, DateTime end_time )
        {
            /*
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
            }*/
        }

    }

}