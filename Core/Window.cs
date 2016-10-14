using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core
{
    public class Window : IGameObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Window;
            }
        }

        public Window() { }

        public Window(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Look(Player p)
        {
            Console.WriteLine("You are looking into window.");
            Console.WriteLine(Description);
        }

        public void Use(Player p)
        {
            Console.WriteLine("Nothing happend.");
        }
    }
}
