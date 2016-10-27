using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    ///     Game item, key, that is used for unlocking chests or doors
    /// </summary>
    [XmlRoot("Key")]
    public class Key : GameItemBase
    {
        public delegate void OnItemUse(Key item);

        public Key()
        {
        }

        public Key(string name)
        {
            Name = name;
        }

        public override GameObjectType Type => GameObjectType.Key;
        public event OnItemUse ItemUse;

        /// <summary>
        ///     Method invoked when player is using this item.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            ItemUse?.Invoke(this);
        }

        /// <summary>
        ///     Method invoked on taking this game item
        /// </summary>
        public override void Take()
        {
        }

        /// <summary>
        ///     Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine(Name + " can unlock some door or chest.");
        }
    }
}