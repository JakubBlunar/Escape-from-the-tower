using Core;

namespace PotSemestralkaJakubBlunar
{
    public class Loader
    {
        public static Room LoadWorld()
        {
            Room r = new Room("room1", "Room on the top of the castle tower.");
            Room r2 = new Room("staircase1", "This is staircase of the tower");
            Key k = new Key("cooper_key");
            Door d1 = new Door("rusty_door1", r, r2, k);

            Bookshelf bookShelf = new Bookshelf("bookshelf1");
            bookShelf.Books.Add(new Book("basics_of_c#"));
            bookShelf.Books.Add(new Book("harry_potter", d1));
            bookShelf.Books.Add(new Book("eragon"));

            Key k2 = new Key("small_key");
            Chest ch = new Chest("wooden_chest",k2);
            ch.Items.Add(new Gold("small_pouch",30));
            ch.Items.Add(k);
        
            r.VisibleObjects.Add(k2);
            r.VisibleObjects.Add(ch);
            r.HiddenObjects.Add(d1);

            r.VisibleObjects.Add(new Book("magic_book"));
            r.VisibleObjects.Add(new Gold("gold_pouch1", 20));
            r.VisibleObjects.Add(bookShelf);

            r2.VisibleObjects.Add(d1);

            return r;
        }
    }

}
