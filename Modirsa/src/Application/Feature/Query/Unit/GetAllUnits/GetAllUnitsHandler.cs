using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Unit.GetAllUnits
{
    public class GetAllUnitsHandler : IRequestHandler<GetAllUnitsQuery, List<UnitViewModel>>
    {
        private readonly IUnitRepository _unitRepository;

        public GetAllUnitsHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<List<UnitViewModel>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
        {
            return await _unitRepository.GetAllUnitsWithBuildingAsync();
        }
    }
}
