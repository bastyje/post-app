namespace PostApp.Domain.Dictionaries;

public record Status : IDictionaryBase
{
    public int Id { get; set; }
    public string Name { get; set; }
}