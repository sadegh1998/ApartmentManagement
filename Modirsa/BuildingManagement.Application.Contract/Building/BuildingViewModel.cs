namespace BuildingManagement.Application.Contract.Building
{
    public class BuildingViewModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Floors { get; set; }
        public required int BuildingUnitsNo { get; set; }
        public required decimal FundBalance { get; set; }
    }
}
