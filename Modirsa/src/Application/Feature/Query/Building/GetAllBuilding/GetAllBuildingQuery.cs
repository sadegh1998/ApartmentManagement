using MediatR;

namespace Application.Feature.Query.Building.GetAllBuilding
{
    public class GetAllBuildingQuery : IRequest<List<BuildingViewModel>>
    {
    }
}
