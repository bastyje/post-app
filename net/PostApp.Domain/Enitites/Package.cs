using PostApp.Domain.Enums;

namespace PostApp.Domain.Entities;

public record Package : IEntityBase<int>
{
    public int Id { get; set; }
    public string AddresseeId { get; set; }
    public ApplicationUser Addressee { get; private set; }
    public string SenderId { get; set; }
    public ApplicationUser Sender { get; private set; }
    public int PostMachineId { get; set; }
    public PostMachine PostMachine { get; private set; }
    public StatusEnum StatusId { get; set; }
}