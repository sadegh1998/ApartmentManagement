using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Contract.Building
{
    public class CreateBuilding
    {
        public required string Name { get;  set; }
        public required string Address { get;  set; }
        public required int Floors { get;  set; }
        public required int BuildingUnitsNo { get;  set; }
        public required decimal FundBalance { get;  set; }
        public string? Image { get;  set; }
    }
}
