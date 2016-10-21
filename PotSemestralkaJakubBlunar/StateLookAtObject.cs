using Core;
using System;
using System.Collections.Generic;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// State where player looking at some object, where he can take or put things there.
    /// </summary>
    public class StateLookAtObject : GameState
    {
        private List<string> Commands { get; }

        public IGameObject GameObject { private get; set; }

        /// <summary>
        /// Creates state look at object. Define commands available for this state.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="game">instance of game</param>
        public StateLookAtObject(String name, Game game) : base(name, game)
        {
            Commands = new List<string> {"take", "put", "look", "player", "back", "help"};

        }

        /// <summary>
        /// Main loop of this state, wait for user input, parse it and execute specified command.
        /// </summary>
        public override void Tick()
        {
            Info();    

            bool parsed = false;
            while (!parsed)
            {
                Console.WriteLine();
                Console.Write("Available commands: ");
                foreach (var c in Commands)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.Write("->  ");
                string command = Console.ReadLine();
                if (command != null)
                {
                    command = command.Trim();

                    string[] split = command.Split(DelimiterChars);

                    switch (split[0])
                    {
                        case "take":
                            if (split.Length <= 1)
                            {
                                Console.WriteLine("What do you want to take?");
                            }
                            else  Game.Player.TakeFromObject(split[1], GameObject);

                            break;
                        case "put":
                            if (split.Length <= 1)
                            {
                                Console.WriteLine("What do you want to drop?");
                            }
                            else Game.Player.PutToObject(split[1], GameObject);
                            break;
                        case "look":
                            Info();
                            break;
                        case "back":
                            Game.Manager.ChangeState("gamePlay");
                            parsed = true;
                            break;
                        case "player":
                            Game.Player.Info();
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
            }
        }

        /// <summary>
        /// Displays info about Object on which is player looking at.
        /// </summary>
        private void Info()
        {
            Console.Clear();

            if (GameObject.Type == GameObjectType.Bookshelf)
            {
                Bookshelf bs = (Bookshelf)GameObject;
                Console.WriteLine("You are now looking at Bookshelf: " + bs.Name);
                Console.WriteLine("Books:");
                foreach (var b in bs.Books)
                {
                    Console.Write(b.Name + ", ");
                }
            }
            else if (GameObject.Type == GameObjectType.Chest)
            {
                Chest ch = (Chest)GameObject;
                Console.WriteLine("You are now looking into Chest: " + ch.Name);
                Console.WriteLine("Items:");
                foreach (var b in ch.Items)
                {
                    Console.Write(b.Name + ", ");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Display help about available commands
        /// </summary>
        /// <param name="command">Specified command</param>
        /// <returns>detail of command</returns>
        private string Help(string command = null)
        {

            if (command == null)
            {
                foreach (string item in Commands)
                {
                    Console.WriteLine(Help(item));
                }
            }
            else
            {
                switch (command)
                {
                    case "take":
                        return "take {bookname} - take book with {bookname} from bookshelf/chest";
                    case "put":
                        return "put {bookname} - Put book with name {bookname} into bookshelf/chest";
                    case "back":
                        return "back - stop to looking at this bookshelf/chest";
                    case "look":
                        return "look - display info about object";
                    case "player":
                        return "player - display info about player";
                    default:
                        return "help [command] - list of commands or help for specified command";
                }
            }
            return "";
        }
    }
}
