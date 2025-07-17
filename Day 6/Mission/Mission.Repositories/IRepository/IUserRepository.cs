using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;

namespace Mission.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model);

        Task<List<UserResponseModel>> GetUsersAsync();

        Task<bool> RegisterUserAsync(AddUserRequestModel model);

        Task<UserResponseModel?> GetLoginUserDetailById(int userId);

        Task<(bool response, string message)> UpdateUserAsync(UpdateUserRequestModel model);

        Task<bool> DeleteUser(int userId);
    }
}
