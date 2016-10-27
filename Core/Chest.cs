using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    ///     Object in game chest, that can contain various game items.
    /// </summary>
    [XmlRoot("Chest")]
    public class Chest : GameObjectBase
    {
        public Chest()
        {
        }

        public Chest(string name, Key k = null)
        {
            Key = k;
            Name = name;
            if (Key != null) IsUnlocked = false;
            else IsUnlocked = true;
            IsClosed = true;
            Items = new List<GameItemBase>();
        }

        public List<GameItemBase> Items { get; set; }

        public override GameObjectType Type => GameObjectType.Chest;

        public Key Key { get; set; }

        public bool IsUnlocked { get; set; }

        public bool IsClosed { get; set; }

        /// <summary>
        ///     Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            //nothing here, game context changes state to state looking at object
        }

        /// <summary>
        ///     Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            if (IsUnlocked)
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
            else
                Console.WriteLine("Chest " + Name + " is locked. Find key to unlock it.");
        }
    }
}