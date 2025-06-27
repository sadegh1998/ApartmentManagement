using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Unit.SearchUnit
{
    public class SearchUnitHandler : IRequestHandler<SearchUnitQuery, List<UnitSearchViewModel>>
    {
        private readonly IUnitRepository _unitRepository;

        public SearchUnitHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<List<UnitSearchViewModel>> Handle(SearchUnitQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitRepository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                result = result.Where(x => x.Name.Contains(request.Name)).ToList();
            }
            return result.Select(x => new UnitSearchViewModel
            {
                Name = x.Name,
                UnitNumber = x.UnitNumber,
                NumberOfFamilyMembers = x.NumberOfFamilyMembers,
                OwnerTenanStatus = x.OwnerTenanStatus,
                BuildingName = x.Building.Name
            }).ToList();
        }
    }
}
