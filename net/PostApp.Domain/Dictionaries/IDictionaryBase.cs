using PostApp.Domain.Entities;

namespace PostApp.Domain.Dictionaries;

public interface IDictionaryBase
{
    public int Id { get; set; }
    public string Name { get; set; }
}