using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
//Customers need to be tracked for marketing purposes if they give permission, 
//create a class with private attributes and associated assessor methods to store and retrieve information
{
    [Serializable]
    class Customer : IComparable<Customer>
    {
        //Custoomer's Attributes
        private string customerID;
        private string lastName;
        private string firstName;
        private string email;
        //Getters and Setters
        public string gsCustomerID { get => customerID; set => customerID = value; }
        public string gsLastName { get => lastName; set => lastName = value; }
        public string gsFirstName { get => firstName; set => firstName = value; }
        public string gsEmail { get => email; set => email = value; }
        //Default Constuctor
        public Customer() {}
        // If no details are provided they can be grouped as a single customer unknown with an ID of "C000" 
        //Constuctor for Unknown customer
        public Customer(string customerID) {
            customerID = "C000";
        }

        //Method to display base item
        public string DisplayBaseItem()
        {
            return customerID + "  " + lastName;
        }

        public int CompareTo(Customer next)
        {
            return this.customerID.CompareTo(next.customerID);
        }

    }
}
