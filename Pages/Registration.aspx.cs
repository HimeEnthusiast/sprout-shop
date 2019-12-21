using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalAssignmentCS.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * This button will take the inputs from the registration page and insert them into the users table of the database.
         */
        protected void regBtn_Click(object sender, EventArgs e)
        {
            //Insert into user table
            DBMethods dbMethods = new DBMethods();

            //If the account was created, the user will be taken back to the home page.
            if (dbMethods.insertUser(this.fname.Text, this.lname.Text, this.email.Text, this.pass.Text) == true)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}