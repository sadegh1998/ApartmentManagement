using _0_Framework.Domain;

namespace BuildingManagement.Domain.BuildingAgg
{
    public class Building : EntityBase
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Floors { get; private set; }
        public int BuildingUnitsNo { get; private set; }
        public decimal FundBalance { get; private set; }
        public string Image { get; private set; }

        public Building(string name, string address, int floors, int buildingUnitsNo, decimal fundBalance, string image)
        {
            Name = name;
            Address = address;
            Floors = floors;
            BuildingUnitsNo = buildingUnitsNo;
            FundBalance = fundBalance;
            Image = image;
        }
        public void Edit(string name, string address, int floors, int buildingUnitsNo, decimal fundBalance, string image)
        {
            Name = name;
            Address = address;
            Floors = floors;
            BuildingUnitsNo = buildingUnitsNo;
            FundBalance = fundBalance;
            Image = image;
        }
    }
}
