using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.ViewModels.Login
{
    public class userLoginRequestModel
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
