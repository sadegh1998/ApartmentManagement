using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository :IRepository<Guid,Role>
    {
        Task<EditRole> GetDetailsAsync(Guid id);
        Task<List<RoleViewModel>> ListAsync();
    }
}
