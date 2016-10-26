using Core;
using System;
using System.Collections.Generic;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// State of the game, when player is at some room.
    /// </summary>
    public class StateGamePlay : GameState
    {
        private List<string> Commands { get; }

        /// <summary>
        /// Creates state game play. Define commands available for this state.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="game">instance of game</param>
        public StateGamePlay(String name, Game game) : base(name, game)
        {
            Commands = new List<string> {"go", "look", "take", "put", "use", "player", "save", "load"};
        }

        /// <summary>
        /// Main loop of this state, wait for user input, parse it and execute specified command.
        /// </summary>
        public override void Tick()
        {

            Console.Clear();
            Room actual = Game.Player.ActualRoom;
            Console.WriteLine("You are now in: " + actual.Name);
            Console.WriteLine("   " + actual.Detail);

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
                        case "go":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("Where do you want to go?");
                            }
                            else parsed = Game.Player.Go(split[1]);
                            if (parsed)
                            {
                                Game.Loader.Player.ActualRoom = Game.Loader.Rooms.Find(x => x.Name == Game.Player.NameOfActualRoom);
                            }
                            break;
                        case "look":
                            if (split.Length == 1)
                            {
                                Info();
                            }
                            else
                            {
                                IGameObject o = Game.Player.Look(split[1]);
                                if(o != null)
                                {
                                    if (o.Type == GameObjectType.Chest || o.Type == GameObjectType.Bookshelf)
                                    {
                                        StateLookAtObject state = (StateLookAtObject)Game.Manager.GetGameState("lookAtObject");
                                        state.GameObject = o;
                                        Game.Manager.ChangeState("lookAtObject");
                                        parsed = true;
                                    }
                                }
                            }
                            break;
                        case "take":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("What do you want to take?");
                            }
                            else Game.Player.TakeItem(split[1]);
                            break;
                        case "put":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("Which item do you want to drop?");
                            }
                            else Game.Player.DropItem(split[1]);

                            break;
                        case "use":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("What do you want to use?");
                            }
                            else Game.Player.UseItem(split[1]);
                            break;
                        case "player":
                            Game.Player.Info();
                            break;

                        case "save":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("Where do you want to save?");
                            }
                            else
                            {
                                Game.Save(split[1]);

                            }
                            break;
                        case "load":
                            if (split.Length == 1)
                            {
                                Console.WriteLine("From what file you want to load?");
                            }
                            else
                            {
                                Game.Load(split[1]);

                            }
                            break;
                        case "help":
                            if (split.Length == 1)
                            {
                                Help();
                            }
                            else Console.WriteLine(Help(split[1]));
                            break;
                        default:
                            Console.WriteLine("I dont know what you mean.\n Type help for view commands.");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Shows info about actual players room.
        /// </summary>
        private void Info()
        {
            Console.Clear();
            Room actual = Game.Player.ActualRoom;

            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", Game.Timer.Elapsed);
            Console.WriteLine("You are now in: " + actual.Name);
            Console.WriteLine("   " + actual.Detail);
            Console.WriteLine("Objects in room :");
            foreach (var o in actual.VisibleObjects)
            {
                Console.Write(o.Name + ", ");
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
                    case "go":
                        return "go {roomName} - go to room named {roomName}";
                    case "look":
                        return "look {object name} - look at specified object or display visible objects";
                    case "take":
                        return "take {item name} - take specified item";
                    case "put":
                        return "put {item name} - put specified item from inventory into room";
                    case "use":
                        return "use {item name} - use specified item";      
                    case "player":
                        return "player - display info about player";
                    case "save":
                        return "save {filename} - save game into file named {filename}.xml";
                    case "load":
                        return "load {filename} - load game from file named {filename}.xml";
                    default:
                        return "help [command] - list of commands or help for specified command";
                }
            }
            return "";
        }
    }
}
