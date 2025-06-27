using Application.Commons;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Command.Unit.CreateUnit
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, OperationResult>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public CreateUnitHandler(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var check = await _unitRepository.GetAsync(x => x.Name == request.Name && x.BuildingId == request.BuildingId);
            if (check.Any())
            {
                return operation.Failed("ApplicationMessages.Duplicate");
            }

            //var unit = new Unit(command.Name, command.UnitNumber, command.OwnerTenanStatus, command.NumberOfFamilyMembers, command.BuildingId);
            await _unitRepository.AddAsync(_mapper.Map<Domain.UnitAgg.Unit>(request));
            return operation.Success();
        }
    }
}
