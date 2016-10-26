using Core;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Xml.Serialization;

namespace PotSemestralkaJakubBlunar
{   
    
    /// <summary>
    /// Class loader manages game objects and how to game look. It can load and save game.
    /// </summary>
    [XmlRoot("Loader")]
    public class Loader
    {
        
        public List<Room> Rooms { get; set; }
        public Player Player { get; set; }

        public string LastRoom { get; set; }

        public Loader() { Rooms = new List<Room>();}

        public Loader(Player p = null)
        {
            Rooms = new List<Room>();
            Player = p;
        }

        /// <summary>
        /// Loads world objects.
        /// </summary>
        /// <param name="g">this game</param>
        /// <returns>First room of the game where player is located.</returns>
        public Room LoadWorld()
        {
            Room r = new Room("top_tower_room", "Room on the top of the castle tower.");
            r.VisibleObjects.Add(new Book("magic_book"));
            r.VisibleObjects.Add(new Gold("gold_pouch1", 20));


            Room r2 = new Room("staircase", "This is staircase of the tower");
            Room r3 = new Room("outside", "");
            Room r4 = new Room("middle_tower_room", "Room in the middle of the castle tower");

            

            Key k = new Key("cooper_key");
            Doors d1 = new Doors("rusty_door", r, r2, k);
            Doors d2 = new Doors("golden_door",r2,r3,k);
            Doors d3 = new Doors("wooden_door", r2, r4);

            r2.VisibleObjects.Add(d2);
            r2.VisibleObjects.Add(d3);
            r4.VisibleObjects.Add(d3);

            Bookshelf bookShelf = new Bookshelf("bookshelf1");
            bookShelf.Books.Add(new Book("basics_of_c#"));
            bookShelf.Books.Add(new Book("harry_potter", d1));
            bookShelf.Books.Add(new Book("eragon"));
            r.VisibleObjects.Add(bookShelf);

            Key k2 = new Key("small_key");
            Chest ch = new Chest("wooden_chest",k2);
            ch.Items.Add(new Gold("small_pouch",30));
            ch.Items.Add(k);

            Key k3 = new Key("golden_key");
            r4.VisibleObjects.Add(k3);

            Chest ch2 = new Chest("big_chest",k3);
            ch2.Items.Add(new GameItem("golden_sword", "Sharp and bright sword. I am sure you will find usage for it.","You swish with the sword"));


            TorchHolder th1 = new TorchHolder("torch_holder1");
            TorchHolder th2 = new TorchHolder("torch_holder2");
            TorchHolder th3 = new TorchHolder("torch_holder3", false, ch2);
            r.VisibleObjects.Add(th1);
            r.VisibleObjects.Add(th2);
            r.VisibleObjects.Add(th3);
            r.VisibleObjects.Add(k2);
            r.VisibleObjects.Add(ch);
            r.HiddenObjects.Add(d1);
            r.HiddenObjects.Add(ch2);

            r.VisibleObjects.Add(new CommonObject("small_bed", "It is just small bed. Are you sleepy?", "You fell asleep."));
            r4.VisibleObjects.Add(new CommonObject("bed", "Long bed for two people. Are you sleepy?", "You fell asleep."));

            r2.VisibleObjects.Add(d1);

            Window w1 = new Window("window", "When you look down you can see how high the tower is. You can see some lake and mountains too. ");
            r.VisibleObjects.Add(w1);
            Window w2 = new Window("slim_window", "When you look into this window you can see roof of the castle. You know you are going the right way.");
            r2.VisibleObjects.Add(w2);
            Window w3 = new Window("big_window", "When you look down, you see that you are not that high from the grass. But you can't jump from here.");
            r4.VisibleObjects.Add(w3);

            Rooms.Add(r);
            Rooms.Add(r2);
            Rooms.Add(r3);
            Rooms.Add(r4);
            LastRoom = r3.Name;

            return r;
        }
      
    }

}
