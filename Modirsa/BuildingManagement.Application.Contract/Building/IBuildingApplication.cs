using _0_Framework.Application;

namespace BuildingManagement.Application.Contract.Building
{
    public interface IBuildingApplication
    {
        Task<OperationResult> Create(CreateBuilding command);
        Task<OperationResult> Edit(EditBuilding command);
        Task<EditBuilding> GetBuildingBy(Guid Id);
        Task<List<BuildingViewModel>> GetAll();
        Task<List<BuildingViewModel>> Search(BuildingSearchModel searchModel);
    }
}
