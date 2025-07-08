using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.IService
{
    public interface IUserService
    {
        Task<ResponseResult> LoginUser(userLoginRequestModel model);
    }
}
