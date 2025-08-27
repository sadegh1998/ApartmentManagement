using Domain.RoleAgg;

namespace Application.Persistance.Contracts
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        // Additional role-specific methods can be added here
    }
}
