using Application.Persistance.Contracts;
using Domain.RoleAgg;
using MediatR;

namespace Application.Feature.Command.Permission.CreatePermission
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Guid>
    {
        private readonly IPermissionRepository _permissionRepository;

        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Domain.RoleAgg.Permission(request.Name, request.Code);
            await _permissionRepository.AddAsync(permission);
            return permission.Id;
        }
    }
}
