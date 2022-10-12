using PostApp.Domain.Entities;
using PostApp.Application.Common.Interfaces;

namespace PostApp.Persistence.Repositories;

public class PackageRepository : BaseRepository<Package, string>, IPackageRepository