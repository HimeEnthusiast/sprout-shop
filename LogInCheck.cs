using FinalAssignmentCS.ReaderService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinalAssignmentCS
{
    /*
     * This class contains methods for logging into a user account.
     */
    public class LogInCheck
    {
        public LogInCheck() { }

        //This method takes the email and password from the log in page. It goes through the database to check if the credentials match a record. If so, it will return the user's account id.
        public int returnUser(string email, string password)
        {
            ReaderClient reader = new ReaderClient();
            DataTable dt = reader.GetUsers().Tables[0];
            int check = 0;

            //The method loops through the user table and checks if the email and password are equal to any records within the table. 
            foreach (DataRow dr in dt.Rows)
            {
                //If there is a match, the user id is returned.
                if (email.Equals(dr.ItemArray[3].ToString()) && password.Equals(dr.ItemArray[4].ToString()))
                {
                    check = Convert.ToInt32(dr.ItemArray[0]);
                    return check;
                }
            }

            //If no user is found, 0 will be returned.
            if (check == 0)
            {
                return check;
            }

            throw new InvalidOperationException("Could not find user.");
        }
    }
}