using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    ///     Item gold pouch that contain some ammount of gold.
    /// </summary>
    [XmlRoot("Gold")]
    public class Gold : GameItemBase
    {
        public Gold()
        {
        }

        public Gold(string name, int ammount = 1)
        {
            Ammount = ammount;
            Name = name;
        }

        public override GameObjectType Type => GameObjectType.Gold;

        public int Ammount { get; set; }

        /// <summary>
        ///     Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            // nothing, on take game remove item
        }

        /// <summary>
        ///     Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine("You are looking at gold pouch. It contains" + Ammount + " gold.");
        }

        /// <summary>
        ///     Method invoked on taking this game item
        /// </summary>
        public override void Take()
        {
            Console.WriteLine("You take " + Ammount + " gold.");
        }
    }
}