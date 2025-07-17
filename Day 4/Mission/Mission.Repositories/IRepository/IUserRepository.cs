using Mission.Entities.ViewModels.Login;

namespace Mission.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model);
    }
}
