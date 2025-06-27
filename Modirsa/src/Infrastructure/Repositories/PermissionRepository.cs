using Application.Persistance.Contracts;
using Domain.RoleAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission> , IPermissionRepository
    {
        private readonly ModisaDbContext _context;

        public PermissionRepository(ModisaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
