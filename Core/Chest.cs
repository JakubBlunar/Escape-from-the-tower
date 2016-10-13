using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Chest : IGameObject
    {
        public List<IGameItem> Items { get; private set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Chest;
            }
        }

        public string Name { get; set; }

        public Key Key { get; private set; }
        public bool IsUnlocked { get; set; }
        public bool IsClosed { get; set; }

        public Chest(string name, Key k = null)
        {
            Key = k;
            Name = name;
            if (Key != null) IsUnlocked = false;
            else IsUnlocked = true;
            IsClosed = true;
            Items = new List<IGameItem>();
        }


        public void Look(Player p)
        {
            
        }

        public void Use(Player p)
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
