using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Gold : IGameItem
    {
        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Gold;
            }
        }
     
        public int Ammount { get; private set; }

        public string Name { get; set; }


        public Gold(string name,int ammount = 1)
        {
            Ammount = ammount;
            Name = name;
        }

        public void Use(Player p)
        {
            
        }

        public void Look(Player p)
        {
            Console.WriteLine("Player is looking at gold pouch. It contains" + Ammount + " gold.");
        }

        public void Take()
        {
            Console.WriteLine("You took " + Ammount + " gold.");
        }

    }
}
