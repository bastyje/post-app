namespace PostApp.Domain.Entities;

public interface IEntityBase<TKey> where TKey : class
{
    public TKey Id { get; set; }
}