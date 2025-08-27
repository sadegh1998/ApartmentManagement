using Application.Persistance.Contracts;
using Domain.RoleAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ModisaDbContext context) : base(context)
        {
        }
    }
}

