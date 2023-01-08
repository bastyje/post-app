using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostApp.Domain.Entities;

namespace PostApp.Persistence.Configurations;

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.ToTable(nameof(Package));
        builder.HasOne(p => p.Addressee).WithMany().HasForeignKey(p => p.AddresseeId);
        builder.HasOne(p => p.Sender).WithMany().HasForeignKey(p => p.SenderId);
        builder.HasOne(p => p.PostMachine).WithMany().HasForeignKey(p => p.PostMachineId);
    }
}