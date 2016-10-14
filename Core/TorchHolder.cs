using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    public class TorchHolder : IGameObject
    {
        public string Name{ get; set; }

        public GameObjectType Type
        {
            get
            {
                return GameObjectType.TorchHolder;
            }
        }
        public IGameObject Object { get; set; }
        public bool ShowsSomething
        {
            get
            {
                return Object != null;
            }
        }

        public bool HasTorch { get; set; }

        public delegate void OnTorchHolderUse(TorchHolder holder);
        public event OnTorchHolderUse objectUse;
        
        public TorchHolder(string name,bool hasTorch = true, IGameObject toShow = null)
        {
            HasTorch = hasTorch;
            Object = toShow;
            Name = name;
        }

        public void Look(Player p)
        {
            if (HasTorch)
            {
                Console.WriteLine("You are looking at Torch holder. There is lightning torch. What to do with it?");
            }else
            {
                Console.WriteLine("You are looking at Torch holder. There is torch missing. What to do with it?");
            }
        }

        public void Use(Player p)
        {
            objectUse?.Invoke(this);
        }
    }
}
