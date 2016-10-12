using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Player
    {
        public Room ActualRoom { get; set; }

        public int MoneyCollected { get; set; }

        public List<IGameItem> Inventory { get; private set; }

        public Player()
        {
            Inventory = new List<IGameItem>();
        }

        public void TakeItem(IGameItem item)
        {
            if(item.type == GameObjectType.Gold)
            {
                Gold g = (Gold)item;
                MoneyCollected += g.Ammount;
                Console.WriteLine("Player took " + g.Ammount + " gold");
            }else
            {
                Inventory.Add(item);
            }
        }

        public void UseItem(IGameItem item)
        {
            switch (item.type)
            {
                case GameObjectType.Key:
                    Key k = (Key)item;
                    k.itemUse += ActualRoom.onKeyUse;
                    k.use();
                    break;
                default:
                    item.use();
                    break;
            }
           
        }

    }
}
