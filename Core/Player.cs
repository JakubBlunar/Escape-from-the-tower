using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core
{

    /// <summary>
    /// Class that represents player.
    /// Has his name, executes command from commandline.
    /// </summary>
    [XmlRoot("Player")]
    public class Player
    {
        [XmlIgnore]
        public Room ActualRoom { get; set; }
        public string NameOfActualRoom { get; set; }

        public int MoneyCollected { get; set; }

        public List<GameItemBase> Inventory { get; set; }

        public string Name { get; set; }

        public Player() { }

        public Player(string name)
        {
            Inventory = new List<GameItemBase>();
            Name = name;
        }

        /// <summary>
        /// Method for command go, where player change actual room
        /// </summary>
        /// <param name="where">Name of the new room.</param>
        /// <returns>If player is in new room.</returns>
        public bool Go(string where)
        {
            if (where == ActualRoom.Name) {
                Console.WriteLine("You are already here.");
                return false;
            }

            foreach (var o in ActualRoom.VisibleObjects)
            {
                if (o.Type == GameObjectType.Door)
                {
                    Doors d = (Doors)o;
                    string nextRoom = null;
                    if (d.Room1 == where) nextRoom = d.Room1;
                    if (d.Room2 == where) nextRoom = d.Room2;
                    if (nextRoom != null)
                    {
                        if (!d.AreClosed)
                        {
                            NameOfActualRoom = nextRoom;
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

            Console.WriteLine("Room with name " + where + " dont exists");
            return false;
        }

        /// <summary>
        /// Method that puts game item into player inventory
        /// </summary>
        /// <param name="nameOfItem">name of the item</param>
        public void TakeItem(string nameOfItem)
        {
            GameObjectBase item = ActualRoom.VisibleObjects.Find(x => x.Name == nameOfItem);
            if (item != null)
            {
                if (item is GameItemBase)
                {
                    if (item.Type == GameObjectType.Gold)
                    {
                        Gold g = (Gold)item;
                        MoneyCollected += g.Ammount;
                        g.Take();
                    }
                    else
                    {
                        Inventory.Add((GameItemBase)item);
                        Console.WriteLine("You put " + item.Name + " to your inventory.");
                    }
                    ActualRoom.VisibleObjects.Remove(item);
                }
                else Console.WriteLine("You cant take " + nameOfItem + "! It's too heavy.");
            } else Console.WriteLine("Item " + nameOfItem + " dont exists.");
        }

        /// <summary>
        /// Method for putting Items into gameObject
        /// </summary>
        /// <param name="name">name of item from inventory</param>
        /// <param name="gameObject">object where to put item</param>
        public void PutToObject(string name, IGameObject gameObject)
        {
            GameItemBase item = Inventory.Find(x => x.Name == name);
            if (item != null)
            {
                if (gameObject.Type == GameObjectType.Bookshelf)
                {
                    Bookshelf bs = (Bookshelf)gameObject;
                    var book = item as Book;
                    if (book != null)
                    {
                        bs.Books.Add(book);
                        Inventory.Remove(book);
                        Console.WriteLine("You put " + book.Name + " to bookshelf " + gameObject.Name);
                    }
                    else Console.WriteLine("You can add only books into bookshelf.");

                }
                else if (gameObject.Type == GameObjectType.Chest)
                {
                    Chest ch = (Chest)gameObject;
                    ch.Items.Add(item);
                    Inventory.Remove(item);
                    Console.WriteLine("You put " + item.Name + " to chest " + gameObject.Name);
                }
            } else Console.WriteLine("Item with name" + name + " don't exists in your inventory.");
        }

        /// <summary>
        /// Method for taking game item from some object.
        /// </summary>
        /// <param name="name">name of item</param>
        /// <param name="paObject">object from which take game item</param>
        public void TakeFromObject(string name, IGameObject paObject)
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

            } else if (paObject.Type == GameObjectType.Chest)//chest
            {
                Chest c = (Chest)paObject;
                GameItemBase item = c.Items.Find(x => x.Name == name);
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

        /// <summary>
        /// Method for use specified game item
        /// </summary>
        /// <param name="nameOfItem">name of item that player want to use</param>
        public void UseItem(String nameOfItem)
        {
            IGameObject item = ActualRoom.VisibleObjects.Find(x => x.Name == nameOfItem);
            if (item != null)
            {
                if (item is GameItemBase)
                {
                    Console.WriteLine("You have to take it into your inventory to use it.");
                } else
                {
                    if (item.Type == GameObjectType.TorchHolder)
                    {
                        TorchHolder h = (TorchHolder)item;
                        h.ObjectUse += ActualRoom.OnTorchHolderUse;
                        h.Use(this);
                        h.ObjectUse -= ActualRoom.OnTorchHolderUse;
                    }
                    else item.Use(this);
                }
            }
            else // inventory
            {
                item = Inventory.Find(x => x.Name == nameOfItem);
                if (item != null)
                {
                    switch (item.Type)
                    {
                        case GameObjectType.Key:
                            Key k = (Key)item;
                            k.ItemUse += ActualRoom.OnKeyUse;
                            k.Use(this);
                            k.ItemUse -= ActualRoom.OnKeyUse;
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

        /// <summary>
        /// Drop Item from player inventory into room.
        /// </summary>
        /// <param name="nameOfItem">Name of item to be dropped.</param>
        public void DropItem(string nameOfItem)
        {
            GameObjectBase item = Inventory.Find(x => x.Name == nameOfItem);
            if (item == null)
            {
                Console.WriteLine("You dont have item with name '" + nameOfItem + "' in your inventory");
                return;
            }

            ActualRoom.VisibleObjects.Add(item);
            Inventory.Remove((GameItemBase)item);
            Console.WriteLine("You dropped item with name '" + nameOfItem + "' from your inventory");
        }

        /// <summary>
        /// Look at specified object
        /// </summary>
        /// <param name="at">Name of object</param>
        /// <returns>The object on which the player is looking or null if dont exists</returns>
        public IGameObject Look(string at)
        {
            if (at != null)
            {
                IGameObject o = ActualRoom.VisibleObjects.Find(x => x.Name == at);
                if (o != null)
                {
                    if (o.Type == GameObjectType.Chest)// check if player can look into chest
                    {
                        Chest chest = (Chest)o;
                        if (chest.IsUnlocked)
                        {
                            if (!chest.IsClosed)
                            {
                                return o;
                            }
                            Console.WriteLine("Chest " + chest.Name + " is closed!"); return null;
                          
                        }
                        Console.WriteLine("Chest " + chest.Name + " is locked!"); return null;
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

        /// <summary>
        /// Writes info about player on console
        /// Name
        /// Inventory items
        /// Collected gold
        /// </summary>
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


        public void SetActualRoom(Room room)
        {
            ActualRoom = room;
            NameOfActualRoom = room.Name;
        }

    }

   

}
