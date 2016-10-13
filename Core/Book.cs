using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Book : IGameItem
    {

        public IGameObject Object { get; private set; }

        public bool ShowsSomething { get {
                return Object != null;
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

        public Book(string name, IGameObject toShow = null)
        {
            Name = name;
            Object = toShow;
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
