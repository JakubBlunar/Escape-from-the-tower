using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public class StateMainMenu:GameState
    {
        private List<string> commands { get; set; }

        public StateMainMenu(String name,Game game): base(name,game)
        {
            commands = new List<string>();
            commands.Add("new_game");
            commands.Add("exit");
            commands.Add("help");
        }

        public override void tick()
        {
            Console.Clear();

            bool parsed = false;
            while (!parsed)
            {   
                Console.Write("Available commands: ");
                foreach (var c in commands)
                {
                    Console.Write(c.ToString() + " ");
                }
                Console.WriteLine();
                Console.Write("->  ");
                string command = Console.ReadLine();
                command = command.Trim();

                string[] split = command.Split(delimiterChars);

                switch (split[0])
                {
                    case "new_game":
                        if (split.Length == 1)
                        {
                            Console.WriteLine("You forgot to enter your name. help new_game for info.");
                        }
                        else {
                            Player p = new Player(split[1]);
                            Game.Player = p;
                            p.ActualRoom = Loader.LoadWorld();            
                            Game.Manager.ChangeState("gamePlay");
                            parsed = true;
                        }
                        break;
                    case "exit":
                        Game.IsRunning = false;
                        parsed = true;
                        break;
                    case "help":
                        if (split.Length == 1) {
                            help();
                        }
                        else Console.WriteLine(help(split[1]));
                        break;
                    default:
                        Console.WriteLine("I dont know what you mean. Type help for view commands.");
                        break;
                }
                Console.WriteLine();
            }
        }
        private string help(string command = null)
        {
            
            if (command == null)
            {
                foreach (string item in commands)
                {
                    Console.WriteLine(help(item));
                }
            }else
            {
                switch (command)
                {
                    case "new_game":
                        return "new_game {playerName} - starts new game with player named {playername}";
                    case "exit":
                        return "exit - exit game";
                    default :
                        return "help [command] - list of commands or help for specified command";
                }
            }
            return "";
        }
    }
}
