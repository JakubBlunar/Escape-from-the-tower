using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotSemestralkaJakubBlunar
{
    public class StateLookAtObject : GameState
    {
        private List<string> commands { get; set; }

        public IGameObject GameObject { get; set; }

        public StateLookAtObject(String name, Game game) : base(name, game)
        {
            commands = new List<string>();
            commands.Add("take");
            commands.Add("put");
            commands.Add("look");
            commands.Add("player");
            commands.Add("back");
            commands.Add("help");
           
        }

        public override void tick()
        {
            info();    

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
                        info();
                        break;
                    case "back":
                        Game.Manager.ChangeState("gamePlay");
                        parsed = true;
                        break;
                    case "player":
                        Game.Player.Info();
                        break;
                    case "help":
                        if (split.Length == 1) help();
                        else Console.WriteLine(help(split[1]));
                        break;
                    default:
                        Console.WriteLine("I dont know what you mean. Type help for view commands.");
                        break;
                }
            }
        }

        private void info()
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

        private string help(string command = null)
        {

            if (command == null)
            {
                foreach (string item in commands)
                {
                    Console.WriteLine(help(item));
                }
            }
            else
            {
                switch (command)
                {
                    case "take":
                        return "take {bookname} - take book with {bookname} from bookshelf";
                    case "put":
                        return "put {bookname} - Put book with name {bookname} into bookshelf";
                    case "back":
                        return "back - stop to looking at this bookshelf";
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
