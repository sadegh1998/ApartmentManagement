using Domain.AccountAgg;

namespace Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Title { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public Role(string title)
        {
            Title = title;
            UserRoles = new List<UserRole>();
            RolePermissions = new List<RolePermission>();
        }
       
    }
}
