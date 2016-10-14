using Core;
using System;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// Main chass of the game, has Player and check if game has ended.
    /// Contains main loop between game states.
    /// </summary>
    public class Game
    {

        public Loader Loader { get; set; }

        public StateManager Manager { get; set; }
        public bool IsRunning { get; set; }

        public Player Player { get; set; }
        public Room LastRoom { get; set; }

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
                if(LastRoom != null && Player.ActualRoom == LastRoom) {// check if player won
                    IsRunning = false;
                    if(Player.Inventory.Find(x=> x.Name == "golden_sword") != null)
                    {
                        Console.WriteLine("When you got outside big dragon attacked you. With your golden_sword you beat that monster.");
                        Console.WriteLine("You win!");
                    }else
                    {
                        Console.WriteLine("When you got outside big dragon attacked you. You didn't have something to use for defense. Monster have eaten you.");
                        Console.WriteLine("You lose!");
                    }
                   
                    break;
                }
                Manager.Tick();
            }   

        }
                

    }
}
