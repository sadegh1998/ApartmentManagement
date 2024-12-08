using _0_Framework.Infrastructure;
using BuildingManagement.Domain.BuildingAgg;

namespace BuildingManagement.Infrastructure.EFCore.Repository
{
    public class BuildingRepository : RepositoryBase<Guid,Building>,IBuildingRepository
    {
        private readonly BuildingContext _context;

        public BuildingRepository(BuildingContext context) : base(context) 
        {
            _context = context;
        }

    }
}
