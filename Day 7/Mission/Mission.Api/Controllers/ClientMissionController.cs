using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController(IMissionService missionService) : Controller
    {
        private readonly IMissionService _missionService = missionService;

        [HttpGet]
        [Route("ClientSideMissionList/{id:int}")]
        public async Task<IActionResult> GetClientSideMissionList(int id)
        {
            var response = await _missionService.GetClientSideMissionList(id);
            var result = new ResponseResult() { Result = ResponseStatus.Success, Data = response };
            return Ok(result);
        }
    }
}
