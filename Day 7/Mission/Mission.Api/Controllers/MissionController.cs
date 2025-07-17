using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Mission;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpPost]
        [Route("AddMission")]
        public async Task<IActionResult> AddMission(AddMissionRequestModel model)
        {
            await _missionService.AddMissionRequestAsync(model);
            var result = new ResponseResult() { Result = ResponseStatus.Success, Message = "Mission Added Successfully" };
            return Ok(result);
        }

        [HttpGet]
        [Route("MissionList")]
        public async Task<IActionResult> GetMissionList()
        {
            var response = await _missionService.GetMissionList();
            var result = new ResponseResult() { Result = ResponseStatus.Success, Data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("MissionDetailById/{id:int}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var response = await _missionService.GetMissionById(id);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPost]
        [Route("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionRequestViewModel model)
        {
            var response = await _missionService.UpdateMission(model);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpDelete]
        [Route("DeleteMission/{missionId:int}")]
        public async Task<IActionResult> DeleteMission(int missionId)
        {
            var response = await _missionService.DeleteMission(missionId);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }
    }
}
