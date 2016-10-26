using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Game object, that can contain books.
    /// </summary>
    [XmlRoot("Bookshelf")]
    public class Bookshelf : GameObjectBase
    {

        public List<Book> Books { get; set; }

        public override GameObjectType Type => GameObjectType.Bookshelf;


        public Bookshelf() { }

        public Bookshelf(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        /// <summary>
        /// Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            //changes state to looking at object
        }

        /// <summary>
        /// Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            Console.WriteLine("How can I use Bookshelf? Maybe look?");
        }
    }
}
