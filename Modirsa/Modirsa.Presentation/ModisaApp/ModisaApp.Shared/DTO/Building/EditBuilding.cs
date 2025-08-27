using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModisaApp.Shared.DTO.Building
{
    public class EditBuilding
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Floors { get; set; }
        public int BuildingUnitsNo { get; set; }
        public decimal FundBalance { get; set; }
        public string? Image { get; set; }
    }
}
