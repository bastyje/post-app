using PostApp.Domain.Entities;

namespace PostApp.Domain.Dictionaries;

public interface IDictionaryBase : IEntityBase<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}