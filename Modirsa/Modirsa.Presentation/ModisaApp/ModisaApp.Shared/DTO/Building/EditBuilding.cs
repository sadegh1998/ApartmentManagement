using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModisaApp.Shared.DTO.Building
{
    public class EditBuilding : CreateBuilding
    {
        public Guid Id { get; set; }
    }
}
