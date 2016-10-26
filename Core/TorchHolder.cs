using System;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Game object that can show or hide some another object in room
    /// </summary>
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

        /// <summary>
        /// Method invoked when player is looking at this object.
        /// </summary>
        /// <param name="p">actual player</param>
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

        /// <summary>
        /// Method invoked when player is using this object.
        /// </summary>
        /// <param name="p">actual player</param>
        public override void Use(Player p)
        {
            ObjectUse?.Invoke(this);
        }
    }
}
