using BuildingManagement.Domain.BuildingAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Infrastructure.EFCore.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        public void Create(Building entity)
        {
            throw new NotImplementedException();
        }

        public bool Exsits(Expression<Func<Building, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Building Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public List<Building> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
