using MediatR;

namespace Application.Feature.Command.Role.EditRole
{
    public class EditRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}


