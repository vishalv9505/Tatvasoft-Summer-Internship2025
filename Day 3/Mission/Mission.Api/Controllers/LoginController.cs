using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(userLoginRequestModel model)
        {
            var response = await _userService.LoginUser(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
