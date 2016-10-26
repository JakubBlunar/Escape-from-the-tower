using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Class that represents game room, that contains all objects and items
    /// </summary>
    [XmlRoot("Room")]
    public class Room
    {
        
        public string Name { get; set; }
        
        public string Detail { get; set; }

        public List<GameObjectBase> VisibleObjects{ get; set; }
        public List<GameObjectBase> HiddenObjects { get; set; }

        public Room() { }

        public Room(string name, string detail)
        {
            VisibleObjects = new List<GameObjectBase>();
            HiddenObjects = new List<GameObjectBase>();
            Name = name;
            Detail = detail;
        }

        /// <summary>
        /// Handler on event of using key.
        /// </summary>
        /// <param name="key">key that was used</param>
        public void OnKeyUse(Key key)
        {
            foreach (var o in VisibleObjects)
            {
                if (o.Type == GameObjectType.Door)
                {
                    Doors d = (Doors)o;
                    if (d.Key!= null && d.Key.Name == key.Name)
                    {
                        if (!d.IsUnlocked)
                        {
                            d.IsUnlocked = true;
                            Console.WriteLine("You have unlocked door: " + d.Name);
                            break;
                        }

                        if (d.AreClosed)
                        { 
                            d.IsUnlocked = false;
                            Console.WriteLine("You have locked door: " + d.Name);
                            break;
                        }
                        Console.WriteLine("Can't lock opened door!");
                    }
                }else if(o.Type == GameObjectType.Chest)
                {
                    Chest ch = (Chest)o;
                    if (ch.Key!= null && ch.Key.Name == key.Name)
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

        /// <summary>
        /// Handler for event of taking book from bookshelf
        /// </summary>
        /// <param name="b">book</param>
        public void OnBookTake(Book b)
        {
            if (b.ShowsSomething)
            {
                GameObjectBase gameObject = HiddenObjects.Find(x => x.Name == b.Object.Name);
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
                }
            }
            
        }

        /// <summary>
        /// Handler for event of using torch holder
        /// </summary>
        /// <param name="holder"></param>
        public void OnTorchHolderUse(TorchHolder holder)
        {
            if (holder.ShowsSomething)
            {
                GameObjectBase gameObject = HiddenObjects.Find(x => x.Name == holder.Object.Name);
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
                }

            }else
            {
                Console.WriteLine("Using torch holder had no effect.");
            }
        }


    }
}
