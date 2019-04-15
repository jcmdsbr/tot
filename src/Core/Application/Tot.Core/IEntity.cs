namespace Tot.Shared
{
    public interface IEntity<out T> : IEntity where T : struct
    {
        T Id { get; }
    }

    public interface IEntity
    {
    }
}