using System;
using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("TorchHolder")]
    public class TorchHolder : GameObjectBase
    {
        public override GameObjectType Type => GameObjectType.TorchHolder;
        public GameObjectBase Object { get; set; }
        public bool ShowsSomething => Object != null;

        public bool HasTorch { get; set; }

        public delegate void OnTorchHolderUse(TorchHolder holder);
        public event OnTorchHolderUse ObjectUse;
        
        public TorchHolder() { }

        public TorchHolder(string name,bool hasTorch = true, GameObjectBase toShow = null)
        {
            HasTorch = hasTorch;
            Object = toShow;
            Name = name;
        }

        public override void Look(Player p)
        {
            if (HasTorch)
            {
                Console.WriteLine("You are looking at Torch holder. There is lightning torch. What to do with it?");
            }else
            {
                Console.WriteLine("You are looking at Torch holder. There is torch missing. What to do with it?");
            }
        }

        public override void Use(Player p)
        {
            ObjectUse?.Invoke(this);
        }
    }
}
