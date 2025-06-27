using Application.Feature.Query.Unit.GetAllUnits;
using MediatR;

namespace Application.Feature.Query.Unit.GetUnitById
{
    public class GetUnitByIdQuery : IRequest<SingeleUnitViewModel>
    {
        public Guid Id { get; set; }

        public GetUnitByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
