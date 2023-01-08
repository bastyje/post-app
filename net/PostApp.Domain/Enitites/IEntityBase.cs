namespace PostApp.Domain.Entities;

public interface IEntityBase<TKey>
{
    public TKey Id { get; set; }
}