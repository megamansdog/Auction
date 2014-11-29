using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

namespace Auction
{
    public class AuctionDB
    {
        private System.Data.SqlClient.SqlConnection con;

        // Constructor: 
        public AuctionDB()
        {
            this.con = new System.Data.SqlClient.SqlConnection();
            this.con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Documents\Visual Studio 2013\Projects\Auction\App_Data\Database1.mdf;Integrated Security=True";
            this.con.Open();
        }

        // Printing method: 
        public void CreateUser(string username, string password, string email )
        {
            String query = "INSERT INTO dbo.users (username,password,email) VALUES(@username,@password, @email)";

            SqlCommand command = new SqlCommand(query, this.con);
            command.Parameters.Add("@username",username);
            command.Parameters.Add("@password", FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"));
            command.Parameters.Add("@email",email);
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

        public bool Authenticate(string username, string password)
        {
            return true;
        }
    }
}