using _0_Framework.Domain;
using BuildingManagement.Domain.BuildingAgg;

namespace BuildingManagement.Domain.UnitAgg
{
    public class Unit : EntityBase
    {
        public string Name { get;private set; }
        public int UnitNumber { get; private set; }
        public string OwnerTenanStatus { get; private set; }
        public int NumberOfFamilyMembers { get; private set; }
        public Guid BuildingId { get; private set; }
        public Building Building { get; private set; }

        public Unit(string name, int unitNumber, string ownerTenanStatus, int numberOfFamilyMembers,Guid buildingId)
        {
            Name = name;
            UnitNumber = unitNumber;
            OwnerTenanStatus = ownerTenanStatus;
            NumberOfFamilyMembers = numberOfFamilyMembers;  
            BuildingId = buildingId;
        }
        public void Edit(string name, int unitNumber, string ownerTenanStatus, int numberOfFamilyMembers, Guid buildingId)
        {
            Name = name;
            UnitNumber = unitNumber;
            OwnerTenanStatus = ownerTenanStatus;
            NumberOfFamilyMembers = numberOfFamilyMembers;
            BuildingId = buildingId;
        }
    }
}
