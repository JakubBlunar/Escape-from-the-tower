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

            using (var db = new ScoreContext())
            {
                db.Scores.Add(new Score("jakub",new TimeSpan(0,5,0), DateTime.Now));
                db.SaveChanges();

                
            }

            var g = new Game();
            g.Start();
            Console.ReadKey();
        }
    }
}
