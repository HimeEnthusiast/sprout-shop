using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalAssignmentCS
{
    /*
     * This class exists to hold information to connect to the database, so it can be easily reused.
     */
    public class DBConnection
    {
        //A constructor for the class
        public DBConnection() { }

        //This method returns the connection string
        public string getConnString()
        {
            string connectionString = @"Data Source = DESKTOP-76CQ0MM\SQLEXPRESS; Initial Catalog = SproutDB; Integrated Security = SSPI; Persist Security Info = False";

            return connectionString;
        }

        //This method returns a database connection
        public SqlConnection getConnection(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }


    }
}