using System.Xml.Serialization;

namespace Core
{
    [XmlType("GameItemBase")]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Key))]
    [XmlInclude(typeof(GameItem))]
    [XmlInclude(typeof(Gold))]
    public abstract class GameItemBase : GameObjectBase
    {
       
        public abstract void Take();
        
    }
}
