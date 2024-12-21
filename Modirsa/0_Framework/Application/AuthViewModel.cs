namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<int> Permissions { get; set; }
        public AuthViewModel()
        {
            
        }

        public AuthViewModel(Guid id, Guid roleId, string userName, string fullName, List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            UserName = userName;
            FullName = fullName;
            Permissions = permissions;
        }
    }
}
