using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Player
    {
        public Room ActualRoom { get; set; }

        public int MoneyCollected { get; set; }

        public List<IGameItem> Inventory { get; private set; }

        public string Name { get; private set; }

        public Player(string name)
        {
            Inventory = new List<IGameItem>();
            Name = name;
        }

        public bool go(string where)
        {
            if (where == ActualRoom.Name) {
                Console.WriteLine("You are already here.");
                return false;
            }

            bool found = true;
            foreach(var o in ActualRoom.VisibleObjects)
            {
               
                    if(o.Type == GameObjectType.Door)
                    {
                        Door d = (Door)o;
                        Room nextRoom = null;
                        if (d.Room1.Name == where) nextRoom = d.Room1;
                        if (d.Room2.Name == where) nextRoom = d.Room2;
                        if (nextRoom != null)
                        {
                            found = true;
                            if (!d.AreClosed)
                            {
                                ActualRoom = nextRoom;
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Door " + d.Name + " are closed.");
                                return false;
                            }
                        }
                    }
            }

           if (!found) Console.WriteLine("Room with name" + where + " dont exists");
           return false;
        }

        public void TakeItem(string nameOfItem)
        {
            IGameObject item = ActualRoom.VisibleObjects.Find(x => x.Name == nameOfItem);
            if (item != null)
            {
                if (item is IGameItem)
                {
                    if (item.Type == GameObjectType.Gold)
                    {
                        Gold g = (Gold)item;
                        MoneyCollected += g.Ammount;
                        g.Take();
                    }
                    else
                    {
                        Inventory.Add((IGameItem)item);
                        Console.WriteLine("You put " + item.Name + " to your inventory.");
                    }
                    ActualRoom.VisibleObjects.Remove(item);
                }
                else Console.WriteLine("You cant take " + nameOfItem + "! It's too heavy.");
            }else Console.WriteLine("Item " + nameOfItem + " dont exists.");
        }

        public void PutToObject(string name, IGameObject gameObject)
        {
            IGameItem item = Inventory.Find(x => x.Name == name);
            if(item != null)
            {
                if(gameObject.Type == GameObjectType.Bookshelf)
                {
                    Bookshelf bs = (Bookshelf)gameObject;
                    if (item is Book)
                    {
                        bs.Books.Add((Book)item);
                        Inventory.Remove(item);
                        Console.WriteLine("You put " + item.Name + " to bookshelf " + gameObject.Name);
                    }
                    else Console.WriteLine("You can add only books into bookshelf.");       
                    
                }
                else if(gameObject.Type == GameObjectType.Chest)
                {
                    Chest ch = (Chest)gameObject;
                    ch.Items.Add(item);
                    Inventory.Remove(item);
                    Console.WriteLine("You put " + item.Name + " to chest " + gameObject.Name);
                }
            }else Console.WriteLine("Item with name" + name + " don't exists in your inventory.");
        }

        public void TakeFromObject(string name, IGameObject paObject )
        {
            if (paObject.Type == GameObjectType.Bookshelf)
            {
                Bookshelf b = (Bookshelf)paObject;
                Book book = b.Books.Find(x => x.Name == name);
                if (book != null)
                {
                    if (book.ShowsSomething)
                    {
                        book.BookTake += ActualRoom.OnBookTake;
                        book.Take();
                        book.BookTake -= ActualRoom.OnBookTake;
                    }
                    else
                    {
                        Inventory.Add(book);
                        b.Books.Remove(book);
                        Console.WriteLine("You put " + book.Name + " to your inventory.");
                    }
                }
                else Console.WriteLine("Book with name" + name + " don't exists.");

            }else if (paObject.Type == GameObjectType.Chest)//chest
            {
                Chest c = (Chest)paObject;
                IGameItem item = c.Items.Find(x => x.Name == name);
                if (item != null)
                {
                    if (item.Type == GameObjectType.Gold)
                    {
                        Gold g = (Gold)item;
                        MoneyCollected += g.Ammount;
                        g.Take();
                        c.Items.Remove(g);
                    }
                    else
                    {
                        Inventory.Add(item);
                        c.Items.Remove(item);
                        Console.WriteLine("You put " + item.Name + " to your inventory.");
                    }
                    
                }
                else Console.WriteLine("Game Item with name" + name + " don't exists.");

            }
        }


        public void UseItem(String nameOfItem)
        {
            IGameObject item = ActualRoom.VisibleObjects.Find(x => x.Name == nameOfItem);
            if (item != null)
            {
                if (item is IGameItem)
                {
                    Console.WriteLine("You have to take it into your inventory to use it.");
                } else
                {
                    item.Use(this);
                }
            } else // inventory
            {
                item = Inventory.Find(x => x.Name == nameOfItem);
                if (item != null)
                {
                    switch (item.Type)
                    {
                        case GameObjectType.Key:
                            Key k = (Key)item;
                            k.itemUse += ActualRoom.onKeyUse;
                            k.Use(this);
                            k.itemUse -= ActualRoom.onKeyUse;
                            break;
                        default:
                            item.Use(this);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Object with name " + nameOfItem + " don't exists.");
                }
            }

           
           
        }

        public void DropItem(string nameOfItem)
        {
            IGameObject item = Inventory.Find(x => x.Name == nameOfItem);
            if(item == null)
            {
                Console.WriteLine("You dont have item with name '" + nameOfItem + "' in your inventory");
                return;
            }

            ActualRoom.VisibleObjects.Add(item);
            Inventory.Remove((IGameItem)item);
            Console.WriteLine("You dropped item with name '" + nameOfItem + "' from your inventory");
        }


        public IGameObject Look(string at = null)
        {
            if (at != null)
            {
                IGameObject o = ActualRoom.VisibleObjects.Find(x => x.Name == at);
                if(o != null)
                {
                    if(o.Type == GameObjectType.Chest)// check if player can look into chest
                    {
                        Chest chest = (Chest)o;
                        if (chest.IsUnlocked)
                        {
                            if (!chest.IsClosed)
                            {
                                return o;
                            }
                            else { Console.WriteLine("Chest " + chest.Name + " is closed!"); return null; };
                        }
                        else { Console.WriteLine("Chest " + chest.Name + " is locked!"); return null; };
                    }
                    // look at another object that is not chest
                    o.Look(this);
                    return o;
                }

                o = Inventory.Find(x => x.Name == at);
                if (o != null)
                {
                    o.Look(this);
                    return o;
                }
                Console.WriteLine("Object with name " + at + " don't exists.");
                return null;
            }
            return null;
        }

        public void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Inventory:");
            if (Inventory.Count > 0)
            {
                foreach (var i in Inventory)
                {
                    Console.Write(i.Name + ", ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("Player inventory is empty.");

            Console.WriteLine("Curently have " + MoneyCollected + " gold.");
        }

    }
}
