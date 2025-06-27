using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Query.Unit.GetUnitById
{
    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, SingeleUnitViewModel>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitByIdHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<SingeleUnitViewModel> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {

            var unit = await _unitRepository.GetByIdAsync(request.Id);
            return new SingeleUnitViewModel
            {
                Name = unit.Name,
                NumberOfFamilyMembers = unit.NumberOfFamilyMembers,
                OwnerTenanStatus = unit.OwnerTenanStatus,
                UnitNumber = unit.UnitNumber,
                BuildingId = unit.BuildingId,
                Id = unit.Id
            };
        }
    }
}
