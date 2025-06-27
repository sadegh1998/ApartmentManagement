using Application.Commons;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Command.Unit.EditUnit
{
    public class EditUnitHandler : IRequestHandler<EditUnitCommand, OperationResult>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public EditUnitHandler(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(EditUnitCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var unit = await _unitRepository.GetByIdAsync(request.Id);
            if (unit == null)
            {
                return operation.Failed("ApplicationMessages.NotFound");
            }
            var check = await _unitRepository.GetAsync(x => x.Name == request.Name && x.BuildingId == request.BuildingId && x.Id != unit.Id);
            if (check.Any())
            {
                return operation.Failed("ApplicationMessages.Duplicate");
            }

            unit.Edit(request.Name, request.UnitNumber, request.OwnerTenanStatus, request.NumberOfFamilyMembers, request.BuildingId);
            //await _unitRepository.UpdateAsync(_mapper.Map<Domain.UnitAgg.Unit>(request));
            await _unitRepository.SaveChangesAsync();
            return operation.Success();
        }
    }
}
