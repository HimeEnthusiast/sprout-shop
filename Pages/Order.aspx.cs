using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalAssignmentCS.Pages
{
    public partial class Order : System.Web.UI.Page
    {

        //On page load, there will be a check to see if a product has been chosen. If there is no order in progress, the user must return to the product page.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Product"] == null)
            {
                if (Session["User_ID"] != null)
                {
                    orderForm.InnerHtml = "You haven't ordered anything!<br><br><button id='sendOrder'><a href='Store.aspx'>Go To Products</a></button>";
                }
                else
                {
                    orderForm.InnerHtml = "You haven't logged in!<br><br><button id='sendOrder'><a href='Default.aspx'>Go Home</a></button>";
                }
            }
            else
            {
                Product order = (Product)Session["Product"];
                orderDisplay.InnerHtml = order.ProdName + "<br>" + order.ProdDescription + "<br>" + order.Price;
            }
        }

        //When the send order button is clicked, the users address, payment, and order information will be saved to the database.
        protected void sendOrder_Click(object sender, EventArgs e)
        {
            //The method will first check if the user is logged in before ordering.
            if (Session["User_ID"] != null)
            {
                Product order = (Product)Session["Product"];

                int userID = Convert.ToInt32(Session["User_ID"]);
                //Add address payment and product to db
                DBMethods methods = new DBMethods();
                DateTime today = DateTime.Today;

                methods.insertAddress(this.street.Text, this.city.Text, this.postalCode.Text, userID);
                methods.insertPaymentInfo(this.cardType.SelectedValue, Convert.ToInt32(this.cardNumber.Text), Convert.ToInt32(this.securityCode.Text), this.cardName.Text, userID);
                methods.insertOrderHistory(today, order.ProdID, userID);
                orderForm.InnerHtml = "Order Successful!";
            }
            else
            {
                Response.Write("You aren't logged in!");
            }
        }
    }
}