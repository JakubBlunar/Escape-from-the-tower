using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("Key")]
    public class Key: GameItemBase
    {

        public override GameObjectType Type => GameObjectType.Key;

        public delegate void OnItemUse(Key item);
        public event OnItemUse ItemUse;

        public Key() { }

        public Key(string name)
        {
            Name = name;
        }

        public override void Use(Player p)
        {
            ItemUse?.Invoke(this);
        }

        public override void Take()
        {

        }

        public override void Look(Player p)
        {
            Console.WriteLine(Name + " can unlock some door or chest.");
        }

    }
}
