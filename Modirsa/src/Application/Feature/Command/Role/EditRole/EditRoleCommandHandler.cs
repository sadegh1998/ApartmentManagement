using Application.Persistance.Contracts;
using Domain.RoleAgg;
using MediatR;

namespace Application.Feature.Command.Role.EditRole
{
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, bool>
    {
        private readonly IRoleRepository _roleRepository;

        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id);
            if (role == null)
                return false;

            role.Title = request.Title;
            await _roleRepository.UpdateAsync(role);
            return true;
        }
    }
}
