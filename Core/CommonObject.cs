using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    ///     Common game object that has only writing functionality.
    /// </summary>
    [XmlRoot("CommonObject")]
    public class CommonObject : GameObjectBase
    {
        public CommonObject()
        {
        }

        public CommonObject(string name, string textLook, string textUse)
        {
            Name = name;
            TextLook = textLook;
            TextUse = textUse;
        }

        public string TextLook { get; set; }
        public string TextUse { get; set; }

        public override GameObjectType Type => GameObjectType.UnknownObject;

        /// <summary>
        ///     Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Look(Player p)
        {
            Console.WriteLine(TextLook);
        }

        /// <summary>
        ///     Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            Console.WriteLine(TextUse);
        }
    }
}