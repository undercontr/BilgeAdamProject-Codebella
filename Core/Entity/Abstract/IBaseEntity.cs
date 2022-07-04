namespace Core.Entity.Abstract;

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
}