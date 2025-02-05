using BuildingManagement.Application.Contract.Building;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
