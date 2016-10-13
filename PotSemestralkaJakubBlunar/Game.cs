using System;

namespace PotSemestralkaJakubBlunar
{
    public class Game
    {
        public StateManager Manager { get; private set; }
        public bool IsRunning { get; set; }

        public Core.Player Player { get; set; }

        public Game()
        {
            IsRunning = false;
            GameState mm = new StateMainMenu("mainMenu",this);
            Manager = new StateManager(mm);
            Manager.AddState(new StateGamePlay("gamePlay",this));
            Manager.AddState(new StateLookAtObject("lookAtObject", this));
        }

        public void start()
        {
            if (IsRunning) return;
            IsRunning = true;

            while (IsRunning)
            {
                Manager.tick();
            }

            Console.WriteLine("You exited game.");

        }        

    }
}
