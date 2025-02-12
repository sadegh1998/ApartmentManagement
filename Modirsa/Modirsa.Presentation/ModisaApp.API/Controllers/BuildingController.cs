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
        [HttpGet]
        [Route("GetBuildingAsyncBy")]
        public async Task<EditBuilding> GetBuildingAsyncBy(Guid Id)
        {
            return await _buildingApplication.GetBuildingBy(Id);
        }
        [HttpPost]
        [Route("CreateNewBuilding")]
        public async Task<bool> CreateNewBuilding([FromBody] CreateBuilding command)
        {
            var result = await _buildingApplication.Create(command);
            return result.IsSuccess;
        }
        [HttpPut]
        [Route("EditBuilding")]
        public async Task<bool> EditBuildingAsync([FromBody] EditBuilding command)
        {
            var result = await _buildingApplication.Edit(command);
            return result.IsSuccess;
        }
    }
}
