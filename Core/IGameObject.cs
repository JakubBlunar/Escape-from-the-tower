namespace Core
{
    public interface IGameObject
    {
        GameObjectType Type { get; }
        string Name { get; set; }

        void Use(Player p);
        void Look(Player p);
      
    }
}
