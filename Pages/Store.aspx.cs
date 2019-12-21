using FinalAssignmentCS.ReaderService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinalAssignmentCS.Models
{
    public partial class Default : System.Web.UI.Page
    {
        List<Product> products = new List<Product>();
        List<Product> buyProduct = new List<Product>();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                storePage.InnerHtml = "You haven't logged in!<br><br><button id='home'><a href='Default.aspx'>Go Home</a></button>";
            }
            else
            {

                ReaderClient reader = new ReaderClient();
                DataTable dt = reader.GetProducts().Tables[0];

                //The products for the store are loaded from the data table and are stored at product Objects, then stored in a list.
                foreach (DataRow dr in dt.Rows)
                {
                    Product prod = new Product(Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), Convert.ToDecimal(dr.ItemArray[4]), dr.ItemArray[5].ToString());
                    products.Add(prod);
                }

                //For every product, a div and a button are created with the product information.
                foreach (Product p in products)
                {
                    var button = new Button
                    {
                        ID = i.ToString(),
                        CssClass = "adder",
                        Text = "Buy this item"
                    };
                    button.Click += Button_Click;
                    i++;

                    HtmlGenericControl innerProd = new HtmlGenericControl();
                    innerProd.Attributes["class"] = "innerProducts";
                    innerProd.TagName = "div";
                    innerProd.Controls.Add(button);

                    HtmlGenericControl outerProd = new HtmlGenericControl();
                    outerProd.Attributes["class"] = "outerProducts";
                    outerProd.TagName = "div";
                    outerProd.InnerHtml += "<img src=assets/" + p.ImageLink + "><br>" + "<div id='prod-container'><span id='prod-name'>" + p.ProdName + "</span><br><br>" + p.ProdDescription + "<br><br>" + "$" + p.Price + "</div>";
                    outerProd.Controls.Add(innerProd);

                    display.Controls.Add(outerProd);
                    buyProduct.Add(p);
                }
            }
        }
        
        //When the product's button is clicked, the object will be stored in a session. The user will then be taken to an order page.
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int btnID = Convert.ToInt32(button.ID);
            Product p = buyProduct[btnID];
            Session["Product"] = p;
            Response.Redirect("Order.aspx");
        }
    }
}