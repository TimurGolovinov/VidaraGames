using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
{
    //Transactions are a class with private attributes and associated assessor methods
    //to store and retrieve information
    [Serializable]
    class Transaction : IComparable<Transaction>
    {
        //Transaction Attributes
        string customerID; //TODO gs ID from customer class
        string productID; //TODO gs ID from item class
        private string quantity;
        string retailPrice; //TODO gs RRP from item class
        private string date;
        //Setters and Getters
        public string gsCustomerID { get => customerID; set => customerID = value; }
        public string gsProductID { get => productID; set => productID = value; }
        public string gsQuantity { get => quantity; set => quantity = value; }
        public string gsRetailPrice { get => retailPrice; set => retailPrice = value; }
        public string gsDate { get => date; set => date = value; }

        //Method to display base item
        public string DisplayBaseItem()
        {
            return customerID + "  ID" + productID + ", " + quantity + "X" + retailPrice + "  " + date;
        }

        public int CompareTo(Transaction next)
        {
            return this.productID.CompareTo(next.productID);
        }
    }
}
