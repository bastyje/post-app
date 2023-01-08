using System.Numerics;
using Microsoft.EntityFrameworkCore;
using PostApp.Domain.Entities;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Packages.Queries.GetAllPackages;
using PostApp.Persistence.Interfaces;
using PostApp.Persistence.Extensions;
using PostApp.Application.Common.Models;

namespace PostApp.Persistence.Repositories;

public class PackageRepository : BaseRepository<Package, int>, IPackageRepository
{
    public PackageRepository(IAppDbContext appDbContext) : base(appDbContext) {}

    public Task<PaginationResponse<Package>> GetPaged(PaginationRequest paginationRequest, CancellationToken cancellationToken)
    {
        return base
            .GetAll()
            .Include(p => p.Addressee)
            .Include(p => p.Sender)
            .Include(p => p.PostMachine)
            .GetPagedAsync<Package, int>(paginationRequest, cancellationToken);
    }
    
}