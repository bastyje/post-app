using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PostApp.Domain.Entities;
using PostApp.Persistence.Interfaces;

#pragma warning restore format

namespace PostApp.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Package> Package { get; set; }
    public DbSet<PostMachine> PostMachine { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    
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
        return Task.FromResult(base.SaveChanges());
    }

    public DbSet<TEntity> Set<TEntity, TKey>() where TEntity : class, IEntityBase<TKey>
    {
        return base.Set<TEntity>();
    }
}