
using _0_Framework.Infrstructure;

namespace AccountManagement.Application.Contract.Role
{
    public class EditRole : CreateRole {
        public Guid Id { get; set; }
        public List<PermissonDto> MappedPermissions { get; set; }
    }
}
