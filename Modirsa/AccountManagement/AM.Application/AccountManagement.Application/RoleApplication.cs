using _0_Framework.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> CreateAsync(CreateRole command)
        {
            var operation = new OperationResult();
            if (await _roleRepository.ExsitsAsync(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }

            var role = new Role(command.Name, new List<Permission>());
            await _roleRepository.CreateAsync(role);
            await _roleRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> EditAsync(EditRole command)
        {
            var operation = new OperationResult();
            var role =await _roleRepository.GetAsync(command.Id);
            if (role == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }

            if (await _roleRepository.ExsitsAsync(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }

            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            role.Edit(command.Name, permissions);
            await _roleRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<EditRole> GetDetailsAsync(Guid id)
        {
            return await _roleRepository.GetDetailsAsync(id);
        }

        public async Task<List<RoleViewModel>> ListAsync()
        {
            return await _roleRepository.ListAsync();
        }
    }
}
