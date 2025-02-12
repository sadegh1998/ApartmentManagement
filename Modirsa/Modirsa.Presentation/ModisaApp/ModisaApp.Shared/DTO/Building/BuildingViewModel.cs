using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModisaApp.Shared.DTO.Building
{
    public class BuildingViewModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
            public required int Floors { get; set; }
            public required int BuildingUnitsNo { get; set; }
            public required decimal FundBalance { get; set; }
        
    }
}
