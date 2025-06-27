using Domain.RoleAgg;

namespace Application.Persistance.Contracts
{
    public interface IRoleRepository :IAsyncRepository<Role>
    {
        //Task<EditRole> GetDetailsAsync(Guid id);
        //Task<List<RoleViewModel>> ListAsync();
    }
}
