using Application.Persistance.Contracts;
using Domain.RoleAgg;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly ModisaDbContext _accountContext;

        public RoleRepository(ModisaDbContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        //public async Task<EditRole> GetDetailsAsync(Guid id)
        //{
        //    var role = await _accountContext.Roles
        //       .Select(x => new EditRole
        //       {
        //           Id = x.Id,
        //           Name = x.Name,
        //           MappedPermissions = MapPermission(x.Permissions)
        //       }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        //    role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
        //    return role;
        //}


        //public async Task<List<RoleViewModel>> ListAsync()
        //{
        //    return await _accountContext.Roles.Select(x => new RoleViewModel { Id = x.Id, Name = x.Name }).ToListAsync();
        //}
        //private static List<PermissonDto> MapPermission(List<Permission> permissions)
        //{
        //    return permissions.Select(x => new PermissonDto(x.Code, x.Name)).ToList();
        //}
    }

}

