using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("Book")]
    public class Book : GameItemBase
    {
        public Doors Object { get; set; }

        public bool ShowsSomething => Object != null;

        public override GameObjectType Type => GameObjectType.Book;

        public delegate void OnBookTake(Book b);
        public event OnBookTake BookTake;

        public Book() { }


        public Book(string name, Doors toShow = null)
        {
            Name = name;
            Object = toShow;
        }

        public override void Look(Player p)
        {
            Console.WriteLine("You are reading book: " + Name);
        }

        public override void Take()
        {
            BookTake?.Invoke(this);
        }

        public override void Use(Player p)
        {
            Console.WriteLine("I don't know how to use this book. Maybe Look?");
        }
    }
}
