namespace Application.Feature.Query.Unit.GetUnitById
{
    public class SingeleUnitViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UnitNumber { get; set; }
        public string OwnerTenanStatus { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public Guid BuildingId { get; set; }
    }
}
