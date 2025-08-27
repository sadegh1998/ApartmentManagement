namespace ModisaApp.Shared.DTO.Permission
{
    public class PermissionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int RolesCount { get; set; }
    }
}
