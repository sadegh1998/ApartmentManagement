using MediatR;

namespace Application.Feature.Query.Unit.SearchUnit
{
    public class SearchUnitQuery : IRequest<List<UnitSearchViewModel>>
    {
        public string Name { get; set; }
    }
}
