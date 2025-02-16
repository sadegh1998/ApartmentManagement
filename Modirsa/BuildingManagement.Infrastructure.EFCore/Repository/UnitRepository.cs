using _0_Framework.Infrastructure;
using BuildingManagement.Application.Contract.Unit;
using BuildingManagement.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Infrastructure.EFCore.Repository
{
    public class UnitRepository : RepositoryBase<Guid, Unit>, IUnitRepository
    {
        private readonly BuildingContext _context;

        public UnitRepository(BuildingContext context) : base(context) 
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
