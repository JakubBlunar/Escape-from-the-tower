using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Program is Class just for entry point for game.
    /// </summary>
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Game g = new Game();
            g.Start();
            

            /*
            GameItem k = new GameItem("fold","look","use");

            XmlSerializer serializer = new XmlSerializer(typeof(GameItem));
            FileStream file = new FileStream("test.xml", FileMode.Create);

            serializer.Serialize(Console.Out, k);
            serializer.Serialize(file, k);
            file.Close();

            file = new FileStream("test.xml", FileMode.Open);
            k = (GameItem)serializer.Deserialize(file);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(k.Name);
            */

            Console.ReadKey();

        }
    }
}
