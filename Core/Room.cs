using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Room
    {

        public List<Door> Doors{ get; }

        public Room()
        {
            Doors = new List<Door>();
        }

        public void onKeyUse(Key key, EventArgs args)
        {
            foreach(Door d in Doors)
            {
                if(d.Key == key)
                {
                    d.IsUnlocked = true;
                    Console.WriteLine("unlocking doors" + d.GetHashCode());
                }
            }
        }


    }
}
