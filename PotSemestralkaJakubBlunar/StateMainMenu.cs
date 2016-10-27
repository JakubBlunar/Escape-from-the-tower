using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    ///     State when game is started.
    /// </summary>
    public class StateMainMenu : GameState
    {
        /// <summary>
        ///     Creates state main menu. Define commands available for this state.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="game">instance of game</param>
        public StateMainMenu(string name, Game game) : base(name, game)
        {
            Commands = new List<string> {"new_game", "load", "exit", "help", "highscore"};
        }

        private List<string> Commands { get; }

        /// <summary>
        ///     Method for parsing inserted commands.
        /// </summary>
        public override void Tick()
        {
            Console.Clear();

            var parsed = false;
            while (!parsed)
            {
                Console.Write("Available commands: ");
                foreach (var c in Commands)
                    Console.Write(c + " ");
                Console.WriteLine();
                Console.Write("->  ");
                var command = Console.ReadLine();
                if (command != null)
                {
                    command = command.Trim();

                    var split = command.Split(DelimiterChars);

                    switch (split[0])
                    {
                        case "new_game":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("You forgot to enter your name. help new_game for info.");
                            }
                            else
                            {
                                var p = new Player(split[1]);
                                Game.Player = p;
                                Game.Loader.Player = p;
                                p.SetActualRoom(Game.Loader.LoadWorld());

                                Console.Clear();
                                Console.WriteLine(
                                    "You woke up in big castle tower. You don't know how did you get there. But you want to get out of there!");
                                Console.WriteLine();
                                Console.WriteLine("So let the game begin!. Find the way out.");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();

                                Game.Manager.ChangeState("gamePlay");
                                Game.Timer.Start();
                                parsed = true;
                            }
                            break;
                        case "load":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("From what file you want to load?");
                            }
                            else
                            {
                                if (Game.Load(split[1]))
                                {
                                    Game.Manager.ChangeState("gamePlay");
                                    parsed = true;
                                }
                            }
                            break;
                        case "exit":
                            Console.WriteLine("You exited game.");
                            Game.IsRunning = false;
                            parsed = true;
                            break;
                        case "highscore":
                            try
                            {
                                using (var db = new ScoreContext())
                                {
                                    var count = 1;
                                    var data = (from p in db.Scores orderby p.H, p.M, p.S select p).Take(10).ToList();
                                    foreach (var score in data)
                                    {
                                        Console.WriteLine(
                                            "{0}. Name: {1}   Time: {2}H {3}m {4}s   Gold: {5}   Pc: {6}", count,
                                            score.NameOfPlayer, score.H, score.M, score.S, score.MoneyCollected,
                                            score.NameOfPc);
                                        count++;
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Nothing to display");
                            }
                            break;
                        case "help":
                            if (split.Length == 1) Help();
                            else Console.WriteLine(Help(split[1]));
                            break;
                        default:
                            Console.WriteLine("I dont know what you mean. Type help for view commands.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Display help about available commands
        /// </summary>
        /// <param name="command">Specified command</param>
        /// <returns>detail of command</returns>
        private string Help(string command = null)
        {
            if (command == null)
                foreach (var item in Commands)
                    Console.WriteLine(Help(item));
            else
                switch (command)
                {
                    case "new_game":
                        return "new_game {playerName} - starts new game with player named {playername}";
                    case "load":
                        return "load {filename} - load game from file named {filename}.xml";
                    case "exit":
                        return "exit - exit game";
                    default:
                        return "help [command] - list of commands or help for specified command";
                }
            return "";
        }
    }
}