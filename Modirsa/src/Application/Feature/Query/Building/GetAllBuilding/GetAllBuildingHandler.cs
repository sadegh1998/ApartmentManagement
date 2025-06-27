using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Building.GetAllBuilding
{
    public class GetAllBuildingHandler : IRequestHandler<GetAllBuildingQuery, List<BuildingViewModel>>
    {
        private readonly IBuildingRepository _buildingRepositpry;

        public GetAllBuildingHandler(IBuildingRepository buildingRepositpry)
        {
            _buildingRepositpry = buildingRepositpry;
        }

        public async Task<List<BuildingViewModel>> Handle(GetAllBuildingQuery request, CancellationToken cancellationToken)
        {
            var buildings = await _buildingRepositpry.GetAllAsync();
            return buildings.Select(x => new BuildingViewModel
            {
                Id = x.Id,
                Name = x.Name,
                BuildingUnitsNo = x.BuildingUnitsNo,
                Floors = x.Floors,
                FundBalance = x.FundBalance
            }).ToList();
        }
    }
}
