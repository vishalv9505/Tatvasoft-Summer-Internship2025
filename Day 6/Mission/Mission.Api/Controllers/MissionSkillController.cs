using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionSkill;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController(IMissionSkillService missionSkillService) : ControllerBase
    {
        private readonly IMissionSkillService _missionSkillService = missionSkillService;

        [HttpPost]
        [Route("AddMissionSkill")]
        public async Task<IActionResult> AddMissionSkill(UpsertMissionSkillRequestModel model)
        {
            await _missionSkillService.AddMissionSkillAsync(model);

            var result = new ResponseResult() { Result = ResponseStatus.Success, Message = "New Mission Skill Added Sucessfully" };

            return Ok(result);
        }

        [HttpGet]
        [Route("GetMissionSkillList")]
        public async Task<IActionResult> GetMissionSkillList()
        {
            var response = await _missionSkillService.GetMissionSkillListAsync();

            var result = new ResponseResult() { Data = response, Result = ResponseStatus.Success };

            return Ok(result);
        }

        [HttpGet]
        [Route("GetMissionSkillById/{id:int}")]
        public async Task<IActionResult> GetMissionSkillById(int id)
        {
            var response = await _missionSkillService.GetMissionSkillByIdAsync(id);

            var result = new ResponseResult();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skill Record Not Found";
                return NotFound(result);
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;

            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateMissionSkill")]
        public async Task<IActionResult> UpdateMissionSkill(UpsertMissionSkillRequestModel model)
        {
            var response = await _missionSkillService.UpdateMissionSkillAsync(model);

            var result = new ResponseResult();

            if (response)
            {
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }
            else
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skill Record Not Found";
                return NotFound(result);
            }
        }

        [HttpDelete]
        [Route("DeleteMissionSkill/{id:int}")]
        public async Task<IActionResult> DeleteMissionSkill(int id) 
        {
            var response = await _missionSkillService.DeleteMissionSkill(id);

            var result = new ResponseResult();

            if (response)
            {
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }
            else
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Skill Record Not Found";
                return NotFound(result);
            }
        }
    }
}
