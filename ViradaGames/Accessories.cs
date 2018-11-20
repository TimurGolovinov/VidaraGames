using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
{
    //Accessories which have a platform type (Console, PC, etc) 
    [Serializable]
    class Accessories : Item
    {
        //Accessories attributes
        private string platformType;
        //Setters and Getters
        public string gsPlatformType { get => platformType; set => platformType = value; }
        //Defaul constructor
        public Accessories() : base() { }
    }
}
