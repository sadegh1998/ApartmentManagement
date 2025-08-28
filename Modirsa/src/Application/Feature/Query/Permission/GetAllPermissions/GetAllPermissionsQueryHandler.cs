using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Permission.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<PermissionViewModel>>
    {
        private readonly IPermissionRepository _permissionRepository;

        public GetAllPermissionsQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionViewModel>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _permissionRepository.GetAllAsync();
            return permissions.Select(p => new PermissionViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                RolesCount = p.RolePermissions?.Count ?? 0
            });
        }
    }
}


