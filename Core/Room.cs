using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Room
    {

        public string Name { get; set; }
        public string Detail { get; set; }
        public List<IGameObject> VisibleObjects{ get; }
        public List<IGameObject> HiddenObjects { get; }

        public Room(string name, string detail)
        {
            VisibleObjects = new List<IGameObject>();
            HiddenObjects = new List<IGameObject>();
            Name = name;
            Detail = detail;
        }

        public void onKeyUse(Key key)
        {
            foreach (var o in VisibleObjects)
            {
                if (o.Type == GameObjectType.Door)
                {
                    Door d = (Door)o;
                    if ( d.Key == key)
                    {
                        if (!d.IsUnlocked)
                        {
                            d.IsUnlocked = true;
                            Console.WriteLine("Player unlocked door: " + d.Name);
                            break;
                        }
                        else
                        {
                            if (d.AreClosed)
                            { 
                                d.IsUnlocked = false;
                                Console.WriteLine("Player locked door: " + d.Name);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Can't lock opened door!");
                            }
                        }
                    }
                }else if(o.Type == GameObjectType.Chest)
                {
                    Chest ch = (Chest)o;
                    if (ch.Key == key)
                    {
                        if (!ch.IsUnlocked)
                        {
                            ch.IsUnlocked = true;
                            Console.WriteLine("Player unlocked chest: " + ch.Name);
                            break;
                        }
                        else
                        {
                            if (ch.IsClosed)
                            {
                                ch.IsUnlocked = false;
                                Console.WriteLine("Player locked chest: " + ch.Name);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Can't lock opened chest!");
                            }
                        }
                    }
                }
            
            
            }
        }

        public void OnBookTake(Book b)
        {
            if (b.ShowsSomething)
            {
                foreach (var o in HiddenObjects)
                {
                    if( o == b.Object)
                    {
                        VisibleObjects.Add(o);
                        HiddenObjects.Remove(o);
                        Console.WriteLine("Book " + b.Name + " shows " + o.Name);
                        return;
                    }
                }

                foreach (var o in VisibleObjects)
                {
                    if (o == b.Object)
                    {
                        HiddenObjects.Add(o);
                        VisibleObjects.Remove(o);
                        Console.WriteLine("Book " + b.Name + " hide " + o.Name);
                        return;
                    }
                }

              


            }
        }


    }
}
