namespace Application.Feature.Query.Unit.GetAllUnits
{
    public class UnitViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UnitNumber { get; set; }
        public string OwnerTenanStatus { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public string BuildingName { get; set; }
    }
}
