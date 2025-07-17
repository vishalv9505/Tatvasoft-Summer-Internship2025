using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpGet]
        [Route("UserDetailList")]
        public async Task<IActionResult> GetUserDetailList()
        {
            var response = await _userService.GetUsersAsync();

            var result = new ResponseResult() { Data = response, Result = ResponseStatus.Success };

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteUser/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = new ResponseResult();
            if (userId == 1)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "You can't delete admin record";
                return BadRequest(result);
            }

            var response = await _userService.DeleteUser(userId);

            if (response)
            {
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }

            result.Result = ResponseStatus.Error;
            result.Message = "User not found";

            return NotFound(result);
        }
    }
}
