using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
{
    // An Item class which has an itemID, description, stock quantity and retail price, 
    //these attributes must be private, with associated assessor methods to store and retrieve information. 

    //There are three types of items as follows(these are derived classes of Item) 
    //with associated assessor methods to store and retrieve information
    [Serializable]
    class Item : IComparable<Item>
    {
        //Attributes
        //Item Info (main class attributes)
        private string productID;
        private string description;
        private string stockQuantity;
        private string retailPrice;
        //Setters and Getters
        public string gsProductID { get => productID; set => productID = value; }
        public string gsDescription { get => description; set => description = value; }
        public string gsStockQuantity { get => stockQuantity; set => stockQuantity = value; }
        public string gsRetailPrice { get => retailPrice; set => retailPrice = value; }
        //Method to display base item
        public string DisplayBaseItem()
        {
            return productID + "  " + description;
        }

        public int CompareTo(Item next)
        {
            return this.productID.CompareTo(next.productID);
        }

    }
}
