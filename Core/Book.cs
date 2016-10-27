using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    ///     Game item book, that can show or hide some gameobject in room
    /// </summary>
    [XmlRoot("Book")]
    public class Book : GameItemBase
    {
        public delegate void OnBookTake(Book b);

        public Book()
        {
        }

        public Book(string name, Doors toShow = null)
        {
            Name = name;
            Object = toShow;
        }

        public Doors Object { get; set; }

        public bool ShowsSomething => Object != null;

        public override GameObjectType Type => GameObjectType.Book;
        public event OnBookTake BookTake;

        /// <summary>
        ///     Method invoked when player is looking at this item.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine("You are reading book: " + Name);
        }

        /// <summary>
        ///     Method invoked on taking this game item
        /// </summary>
        public override void Take()
        {
            BookTake?.Invoke(this);
        }

        /// <summary>
        ///     Method invoked when player is using this item.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            Console.WriteLine("I don't know how to use this book. Maybe Look?");
        }
    }
}