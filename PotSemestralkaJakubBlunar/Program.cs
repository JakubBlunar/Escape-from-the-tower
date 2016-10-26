using System;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Program is Class just for entry point for game.
    /// </summary>
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            var g = new Game();
            g.Start();
            Console.ReadKey();
        }
    }
}
