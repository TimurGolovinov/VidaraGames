using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

//M228724
//TimurGolovinov
//5/11/2018
/* This is  a stand-alone application which will be used in-store of Vidara Games 
to keep track of all items and the sales to customers. 

1) The program loads the all information from 3 binary files 
when the program starts into an appropriate List<T> structure. 

2) You can add items, clients and transactions to the list by using text boxes and "Add..." buttons
The program checks your input in the textboxes before adding the data to the binary file
You cannot add platform, game and/or accessories simultaneously (only base attributes + 1 derived objet at a time)

3) When an item in either of the two upper listboxes (Item or Customer) is clicked, the information 
relating to that record is to be added to the textboxes to the left 
and also to the appropriate textboxes under Transaction

4) Before the Transaction add button is clicked the user must first select a customer and item. 
This action will populate the custID, productID and retail price textboxes in the transactions groupbox 

5) Test data: 4 customers, 10 items (4 games, 3 platforms and 3 accessories), and 4 transactions

6) Full Report is attached to the program
*/
namespace ViradaGames
{
    public partial class viradaGames : Form
    {
        public viradaGames()
        {
            InitializeComponent();

        }

        //The program loads the items information from a binary file called items.dat 
        //when the program starts into an appropriate List<T> structure.  
        //List for items (games, platforms and accessories)
        List<Item> myItems = new List<Item>();
        //List for customers
        List<Customer> myCustomers = new List<Customer>();
        //List for transactions
        List<Transaction> myTransactions = new List<Transaction>();

        //Program Launch
        private void viradaGames_Load(object sender, EventArgs e)
        {
            ReadTransactionsFromBinaryFile();
            ReadCustomersFromBinaryFile();
            ReadItemsFromBinaryFile();

            DisplayItems();
            DisplayCustomers();
            DisplayTransactions();
        }

