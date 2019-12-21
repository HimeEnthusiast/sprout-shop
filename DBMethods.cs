using FinalAssignmentCS.ReaderService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalAssignmentCS
{
    /*
     * This class exists to keep a collection of insert and update commands for easy reuse in the program.
     */
    public class DBMethods
    {
        private DBConnection connector = new DBConnection();
        private string commandString;
        private SqlConnection conn;
        private SqlCommand command;

        public DBMethods() { }

        //These methods are for inserting into specific tables.
        //The insertUser method returns a boolean, true if the user was created and false if the user was not created. 
        public bool insertUser(string firstName, string lastName, string email, string password)
        {
            ReaderClient reader = new ReaderClient();
            DataTable dt = reader.GetUsers().Tables[0];
            bool created = true;

            //The method loops through each row in the User table. It matches the email input to the email of every record in the table. If there is a match, then the bool returns false and a message is displayed to the user.
            foreach (DataRow dr in dt.Rows)
            {
                if (email.Equals(dr.ItemArray[3].ToString()))
                {
                    System.Web.HttpContext.Current.Response.Write("You have already created an account with this email!");

                    created = false;
                    return created;
                }
            }

            //If the boolean is true, the user record will be inserted into the table.
            if (created != false)
            {
                //Connect to the DB and set the command
                conn = new SqlConnection(connector.getConnString());
                commandString = "INSERT INTO dbo.Users (FirstName, LastName, Email, UserPassword) values(@FirstName, @LastName, @Email, @UserPassword)";

                try
                {
                    conn.Open();
                    command = new SqlCommand(commandString, conn);

                    //Parameter values are passed in
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@UserPassword", password);

                    int r = command.ExecuteNonQuery();
                    conn.Close();

                    return created;
                }
                catch (SqlException ex)
                {
                    System.Web.HttpContext.Current.Response.Write("A problem has occured!!\n\n" + ex);
                }
            }
            throw new InvalidOperationException("Account not created.");
        }

        public void insertAddress(string street, string city, string postalCode, int userId)
        {
            //Connect to the DB and set the command
            conn = new SqlConnection(connector.getConnString());
            commandString = "INSERT INTO dbo.Ship_Address (Street, City, PostalCode, UserID) values(@Street, @City, @PostalCode, @UserID)";

            try
            {
                conn.Open();
                command = new SqlCommand(commandString, conn);

                //Parameter values are passed in
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@PostalCode", postalCode);
                command.Parameters.AddWithValue("@UserID", userId);

                int r = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("A problem has occured!!\n\n" + ex);
            }
        }

        public void insertPaymentInfo(string cardType, long cardNumber, int securityCode, string cardName, int userId)
        {
            //Connect to the DB and set the command
            conn = new SqlConnection(connector.getConnString());
            commandString = "INSERT INTO dbo.Payment_Info (CardType, CardNumber, SecurityCode, CardName, UserID) values(@CardType, @CardNumber, @SecurityCode, @CardName, @UserID)";

            try
            {
                conn.Open();
                command = new SqlCommand(commandString, conn);

                //Parameter values are passed in
                command.Parameters.AddWithValue("@CardType", cardType);
                command.Parameters.AddWithValue("@CardNumber", cardNumber);
                command.Parameters.AddWithValue("@SecurityCode", securityCode);
                command.Parameters.AddWithValue("@CardName", cardName);
                command.Parameters.AddWithValue("@UserID", userId);

                int r = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("A problem has occured!!\n\n" + ex);
            }
        }
        public void insertOrderHistory(DateTime orderDate, int productId, int userId)
        {
            //Connect to the DB and set the command
            conn = new SqlConnection(connector.getConnString());
            commandString = "INSERT INTO dbo.Order_History (OrderDate, ProductID, UserID) values(@OrderDate, @ProductID, @UserID)";

            try
            {
                conn.Open();
                command = new SqlCommand(commandString, conn);

                //Parameter values are passed in
                command.Parameters.AddWithValue("@OrderDate", orderDate);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@UserID", userId);

                int r = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("A problem has occured!!\n\n" + ex);
            }
        }
    }
}