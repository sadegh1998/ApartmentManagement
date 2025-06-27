using Domain.RoleAgg;

namespace Application.Persistance.Contracts
{
    public interface IRolePermissionRepository : IAsyncRepository<RolePermission>
    {
    }
}
