using Application.Feature.Query.Building.GetAllBuilding;
using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Building.GetBuildingById
{
    public class GetBuildingByIdHandler : IRequestHandler<GetBuildingByIdQuery, BuildingViewModel>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetBuildingByIdHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<BuildingViewModel> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _buildingRepository.GetByIdAsync(request.Id);
            return new BuildingViewModel
            {
                BuildingUnitsNo = result.BuildingUnitsNo,
                Floors = result.Floors,
                FundBalance = result.FundBalance,
                Id = result.Id,
                Name = result.Name
            }
            ;
        }
    }
}
