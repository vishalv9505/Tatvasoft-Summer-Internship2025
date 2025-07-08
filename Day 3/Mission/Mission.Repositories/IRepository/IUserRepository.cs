using Mission.Entities.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<(UserLoginResponseModel? response, string message)> LoginUser(userLoginRequestModel model);
    }
}
