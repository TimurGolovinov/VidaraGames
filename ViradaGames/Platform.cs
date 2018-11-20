using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
{
    //Platforms which have a model number 
    [Serializable]
    class Platform : Item
    {
        //Platform's attributes (derived)
        private string modelNumber;
        //Setters and Getters
        public string gsModelNumber { get => modelNumber; set => modelNumber = value; }
        //Default Constructor
        public Platform() : base() { }
    }
}
