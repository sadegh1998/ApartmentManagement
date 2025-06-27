using Application.Feature.Query.Unit.GetAllUnits;
using Application.Persistance.Contracts;
using Domain.UnitAgg;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        private readonly ModisaDbContext _context;

        public UnitRepository(ModisaDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<UnitViewModel>> GetAllUnitsWithBuildingAsync()
        {
            return await _context.Units.Include(x => x.Building).Select(x => new UnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UnitNumber = x.UnitNumber,
                NumberOfFamilyMembers = x.NumberOfFamilyMembers,
                OwnerTenanStatus = x.OwnerTenanStatus,
                BuildingName = x.Building.Name

            }).ToListAsync();
        }
    }
}
