using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Role.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleViewModel>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Title = r.Title,
                UsersCount = r.UserRoles?.Count ?? 0,
                PermissionsCount = r.RolePermissions?.Count ?? 0
            });
        }
    }
}
