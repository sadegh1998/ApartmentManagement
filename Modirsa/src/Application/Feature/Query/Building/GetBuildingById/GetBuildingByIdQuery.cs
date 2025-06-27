using Application.Feature.Query.Building.GetAllBuilding;
using MediatR;

namespace Application.Feature.Query.Building.GetBuildingById
{
    public class GetBuildingByIdQuery : IRequest<BuildingViewModel>
    {
        public Guid Id { get; set; }

        public GetBuildingByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
