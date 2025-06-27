using Application.Commons;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Command.Building.EditBuilding
{
    public class EditBuildingHandler : IRequestHandler<EditBuildingCommand, OperationResult>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public EditBuildingHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(EditBuildingCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var check = await _buildingRepository.GetAsync(x => x.Name == request.Name && x.Id != request.Id);
            if (check.Any())
            {
                return operation.Failed("ApplicationMessages.Duplicate");
            }
            var building = _buildingRepository.GetByIdAsync(request.Id);
            if (building == null)
            {
                return operation.Failed("ApplicationMessages.NotFound");
            }
            //building.Result.Edit(request.Name, request.Address, request.Floors, request.BuildingUnitsNo, request.FundBalance, request.Image);
            await _buildingRepository.UpdateAsync(_mapper.Map<Domain.BuildingAgg.Building>(request));
            //await _buildingRepository.SaveChangesAsync();
            return operation.Success();

        }
    }
}
