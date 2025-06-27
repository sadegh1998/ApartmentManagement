using Application.Persistance.Contracts;
using Domain.RoleAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole> , IUserRoleRepository
    {
        private readonly ModisaDbContext _context;

        public UserRoleRepository(ModisaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
