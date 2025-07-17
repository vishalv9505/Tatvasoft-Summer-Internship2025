using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;

namespace Mission.Services.IService
{
    public interface IUserService
    {
        Task<ResponseResult> LogiUser(UserLoginRequestModel model);

        Task<List<UserResponseModel>> GetUsersAsync();

        Task<bool> RegisterUserAsync(AddUserRequestModel model);

        Task<UserResponseModel?> GetLoginUserDetailById(int userId);

        Task<ResponseResult> UpdateUserAsync(UpdateUserRequestModel model);

        Task<bool> DeleteUser(int userId);
    }
}
