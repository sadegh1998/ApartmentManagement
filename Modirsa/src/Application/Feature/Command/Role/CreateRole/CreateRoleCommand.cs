using MediatR;

namespace Application.Feature.Command.Role.CreateRole
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
    }
}


