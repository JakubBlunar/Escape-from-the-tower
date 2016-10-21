using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("Chest")]
    public class Chest : GameObjectBase
    {
        
        public List<GameItemBase> Items { get; set; }

        public override GameObjectType Type => GameObjectType.Chest;

        public Key Key { get; set; }

        public bool IsUnlocked { get; set; }

        public bool IsClosed { get; set; }

        public Chest() { }

        public Chest(string name, Key k = null)
        {
            Key = k;
            Name = name;
            if (Key != null) IsUnlocked = false;
            else IsUnlocked = true;
            IsClosed = true;
            Items = new List<GameItemBase>();
        }


        public override void Look(Player p)
        {
            
        }

        public override void Use(Player p)
        {
            if (IsUnlocked)
            {
                if (IsClosed)
                {
                    IsClosed = false;
                    Console.WriteLine("You opened chest " + Name + ".");
                }
                else
                {
                    IsClosed = true;
                    Console.WriteLine("You close chest " + Name + ".");
                }
            }
            else
            {
                Console.WriteLine("Chest " + Name + " is locked. Find key to unlock it.");
            }
        }
    }
}
