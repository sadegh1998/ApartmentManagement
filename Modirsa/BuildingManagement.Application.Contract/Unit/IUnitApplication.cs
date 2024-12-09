using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Contract.Unit
{
    public interface IUnitApplication
    {
        Task<OperationResult> CreateAsync(CreateUnit command);
        Task<OperationResult> EditAsync(EditUnit command);
        Task<UnitViewModel> GetUnitBy(Guid id);
        Task<List<UnitViewModel>> GetAllUnit();
        Task<List<UnitViewModel>> Search(UnitSearchModel searchModel);
    }
}
