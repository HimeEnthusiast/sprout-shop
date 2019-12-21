using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalAssignmentCS.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            LogInCheck logIn = new LogInCheck();
            int userID = logIn.returnUser(this.email.Text, this.password.Text);

            if (userID != 0)
            {
                //create session
                Session["User_ID"] = userID;
                Response.Redirect("Store.aspx");
            }
            else
            {
                Response.Write("Login failed! Please check your username and password.");
            }
        }
    }
}