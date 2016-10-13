using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Key: IGameItem
    {
        public GameObjectType Type { get { return GameObjectType.Key; } }

        public delegate void OnItemUse(Key item);
        public event OnItemUse itemUse;

        public string Name { get; set; }

        public Key(string name)
        {
            Name = name;
        }


        public void Use(Player p)
        {
            itemUse?.Invoke(this);
        }

        public void Take()
        {

        }

        public void Look(Player p)
        {
            Console.WriteLine(Name + " can unlock some door.");
        }

    }
}
