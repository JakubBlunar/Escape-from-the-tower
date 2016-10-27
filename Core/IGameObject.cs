namespace Core
{
    /// <summary>
    ///     Interface of game objects, contain all
    ///     method and propertes that has to be implemented.
    /// </summary>
    public interface IGameObject
    {
        GameObjectType Type { get; }
        string Name { get; set; }

        void Use(Player p);
        void Look(Player p);
    }
}