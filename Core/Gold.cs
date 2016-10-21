using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("Gold")]
    public class Gold : GameItemBase
    {
        public override GameObjectType Type => GameObjectType.Gold;

        public int Ammount { get; set; }

        public Gold() { }

        public Gold(string name,int ammount = 1)
        {
            Ammount = ammount;
            Name = name;
        }

        public override void Use(Player p)
        {
            
        }

        public override void Look(Player p)
        {
            Console.WriteLine("You are looking at gold pouch. It contains" + Ammount + " gold.");
        }

        public override void Take()
        {
            Console.WriteLine("You take " + Ammount + " gold.");
        }


    }
}
