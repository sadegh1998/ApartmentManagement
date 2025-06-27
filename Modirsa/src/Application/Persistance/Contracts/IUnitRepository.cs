using Application.Feature.Query.Unit.GetAllUnits;
using Domain.UnitAgg;

namespace Application.Persistance.Contracts
{
    public interface IUnitRepository : IAsyncRepository<Unit>
    {
        Task<List<UnitViewModel>> GetAllUnitsWithBuildingAsync();
    }
}
