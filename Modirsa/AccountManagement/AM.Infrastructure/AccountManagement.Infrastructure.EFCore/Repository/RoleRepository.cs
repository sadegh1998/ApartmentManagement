using _0_Framework.Infrastructure;
using _0_Framework.Infrstructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<Guid, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<EditRole> GetDetailsAsync(Guid id)
        {
            var role = await _accountContext.Roles
               .Select(x => new EditRole
               {
                   Id = x.Id,
                   Name = x.Name,
                   MappedPermissions = MapPermission(x.Permissions)
               }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            return role;
        }


        public async Task<List<RoleViewModel>> ListAsync()
        {
            return await _accountContext.Roles.Select(x => new RoleViewModel { Id = x.Id, Name = x.Name }).ToListAsync();
        }
        private static List<PermissonDto> MapPermission(List<Permission> permissions)
        {
            return permissions.Select(x => new PermissonDto(x.Code, x.Name)).ToList();
        }
    }

}

