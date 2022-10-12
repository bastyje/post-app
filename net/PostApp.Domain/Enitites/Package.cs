using PostApp.Domain.Enums;

namespace PostApp.Domain.Entities;

public record Package : IEntityBase<string>
{
    public string Id { get; set; }
    public string AddresseeId { get; set; }
    public string PostMachineId { get; set; }
    public StatusEnum StatusId { get; set; }
}