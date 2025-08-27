using MediatR;

namespace Application.Feature.Command.Permission.CreatePermission
{
    public class CreatePermissionCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
