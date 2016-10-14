using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core
{
    public class Room
    {
        
        public string Name { get; set; }
        
        public string Detail { get; set; }

       
        public List<IGameObject> VisibleObjects{ get; set; }
        public List<IGameObject> HiddenObjects { get; set; }

        public Room(string name, string detail)
        {
            VisibleObjects = new List<IGameObject>();
            HiddenObjects = new List<IGameObject>();
            Name = name;
            Detail = detail;
        }

        public Room()
        {

        }


        public void onKeyUse(Key key)
        {
            foreach (var o in VisibleObjects)
            {
                if (o.Type == GameObjectType.Door)
                {
                    Doors d = (Doors)o;
                    if ( d.Key.Name == key.Name)
                    {
                        if (!d.IsUnlocked)
                        {
                            d.IsUnlocked = true;
                            Console.WriteLine("You have unlocked door: " + d.Name);
                            break;
                        }
                        else
                        {
                            if (d.AreClosed)
                            { 
                                d.IsUnlocked = false;
                                Console.WriteLine("You have locked door: " + d.Name);
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
                    if (ch.Key.Name == key.Name)
                    {
                        if (!ch.IsUnlocked)
                        {
                            ch.IsUnlocked = true;
                            Console.WriteLine("You have unlocked chest: " + ch.Name);
                            break;
                        }
                        else
                        {
                            if (ch.IsClosed)
                            {
                                ch.IsUnlocked = false;
                                Console.WriteLine("You have locked chest: " + ch.Name);
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
                IGameObject gameObject = HiddenObjects.Find(x => x.Name == b.Object.Name);
                if (gameObject != null)
                {
                    VisibleObjects.Add(gameObject);
                    HiddenObjects.Remove(gameObject);
                    Console.WriteLine("Book: " + b.Name + " shows object " + gameObject.Name);
                    return;
                }

                gameObject = VisibleObjects.Find(x => x.Name == b.Object.Name);
                if (gameObject != null)
                {
                    HiddenObjects.Add(gameObject);
                    VisibleObjects.Remove(gameObject);
                    Console.WriteLine("Book: " + b.Name + " hide object " + gameObject.Name);
                    return;
                }
            }
            
        }

        public void OnTorchHolderUse(TorchHolder holder)
        {
            if (holder.ShowsSomething)
            {
                IGameObject gameObject = HiddenObjects.Find(x => x.Name == holder.Object.Name);
                if(gameObject != null)
                {
                    VisibleObjects.Add(gameObject);
                    HiddenObjects.Remove(gameObject);
                    Console.WriteLine("Torch holder: " + holder.Name + " shows " + gameObject.Name);
                    return;
                }

                gameObject = VisibleObjects.Find(x => x.Name == holder.Object.Name);
                if(gameObject!= null)
                {
                    HiddenObjects.Add(gameObject);
                    VisibleObjects.Remove(gameObject);
                    Console.WriteLine("Torch holder: " + holder.Name + " hide " + gameObject.Name);
                    return;
                }

            }else
            {
                Console.WriteLine("Using torch holder had no effect.");
            }
        }


    }
}
