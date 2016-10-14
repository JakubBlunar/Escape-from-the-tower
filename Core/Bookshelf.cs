using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Bookshelf : IGameObject
    {

        public List<Book> Books { get; private set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Bookshelf;
            }
        }

        public string Name { get; set; }


        public Bookshelf(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public void Look(Player p)
        {
            
        }

        public void Use(Player p)
        {
            Console.WriteLine("How can I use Bookshelf? Maybe look?");
        }
    }
}
