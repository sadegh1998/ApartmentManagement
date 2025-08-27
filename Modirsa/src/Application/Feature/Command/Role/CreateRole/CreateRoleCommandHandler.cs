using Application.Persistance.Contracts;
using Domain.RoleAgg;
using MediatR;

namespace Application.Feature.Command.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Domain.RoleAgg.Role(request.Title);
            await _roleRepository.AddAsync(role);
            return role.Id;
        }
    }
}
