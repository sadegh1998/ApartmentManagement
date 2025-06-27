using MediatR;

namespace Application.Feature.Query.Unit.GetAllUnits
{
    public class GetAllUnitsQuery : IRequest<List<UnitViewModel>>
    {
    }
}
