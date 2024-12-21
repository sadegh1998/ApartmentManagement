using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        Task<OperationResult> CreateAsync(CreateRole command);
        Task<OperationResult> EditAsync(EditRole command);
        Task<EditRole> GetDetailsAsync(Guid id);
        Task<List<RoleViewModel>> ListAsync();
    }
}
