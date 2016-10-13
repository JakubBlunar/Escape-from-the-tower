using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IGameObject
    {
        GameObjectType Type { get; }
        string Name { get; set; }

        void Use(Player p);
        void Look(Player p);
      
    }
}
