using MediatR;

namespace Application.Feature.Query.Role.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleViewModel>>
    {
    }
}


