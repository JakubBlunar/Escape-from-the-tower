using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{
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

        public override void Look(Player p)
        {
            
        }

        public override void Use(Player p)
        {
            Console.WriteLine("How can I use Bookshelf? Maybe look?");
        }
    }
}
