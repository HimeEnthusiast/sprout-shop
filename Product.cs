using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalAssignmentCS
{
    /*
     * This class provides a structure for store products to be saved as objects so they may be put into lists.
     */
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageLink { get; set; }

        public Product(int id, string name, string description, string category, decimal price, string img)
        {
            ProdID = id;
            ProdName = name;
            ProdDescription = description;
            Category = category;
            Price = price;
            ImageLink = img;
        }

        public override string ToString()
        {
            return ProdName + ProdDescription + Price;
        }
    }
}