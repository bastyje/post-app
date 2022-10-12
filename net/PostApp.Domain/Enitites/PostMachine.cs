namespace PostApp.Domain.Entities;

public record PostMachine : IEntityBase<string>
{
    public string Id { get; set; }
    public string AddressId { get; set; }
}