using _0_Framework.Infrastructure;
using BuildingManagement.Domain.UnitAgg;
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
    }
}