        //**BINARY WRITE AND READ**
        //Write data to Binary File for ITEM
        private void WriteItemsToBinaryFile()
        {
            try
            {
                using (Stream writeStream = File.Open("items.bin", FileMode.Create))
                {
                    // Create the binary formatter and serialize
                    BinaryFormatter binaryData = new BinaryFormatter();
                    binaryData.Serialize(writeStream, myItems);
                }
            }
            catch (IOException IOe)
            {
                MessageBox.Show("Could not write to file ! \n" + IOe.Message);
            }
        }
        //Write data to Binary File for CUSTOMERS
        private void WriteCustomersToBinaryFile()
        {
            try
            {
                using (Stream writeStream = File.Open("customers.bin", FileMode.Create))
                {
                    // Create the binary formatter and serialize
                    BinaryFormatter binaryData = new BinaryFormatter();
                    binaryData.Serialize(writeStream, myCustomers);
                }
            }
            catch (IOException IOe)
            {
                MessageBox.Show("Could not write to file ! \n" + IOe.Message);
            }
        }
        //Write data to Binary File for TRANSACTIONS
        private void WriteTransactionsToBinaryFile()
        {
            try
            {
                using (Stream writeStream = File.Open("transactions.bin", FileMode.Create))
                {
                    // Create the binary formatter and serialize
                    BinaryFormatter binaryData = new BinaryFormatter();
                    binaryData.Serialize(writeStream, myTransactions);
                }
            }
            catch (IOException IOe)
            {
                MessageBox.Show("Could not write to file ! \n" + IOe.Message);
            }
        }
        //Read data from Binary File for ITEM
        private void ReadItemsFromBinaryFile()
        {
            try
            {
                using (Stream readStream = File.Open("items.bin", FileMode.Open))
                {
                    try
                    {
                        // Create the binary formatter and deserialize
                        BinaryFormatter binaryData = new BinaryFormatter();
                        myItems = (List<Item>)binaryData.Deserialize(readStream);
                    }
                    catch (SerializationException)
                    {
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot read items from file");
            }
        }
        //Read data from Binary File for CUSTOMERS
        private void ReadCustomersFromBinaryFile()
        {
            try
            {
                using (Stream readStream = File.Open("customers.bin", FileMode.Open))
                {
                    try
                    {
                        // Create the binary formatter and deserialize
                        BinaryFormatter binaryData = new BinaryFormatter();
                        myCustomers = (List<Customer>)binaryData.Deserialize(readStream);
                    }
                    catch (SerializationException)
                    {
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot read customers from file");
            }
        }
        //Read data from Binary File for TRANSACTIONS
        private void ReadTransactionsFromBinaryFile()
        {
            try
            {
                using (Stream readStream = File.Open("transactions.bin", FileMode.Open))
                {
                    try
                    {
                        // Create the binary formatter and deserialize
                        BinaryFormatter binaryData = new BinaryFormatter();
                        myTransactions = (List<Transaction>)binaryData.Deserialize(readStream);
                    }
                    catch (SerializationException)
                    {
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot read transactions from file");
            }
        }

        //**OTHER METHODS**
        //Methods to clear text boxes
        //Items
        private void ClearItemTextBoxes()
        {
            // clear base model text boxes
            txtProductID1.Clear();
            txtDescription.Clear();
            txtStockQuantity.Clear();
            txtRetailPrice1.Clear();
            //Clear Game text Boxes
            txtPublisher.Clear();
            txtMediaType.Clear();
            //Clear Platform text Boxes
            txtModelNumber.Clear();
            //Clear Accessories text Boxes
            txtPlatformType.Clear();
        }
        //Customers
        private void ClearCustomerTextBoxes()
        {
            // clear Customers text boxes
            txtCustomerID1.Clear();
            txtFamilyName.Clear();
            txtFirstName.Clear();
            txtEmail.Clear();
        }
        //Transactions
        private void ClearTransactionTextBoxes()
        {
            // clear Customers text boxes
            txtProductID2.Clear();
            txtCustomerID2.Clear();
            txtQuantity.Clear();
            txtRetailPrice2.Clear();
            txtDate.Clear();
        }

        // Methods to display data in a list boxes
        //Displat Items
        private void DisplayItems()
        {
            listProducts.Items.Clear();
            foreach (Item i in myItems)
            {
                listProducts.Items.Add(i.DisplayBaseItem());
            }
        }
        //Display Customers
        private void DisplayCustomers()
        {
            listCustomers.Items.Clear();
            foreach (Customer c in myCustomers)
            {
                listCustomers.Items.Add(c.DisplayBaseItem());
            }
        }
        //Display Transactions
        private void DisplayTransactions()
        {
            listTransactions.Items.Clear();
            foreach (Transaction t in myTransactions)
            {
                listTransactions.Items.Add(t.DisplayBaseItem());
            }
        }


        //**BUTTONS**
        //Button To Close App
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Button ADD for ITEMS
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //Check Base class inputs
            if (!String.IsNullOrEmpty(txtProductID1.Text) &&
                !String.IsNullOrEmpty(txtDescription.Text) &&
                !String.IsNullOrEmpty(txtStockQuantity.Text) &&
                !String.IsNullOrEmpty(txtRetailPrice1.Text))
            {
                //IF OK, go and chech derived classes
                //First, check game class attributes
                if (!String.IsNullOrEmpty(txtPublisher.Text) &&
                    !String.IsNullOrEmpty(txtMediaType.Text) &&
                    //make sure other class' fields are empty
                    String.IsNullOrEmpty(txtModelNumber.Text) &&
                    String.IsNullOrEmpty(txtPlatformType.Text))
                //if satisfied, create game object
                {
                    Game newGame = new Game();
                    //Base Attributes
                    newGame.gsProductID = txtProductID1.Text;
                    newGame.gsDescription = txtDescription.Text;
                    newGame.gsStockQuantity = txtStockQuantity.Text;
                    newGame.gsRetailPrice = txtRetailPrice1.Text;
                    //Derived Attributes
                    newGame.gsPublisher = txtPublisher.Text;
                    newGame.gsMediaType = txtMediaType.Text;
                    //Check for duplicates
                    bool duplicateFound = myItems.Exists(x => x.gsProductID == txtProductID1.Text); //Check X
                    //If no duplicates found
                    if (!duplicateFound)
                    {
                        //Add complete object to the list
                        myItems.Add(newGame);
                    }
                    else
                    {
                        MessageBox.Show("This item already exists");
                    }
                }
                //Check maybe it is a Platform
                else if (String.IsNullOrEmpty(txtPublisher.Text) &&
                    String.IsNullOrEmpty(txtMediaType.Text) &&
                    //if there is a model number in text box, add platform
                    !String.IsNullOrEmpty(txtModelNumber.Text) &&
                    String.IsNullOrEmpty(txtPlatformType.Text))
                {
                    Platform newPlatform = new Platform();
                    //Base Attributes
                    newPlatform.gsProductID = txtProductID1.Text;
                    newPlatform.gsDescription = txtDescription.Text;
                    newPlatform.gsStockQuantity = txtStockQuantity.Text;
                    newPlatform.gsRetailPrice = txtRetailPrice1.Text;
                    //Derived Attributes
                    newPlatform.gsModelNumber = txtModelNumber.Text;
                    //Check for duplicates
                    bool duplicateFound = myItems.Exists(x => x.gsProductID == txtProductID1.Text); //Check X
                                                                                                    //If no duplicates found
                    if (!duplicateFound)
                    {
                        //Add complete object to the list
                        myItems.Add(newPlatform);
                    }
                    else
                    {
                        MessageBox.Show("This item already exists");
                    }
                }
                //Check maybe there are Accessories
                else if (String.IsNullOrEmpty(txtPublisher.Text) &&
                    String.IsNullOrEmpty(txtMediaType.Text) &&
                    //if there is a model number in text box, add platform
                    String.IsNullOrEmpty(txtModelNumber.Text) &&
                    !String.IsNullOrEmpty(txtPlatformType.Text))
                {
                    Accessories newAccessories = new Accessories();
                    //Base Attributes
                    newAccessories.gsProductID = txtProductID1.Text;
                    newAccessories.gsDescription = txtDescription.Text;
                    newAccessories.gsStockQuantity = txtStockQuantity.Text;
                    newAccessories.gsRetailPrice = txtRetailPrice1.Text;
                    //Derived Attributes
                    newAccessories.gsPlatformType = txtPlatformType.Text;
                    //Check for duplicates
                    bool duplicateFound = myItems.Exists(x => x.gsProductID == txtProductID1.Text); //Check X
                    //If no duplicates found
                    if (!duplicateFound)
                    {
                        //Add complete object to the list
                        myItems.Add(newAccessories);
                    }
                    else
                    {
                        MessageBox.Show("This item already exists");
                    }

                }
                //If there are multiple inputs
                else
                {
                    MessageBox.Show("You can only add one Model type");
                }
               
            }
            else
            {
                MessageBox.Show("Model data incomplete");
            }
            ClearItemTextBoxes();
            DisplayItems();
            WriteItemsToBinaryFile();
        }
        //Button ADD for CUSTOMERS
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Check class inputs
            if (!String.IsNullOrEmpty(txtCustomerID1.Text) &&
                !String.IsNullOrEmpty(txtFamilyName.Text) &&
                !String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtEmail.Text))
            {
                Customer newCustomer = new Customer();
                //Base Attributes
                newCustomer.gsCustomerID = txtCustomerID1.Text;
                newCustomer.gsEmail = txtEmail.Text;
                newCustomer.gsFirstName = txtFirstName.Text;
                newCustomer.gsLastName = txtFamilyName.Text;
                //Check for duplicates
                bool duplicateFound = myCustomers.Exists(x => x.gsCustomerID == txtCustomerID1.Text); //Check X
                //If no duplicates found
                if (!duplicateFound)
                {
                    //Add complete object to the list
                    myCustomers.Add(newCustomer);
                }
                else
                {
                    MessageBox.Show("This Customer already exists");
                }
            }
            else
            {
                MessageBox.Show("Customers data incomplete");
            }
            ClearCustomerTextBoxes();
            DisplayCustomers();
            WriteCustomersToBinaryFile();
        }
        //Button ADD for TRANSACTIONS
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            //Check class inputs
            if (!String.IsNullOrEmpty(txtCustomerID2.Text) &&
                !String.IsNullOrEmpty(txtProductID2.Text) &&
                !String.IsNullOrEmpty(txtQuantity.Text) &&
                !String.IsNullOrEmpty(txtRetailPrice2.Text) &&
                !String.IsNullOrEmpty(txtDate.Text))
            {
                Transaction newTransaction = new Transaction();
                //Base Attributes
                newTransaction.gsCustomerID = txtCustomerID2.Text;
                newTransaction.gsProductID = txtProductID2.Text;
                newTransaction.gsQuantity = txtQuantity.Text;
                newTransaction.gsRetailPrice = txtRetailPrice2.Text;
                newTransaction.gsDate = txtDate.Text;

                //Add complete object to the list
                myTransactions.Add(newTransaction);
            }
            else
            {
                MessageBox.Show("Customers data incomplete");
            }
            ClearTransactionTextBoxes();
            DisplayTransactions();
            WriteTransactionsToBinaryFile();
        }
        //Button Clear to clear all text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItemTextBoxes();
            ClearCustomerTextBoxes();
            ClearTransactionTextBoxes();
        }
        // List box ITEMS select to populate text boxes
        private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Item selectedItem = myItems.ElementAt(listProducts.SelectedIndex);
                ClearItemTextBoxes();
                txtProductID1.AppendText(selectedItem.gsProductID);
                txtDescription.AppendText(selectedItem.gsDescription);
                txtStockQuantity.AppendText(selectedItem.gsStockQuantity);
                txtRetailPrice1.AppendText(selectedItem.gsRetailPrice);
                txtProductID2.AppendText(selectedItem.gsProductID);
                txtRetailPrice2.AppendText(selectedItem.gsRetailPrice);
                if (selectedItem is Game)
                {
                    Game selectedGame = (Game)selectedItem;
                    txtPublisher.AppendText(selectedGame.gsPublisher);
                    txtMediaType.AppendText(selectedGame.gsMediaType);
                }
                if (selectedItem is Platform)
                {
                    Platform selectedPlatform = (Platform)selectedItem;
                    txtModelNumber.AppendText(selectedPlatform.gsModelNumber);
                }
                if (selectedItem is Accessories)
                {
                    Accessories selectedAccessories = (Accessories)selectedItem;
                    txtPlatformType.AppendText(selectedAccessories.gsPlatformType);
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        // List box CUSTOMERS select to populate text boxes
        private void listCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Customer selectedCustomer = myCustomers.ElementAt(listCustomers.SelectedIndex);
                ClearCustomerTextBoxes();
                txtCustomerID1.AppendText(selectedCustomer.gsCustomerID);
                txtFamilyName.AppendText(selectedCustomer.gsLastName);
                txtFirstName.AppendText(selectedCustomer.gsFirstName);
                txtEmail.AppendText(selectedCustomer.gsEmail);
                txtCustomerID2.AppendText(selectedCustomer.gsCustomerID);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        // List box TRANSACTIONS select to populate text boxes
        private void listTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Transaction selectedTransaction = myTransactions.ElementAt(listTransactions.SelectedIndex);
                ClearTransactionTextBoxes();
                //The appropriate item and customer are selected in the upper listboxes. This should autofill the upper textboxes. 
                txtQuantity.AppendText(selectedTransaction.gsQuantity);
                txtDate.AppendText(selectedTransaction.gsDate);
                txtRetailPrice2.AppendText(selectedTransaction.gsRetailPrice);
                //CustomerID goes to customer and populates text boxes there as well
                txtCustomerID2.AppendText(selectedTransaction.gsCustomerID);
                try
                {
                    Customer selectedCustomer = myCustomers.ElementAt(listTransactions.SelectedIndex);
                    ClearCustomerTextBoxes();
                    txtCustomerID1.AppendText(selectedCustomer.gsCustomerID);
                    txtFamilyName.AppendText(selectedCustomer.gsLastName);
                    txtFirstName.AppendText(selectedCustomer.gsFirstName);
                    txtEmail.AppendText(selectedCustomer.gsEmail);
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                txtProductID2.AppendText(selectedTransaction.gsProductID);
                try
                {
                    Item selectedItem = myItems.ElementAt(listTransactions.SelectedIndex);
                    ClearItemTextBoxes();
                    txtProductID1.AppendText(selectedItem.gsProductID);
                    txtDescription.AppendText(selectedItem.gsDescription);
                    txtStockQuantity.AppendText(selectedItem.gsStockQuantity);
                    txtRetailPrice1.AppendText(selectedItem.gsRetailPrice);
                    if (selectedItem is Game)
                    {
                        Game selectedGame = (Game)selectedItem;
                        txtPublisher.AppendText(selectedGame.gsPublisher);
                        txtMediaType.AppendText(selectedGame.gsMediaType);
                    }
                    if (selectedItem is Platform)
                    {
                        Platform selectedPlatform = (Platform)selectedItem;
                        txtModelNumber.AppendText(selectedPlatform.gsModelNumber);
                    }
                    if (selectedItem is Accessories)
                    {
                        Accessories selectedAccessories = (Accessories)selectedItem;
                        txtPlatformType.AppendText(selectedAccessories.gsPlatformType);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }

            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}

