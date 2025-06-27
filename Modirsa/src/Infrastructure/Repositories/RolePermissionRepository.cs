using Application.Persistance.Contracts;
using Domain.RoleAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class RolePermissionRepository:RepositoryBase<RolePermission> , IRolePermissionRepository
    {
        private readonly ModisaDbContext _context;

        public RolePermissionRepository(ModisaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
