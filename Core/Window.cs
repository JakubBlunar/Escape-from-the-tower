using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("Window")]
    public class Window : GameObjectBase
    {
        public string Description { get; set; }

        public override GameObjectType Type => GameObjectType.Window;

        public Window() { }

        public Window(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override void Look(Player p)
        {
            Console.WriteLine("You are looking into window.");
            Console.WriteLine(Description);
        }

        public override void Use(Player p)
        {
            Console.WriteLine("Nothing happend.");
        }
    }
}
