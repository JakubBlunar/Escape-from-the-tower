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
    
    public class Gold : IGameItem, IXmlSerializable
    {
        public GameObjectType Type
        {
            get
            {
                return GameObjectType.Gold;
            }
        }
     
        public int Ammount { get; private set; }

        public string Name { get; set; }

        public Gold() { }

        public Gold(string name,int ammount = 1)
        {
            Ammount = ammount;
            Name = name;
        }

        public void Use(Player p)
        {
            
        }

        public void Look(Player p)
        {
            Console.WriteLine("You are looking at gold pouch. It contains" + Ammount + " gold.");
        }

        public void Take()
        {
            Console.WriteLine("You take " + Ammount + " gold.");
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Name = reader.ReadString();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Name);
        }
    }
}
