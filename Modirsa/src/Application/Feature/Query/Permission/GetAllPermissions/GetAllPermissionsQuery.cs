using MediatR;

namespace Application.Feature.Query.Permission.GetAllPermissions
{
    public class GetAllPermissionsQuery : IRequest<IEnumerable<PermissionViewModel>>
    {
    }
}
