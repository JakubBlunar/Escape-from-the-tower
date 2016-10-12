using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Gold : IGameItem
    {
        public GameObjectType type
        {
            get
            {
                return GameObjectType.Gold;
            }
        }
     
        public int Ammount { get; private set; }

        public Gold(int ammount = 1)
        {
            Ammount = ammount;
        }

        public void use()
        {
            Console.WriteLine("Player is looking at" + Ammount + " gold.");
        }


    }
}
