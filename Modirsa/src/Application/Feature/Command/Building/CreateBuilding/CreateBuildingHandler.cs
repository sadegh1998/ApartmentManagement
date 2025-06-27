using Application.Commons;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain.BuildingAgg;
using MediatR;

namespace Application.Feature.Command.Building.CreateBuilding
{
    public class CreateBuildingHandler : IRequestHandler<CreateBuildingCommand, OperationResult>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public CreateBuildingHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<OperationResult> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var check = await _buildingRepository.GetAsync(x => x.Name == request.Name);
            if (check.Any())
            {
                operation.Failed("ApplicationMessages.Duplicate");
                return operation;
            }
            //var building = new Domain.BuildingAgg.Building(request.Name, request.Address, request.Floors, request.BuildingUnitsNo, request.FundBalance, request.Image);
            await _buildingRepository.AddAsync(_mapper.Map<Domain.BuildingAgg.Building>(request));

            return operation.Success();
        }
    }
}
