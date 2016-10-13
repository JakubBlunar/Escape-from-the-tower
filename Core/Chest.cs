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

        
        public Chest(string name)
        {
            Name = name;
            Items = new List<IGameItem>();
        }


        public void Look(Player p)
        {
            
        }

        public void Use(Player p)
        {
            Console.WriteLine("How can you use Chest? Maybe look?");
        }
    }
}
