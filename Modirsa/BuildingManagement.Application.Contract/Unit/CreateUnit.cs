namespace BuildingManagement.Application.Contract.Unit
{
    public class CreateUnit
    {
        public string Name { get; set; }
        public int UnitNumber { get; set; }
        public string OwnerTenanStatus { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public Guid BuildingId { get; set; }
    }
}
