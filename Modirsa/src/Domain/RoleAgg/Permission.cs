namespace Domain.RoleAgg
{
    public class Permission : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; private set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        public Permission(string name, string code)
        {
            Name = name;
            Code = code;
            RolePermissions = new List<RolePermission>();
        }
    }
}
