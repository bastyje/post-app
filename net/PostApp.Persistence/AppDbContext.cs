using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PostApp.Domain.Entities;

#pragma warning restore format

namespace PostApp.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Package> Packages { get; set; }
    public DbSet<PostMachine> PostMachines { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Addressee> Addressees { get; set; }
    
    public IConfiguration Configuration { get; }

    public AppDbContext(IConfiguration configuration, DbContextOptions<AppDbContext> options) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration["Data:AppConnection:ConnectionString"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}