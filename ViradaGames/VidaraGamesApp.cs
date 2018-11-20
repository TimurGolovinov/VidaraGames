using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//M228724
//TimurGolovinov
//5/11/2018
/* This is  a stand-alone application which will be used in-store of Virada Games 
to keep track of all items and the sales to customers. 
1) The program loads the all information from 3 binary 
files when the program starts into an appropriate List<T> structure. 

2) You can add items, clients and transactions to the list by using text boxes and "Add..." button

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
    static class VidaraGamesApp
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new viradaGames());
        }
    }
}
