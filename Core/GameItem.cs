using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("GameItem")]
    public class GameItem : IGameItem
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("TextLook")]
        public string TextLook { get; set; }

        [XmlAttribute("TextUse")]
        public string TextUse { get; set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.UnknownItem;
            }
        }

        public GameItem() { }

        public GameItem(string name,string textLook, string textUse)
        {
            Name = name;
            TextLook = textLook;
            TextUse = textUse;
        }

        public void Look(Player p)
        {
            Console.WriteLine(TextLook);
        }

        public void Take()
        {
            
        }

        public void Use(Player p)
        {
            Console.WriteLine(TextUse);
        }

     
    }
}
