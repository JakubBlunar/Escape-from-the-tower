using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    class Program
    {
        public static void Main(string[] args)
        {
            Key k = new Key();
            Door d = new Door(k);
            Door d2 = new Door();

            Room r = new Room();
            r.Doors.Add(d2);
            r.Doors.Add(d);

            Gold g = new Gold();
            Player p = new Player();
            p.ActualRoom = r;
            p.TakeItem(g);


            p.UseItem(k);


            Console.ReadKey();

        }
    }
}
