using Domain.AccountAgg;

namespace Domain.RoleAgg
{
    public class UserRole : EntityBase
    {
        public Guid UserId { get; set; }
        public Account User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
