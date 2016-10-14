using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    /// <summary>
    /// State of the game, when player is at some room.
    /// </summary>
    public class StateGamePlay : GameState
    {
        private List<string> commands { get; set; }

        /// <summary>
        /// Creates state game play. Define commands available for this state.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="game">instance of game</param>
        public StateGamePlay(String name, Game game) : base(name, game)
        {
            commands = new List<string>();
            commands.Add("go");
            commands.Add("look");
            commands.Add("take");
            commands.Add("put");
            commands.Add("use");
            commands.Add("player");
            
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
                    case "go":
                        if (split.Length == 1)
                        {
                            Console.WriteLine("Where do you want to go?");
                        }
                        else parsed = Game.Player.go(split[1]);
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

        /// <summary>
        /// Shows info about actual players room.
        /// </summary>
        public void Info()
        {
            Console.Clear();
            Room actual = Game.Player.ActualRoom;
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
                foreach (string item in commands)
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
                    default:
                        return "help [command] - list of commands or help for specified command";
                }
            }
            return "";
        }
    }
}
