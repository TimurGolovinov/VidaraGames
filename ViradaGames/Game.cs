using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViradaGames
{
    //Games which have a publisher and media type (DVD, Online, etc) 
    [Serializable]
    class Game : Item
    {
        //Game's attributes (derived attributes)
        private string publisher;
        private string mediaType;
        //Setters and Getters
        public string gsPublisher { get => publisher; set => publisher = value; }
        public string gsMediaType { get => mediaType; set => mediaType = value; }

        // Defaul constructor for the derived class
        public Game() : base() { }
    }
}
