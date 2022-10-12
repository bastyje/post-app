namespace PostApp.Domain.Entities;

public record Addressee : IEntityBase<string>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserId { get; set; }
}