using Application.Commons;
using MediatR;

namespace Application.Feature.Command.Building.EditBuilding
{
    public class EditBuildingCommand : IRequest<OperationResult>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required int Floors { get; set; }
        public required int BuildingUnitsNo { get; set; }
        public required decimal FundBalance { get; set; }
        public string? Image { get; set; }
    }
}
