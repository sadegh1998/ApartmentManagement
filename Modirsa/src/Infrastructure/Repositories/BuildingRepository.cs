using Application.Persistance.Contracts;
using Domain.BuildingAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class BuildingRepository : RepositoryBase<Building>,IBuildingRepository
    {
        private readonly ModisaDbContext _context;

        public BuildingRepository(ModisaDbContext context) : base(context) 
        {
            _context = context;
        }

    }
}
