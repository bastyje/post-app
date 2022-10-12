namespace PostApp.Domain.Entities;

public record Address : IEntityBase<string>
{
    public string Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
}