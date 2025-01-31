using BuildingManagement.Application.Contract.Building;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingApplication _buildingApplication;

        public BuildingController(IBuildingApplication buildingApplication)
        {
            _buildingApplication = buildingApplication;
        }

        [HttpGet]
        [Route("GetAllBuilding")]
        public async Task<IEnumerable<BuildingViewModel>> GetAllBuildingAsync()
        {
            return await _buildingApplication.GetAll();
        }
    }
}
