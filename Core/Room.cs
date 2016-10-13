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
                }
            
            
            }
        }

        public void OnBookTake(Book b)
        {
            if (b.ShowsSomething)
            {
                Door d = null;
                foreach (var o in HiddenObjects)
                {
                    if( o == b.Door)
                    {
                        d = (Door)o;
                        break;
                    }
                }

                if(d != null)
                {
                    VisibleObjects.Add(d);
                    HiddenObjects.Remove(d);
                    Console.WriteLine("Book " + b.Name + " shows door " + d.Name);
                    d = null;
                    return;
                }

                foreach (var o in VisibleObjects)
                {
                    if (o == b.Door)
                    {
                        d = (Door)o;
                        break;
                    }
                }

                if (d != null)
                {
                    HiddenObjects.Add(d);
                    VisibleObjects.Remove(d);
                    Console.WriteLine("Book " + b.Name + " hide door " + d.Name);
                    d = null;
                    return;
                }


            }
        }


    }
}
