using MediatR;

namespace Application.Feature.Command.Role.DeleteRole
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
