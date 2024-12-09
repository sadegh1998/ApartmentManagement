using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.UnitAgg
{
    public interface IUnitRepository : IRepository<Guid,Unit>
    {
    }
}
