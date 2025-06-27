using Application.Commons;
using MediatR;

namespace Application.Feature.Command.Unit.CreateUnit
{
    public class CreateUnitCommand : IRequest<OperationResult>
    {
        public string Name { get; set; }
        public int UnitNumber { get; set; }
        public string OwnerTenanStatus { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public Guid BuildingId { get; set; }
    }
}
