using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameObject : IGameObject
    {
        public string Name { get; set; }
        public string TextLook { get; set; }
        public string TextUse { get; set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.UnknownObject;
            }
        }
        public GameObject(string name, string textLook, string textUse)
        {
            Name = name;
            TextLook = textLook;
            TextUse = textUse;
        }

        public void Look(Player p)
        {
            Console.WriteLine(TextLook);
        }

        public void Use(Player p)
        {
            Console.WriteLine(TextUse);
        }

    }
}
