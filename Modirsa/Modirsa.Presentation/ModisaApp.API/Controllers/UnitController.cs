using BuildingManagement.Application.Contract.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitApplication _unitApplication;

        public UnitController(IUnitApplication unitApplication)
        {
            _unitApplication = unitApplication;
        }

        [HttpGet]
        [Route("GetAllUnitsAsync")]
        public async Task<List<UnitViewModel>> GetAllUnitsAsync()
        {
            return await _unitApplication.GetAllUnit();
        }

        [HttpGet]
        [Route("GetUnitByAsync")]
        public async Task<UnitViewModel> GetUnitByAsync(Guid Id)
        {
            return await _unitApplication.GetUnitBy(Id);
        }
        [HttpPost]
        [Route("CreateUnitAsync")]
        public async Task<bool> CreateUnitAsync([FromBody] CreateUnit command)
        {
            var result = await _unitApplication.CreateAsync(command);
            return result.IsSuccess;
        }
        [HttpPut]
        [Route("EditUnitAsync")]
        public async Task<bool> EditUnitAsync([FromBody] EditUnit command)
        {
            var result = await _unitApplication.EditAsync(command);
            return result.IsSuccess;
        }
        [HttpPatch]
        [Route("SearchUnitAsync")]
        public async Task<List<UnitViewModel>> SearchUnitAsync([FromBody] UnitSearchModel command)
        {
            return await _unitApplication.Search(command);
        }

    }
}
