using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Game object that represents window in game.
    /// </summary>
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

        /// <summary>
        /// Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine("You are looking into window.");
            Console.WriteLine(Description);
        }

        /// <summary>
        /// Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            Console.WriteLine("Nothing happend.");
        }
    }
}
