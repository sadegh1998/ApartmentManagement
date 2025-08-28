namespace ModisaApp.Shared.DTO.Role
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UsersCount { get; set; }
        public int PermissionsCount { get; set; }
    }
}


