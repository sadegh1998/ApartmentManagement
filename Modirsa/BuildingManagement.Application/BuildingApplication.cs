using _0_Framework.Application;
using BuildingManagement.Application.Contract.Building;
using BuildingManagement.Domain.BuildingAgg;

namespace BuildingManagement.Application
{
    public class BuildingApplication : IBuildingApplication
    {
        private readonly IBuildingRepository _repository;

        public BuildingApplication(IBuildingRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Create(CreateBuilding command)
        {
            var operation = new OperationResult();
            if (await _repository.ExsitsAsync(x => x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.Duplicate);
                return operation;
            }
            var building = new Building(command.Name, command.Address, command.Floors, command.BuildingUnitsNo, command.FundBalance, command.Image);
            await _repository.CreateAsync(building);
            await _repository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> Edit(EditBuilding command)
        {
            var operation = new OperationResult();
            if (await _repository.ExsitsAsync(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }
            var building = _repository.GetAsync(command.Id);
            if (building == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            building.Result.Edit(command.Name, command.Address, command.Floors, command.BuildingUnitsNo, command.FundBalance, command.Image);
            await _repository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<List<BuildingViewModel>> GetAll()
        {
            var buildings = await _repository.GetAllAsync();
            return buildings.Select(x => new BuildingViewModel
            {
                Name = x.Name,
                BuildingUnitsNo = x.BuildingUnitsNo,
                Floors = x.Floors,
                FundBalance = x.FundBalance
            }).ToList();
        }

        public async Task<BuildingViewModel> GetBuildingBy(Guid Id)
        {
            var building = await _repository.GetAsync(Id);
            return new BuildingViewModel
            {
                BuildingUnitsNo = building.BuildingUnitsNo,
                Floors = building.Floors,
                Name = building.Name,
                FundBalance = building.FundBalance
            };
        }

        public async Task<List<BuildingViewModel>> Search(BuildingSearchModel searchModel)
        {
            var buildings = await _repository.GetAllAsync();
            var result = buildings.Where(x => x.Name.Contains(searchModel.Name));
            return result.Select(x => new BuildingViewModel
            {
                BuildingUnitsNo = x.BuildingUnitsNo,
                Name = x.Name,
                Floors = x.Floors,
                FundBalance = x.FundBalance
            }).ToList();
        }
    }
}
