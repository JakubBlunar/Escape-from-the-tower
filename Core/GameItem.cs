using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// General game item, that has only writing into console functionality.
    /// </summary>
    [XmlRoot("GameItem")]
    public class GameItem : GameItemBase
    {
        public string TextLook { get; set; }
       
        public string TextUse { get; set; }

        public override GameObjectType Type => GameObjectType.UnknownItem;

        public GameItem() { }

        public GameItem(string name,string textLook, string textUse)
        {
            Name = name;
            TextLook = textLook;
            TextUse = textUse;
        }

        /// <summary>
        /// Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine(TextLook);
        }

        /// <summary>
        /// Method invoked on taking this game item
        /// </summary>
        public override void Take()
        {
            
        }

        /// <summary>
        /// Method invoked when player is using this item.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            Console.WriteLine(TextUse);
        }

     
    }
}
