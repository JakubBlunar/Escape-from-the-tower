using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Book : IGameItem
    {

        public Door Door { get; private set; }

        public bool ShowsSomething { get {
                return Door != null;
            } }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Book;
            }
        }

        public string Name { get; set; }

        public delegate void OnBookTake(Book b);
        public event OnBookTake BookTake;

        public Book(string name, Door d = null)
        {
            Name = name;
            Door = d;
        }

      

        public void Look(Player p)
        {
            Console.WriteLine("Player is reading " + Name);
        }

        public void Take()
        {
            BookTake?.Invoke(this);
        }

        public void Use(Player p)
        {
            Console.WriteLine("I don't know how to use this book. Maybe Look?");
        }
    }
}
