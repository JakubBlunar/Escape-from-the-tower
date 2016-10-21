using System.Xml.Serialization;

namespace Core
{
    [XmlRoot("GameObjectBase")]
    [XmlInclude(typeof(Window))]
    [XmlInclude(typeof(Chest))]
    [XmlInclude(typeof(CommonObject))]
    [XmlInclude(typeof(Bookshelf))]
    [XmlInclude(typeof(TorchHolder))]
    [XmlInclude(typeof(Doors))]
    [XmlInclude(typeof(GameItemBase))]
    public abstract class GameObjectBase : IGameObject
    {
        public string Name { get; set; }
        public abstract GameObjectType Type { get; }

        public abstract void Look(Player p);
        public abstract void Use(Player p);
    }
}
