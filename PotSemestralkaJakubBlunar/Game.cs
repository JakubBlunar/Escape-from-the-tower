using Core;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Main chass of the game, has Player and check if game has ended.
    /// Contains main loop between game states.
    /// </summary>
    public class Game
    {
        public MyStopwatch Timer { get; set; }

        public Loader Loader { get; private set; }
        public StateManager Manager { get; }
        public bool IsRunning { private get; set; }  
        public Player Player { get; set; }

        /// <summary>
        /// Constructor creates new game with game states needed for run.
        /// </summary>
        public Game()
        {
            Loader = new Loader();
            IsRunning = false;
            GameState mm = new StateMainMenu("mainMenu",this);
            Manager = new StateManager(mm);
            Manager.AddState(new StateGamePlay("gamePlay",this));
            Manager.AddState(new StateLookAtObject("lookAtObject", this));
            Console.Title = "Escape from the Tower!";
            Timer = new MyStopwatch(new TimeSpan());
        }
        
        /// <summary>
        /// Method Start starts new game, goes inside main loop and checking for end.
        /// </summary>
        public void Start()
        {
            if (IsRunning) return;
            IsRunning = true;

            while (IsRunning)
            {
                if(Player!= null && Player.ActualRoom.Name == Loader.LastRoom) {// check if player won
                    IsRunning = false;
                    if(Player.Inventory.Find(x=> x.Name == "golden_sword") != null)
                    {
                        Console.WriteLine("When you got outside big dragon attacked you. With your golden_sword you beat that monster.");
                        Console.WriteLine("You win!");
                        Timer.Stop();
                        try
                        {
                            using (var db = new ScoreContext())
                            {
                                db.Scores.Add(new Score(Player.Name, Timer.Elapsed, DateTime.Now, Player.MoneyCollected));
                                db.SaveChanges();
                            }
                        }
                        catch
                        {
                            //ignore
                        }

                    }
                    else
                    {
                        Console.WriteLine("When you got outside big dragon attacked you. You didn't have something to use for defense. Monster have eaten you.");
                        Console.WriteLine("You lose!");
                    }
                   
                    break;
                }
                Manager.Tick();
            }   

        }

        /// <summary>
        /// Same actual state to game into xml file using serialization.
        /// </summary>
        /// <param name="paFile">name of file</param>
        /// <returns>if save was succesfull</returns>
        public void Save(string paFile)
        {
            bool succes;
            XmlSerializer serializer = new XmlSerializer(typeof(Loader));
            using (FileStream file = new FileStream("./"+paFile+".xml", FileMode.Create))
            {
                try
                {
                    serializer.Serialize(file, Loader);

                    using (var f = new StreamWriter("./" + paFile))
                    {
                        f.WriteLine(Timer.Elapsed.Hours);
                        f.WriteLine(Timer.Elapsed.Minutes);
                        f.WriteLine(Timer.Elapsed.Seconds);

                    }


                    succes = true;
                }catch
                {
                    succes = false;
                }
            }

            if (succes)
            {
                Console.WriteLine("Game has been saved into file: " + paFile + ".xml");
            }
            else
            {
                Console.WriteLine("Error with saving game.");
            }

            

        }

        /// <summary>
        /// Load game from specified xml file.
        /// </summary>
        /// <param name="paFile">Name of the file</param>
        /// <returns>If game was succesfully loaded.</returns>
        public bool Load(string paFile)
        {
            string fileName = "./" + paFile + ".xml";

            if (File.Exists(fileName))
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Loader));
                    try
                    {
                        var l = (Loader)serializer.Deserialize(file);
                        Loader = l;
                        Player = Loader.Player;
                        Player.SetActualRoom(Loader.Rooms.Find(x => x.Name == Player.NameOfActualRoom));
                        using (var f = new StreamReader("./" + paFile))
                        {
                            try
                            {
                                int h = int.Parse(f.ReadLine());
                                int m = int.Parse(f.ReadLine());
                                int s = int.Parse(f.ReadLine());
                                TimeSpan tm = new TimeSpan(h, m, s);
                                Timer = new MyStopwatch(tm);
                                Timer.Restart();
                            }
                            catch
                            {
                                return false;
                            }

                        }

                        return true;
                    }
                    catch
                    {
                        Console.WriteLine("Game cannot be loaded from : " + paFile + ".xml");
                        return false;
                    }
                }
            }
            else
            {
                
                Console.WriteLine("File " + fileName + " don't exists.");
                return false;
            }

        }       

    }
}
