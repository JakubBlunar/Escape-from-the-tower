using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("CommonObject")]
    public class CommonObject : GameObjectBase
    {
        public string TextLook { get; set; }
        public string TextUse { get; set; }

        public override GameObjectType Type => GameObjectType.UnknownObject;

        public CommonObject() { }

        public CommonObject(string name, string textLook, string textUse)
        {
            Name = name;
            TextLook = textLook;
            TextUse = textUse;
        }

        public override void Look(Player p)
        {
            Console.WriteLine(TextLook);
        }

        public override void Use(Player p)
        {
            Console.WriteLine(TextUse);
        }

    }
}
