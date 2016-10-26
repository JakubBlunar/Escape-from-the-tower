using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Game object that represents door between two rooms.
    /// </summary>
    [XmlRoot("Doors")]
    public class Doors: GameObjectBase
    {
        public Key Key { get; set; }
        public bool IsUnlocked { get; set; }
        public string Room1 { get; set; }
        public string Room2 { get; set; }

        public bool AreClosed { get; set; }

        public override GameObjectType Type => GameObjectType.Door;

        public Doors() { }

        public Doors(string name,Room r1, Room r2,Key key = null)
        {
            Key = key;
            Room1 = r1.Name;
            Room2 = r2.Name;

            if (key != null) IsUnlocked = false;
            else IsUnlocked = true;
            AreClosed = true;
            Name = name;
        }

        /// <summary>
        /// Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
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

        /// <summary>
        /// Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            string whereTo;
            if (p.ActualRoom.Name == Room1)
            {
                whereTo = Room2;
            }
            else
            {
                whereTo = Room1;
            }
            if (AreClosed)
            {
                Console.WriteLine("You look into keyhole. Doors lead to " + whereTo);
            }else Console.WriteLine("Doors lead to " + whereTo);

        }

    }
}
