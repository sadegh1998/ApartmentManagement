using Application.Commons;
using MediatR;

namespace Application.Feature.Command.Building.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<OperationResult>
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required int Floors { get; set; }
        public required int BuildingUnitsNo { get; set; }
        public required decimal FundBalance { get; set; }
        public string? Image { get; set; }
    }
}
