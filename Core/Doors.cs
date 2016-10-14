using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public class Doors: IGameObject
    {
        public Key Key { get; private set; }
        public bool IsUnlocked { get; set; }
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }

        public bool AreClosed { get; set; }

        public string Name { get; set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Door;
            }
        }

        public Doors(string name,Room r1, Room r2,Key key = null)
        {
            Key = key;
            Room1 = r1;
            Room2 = r2;

            if (key != null) IsUnlocked = false;
            else IsUnlocked = true;
            AreClosed = true;
            Name = name;
        }

        public void Use(Player p)
        {
            if (IsUnlocked)
            {
                if (AreClosed)
                {
                    AreClosed = false;
                    Console.WriteLine("You opened Door " + Name + ".");
                }else
                {
                    AreClosed = true;
                    Console.WriteLine("You close Door " + Name + ".");
                }
            }else
            {
                Console.WriteLine("Door " + Name + " are locked. Find key to unlock them.");
            }
        }

        public void Look(Player p)
        {
            string whereTo;
            if (p.ActualRoom.Name == Room1.Name)
            {
                whereTo = Room2.Name;
            }
            else
            {
                whereTo = Room1.Name;
            }
            if (AreClosed)
            {
                Console.WriteLine("You look into keyhole. Doors lead to " + whereTo);
            }else Console.WriteLine("Doors lead to " + whereTo);

        }

    }
}
