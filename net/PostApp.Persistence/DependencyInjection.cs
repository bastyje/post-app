using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostApp.Application.Common.Interfaces;
using PostApp.Persistence.Interfaces;
using PostApp.Persistence.Repositories;

namespace PostApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["Data:AppConnection:ConnectionString"]))
            .AddScoped<IPackageRepository, PackageRepository>()
            .AddScoped<IPostMachineRepository, PostMachineRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IDictionaryRepository, DictionaryRepository>()
            .AddScoped<IAppDbContext, AppDbContext>();
    }
}