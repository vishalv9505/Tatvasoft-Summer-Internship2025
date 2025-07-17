using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class UserRepository(MissionDbContext dbContext) : IUserRepository
    {
        private readonly MissionDbContext _context = dbContext;

        public async Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model) 
        {
            var user = await _context.Users.Where(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower()).FirstOrDefaultAsync();

            if (user == null)
            {
                return (null, "User doesn't exist for the given emailaddress");
            }

            if (user.Password != model.Password)
            {
                return (null, "Password doesn't matched");
            }

            var response = new UserLoginResponseModel() 
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                UserImage = user.UserImage,
            };

            return (response, "Login Successfully");
        }

        public async Task<List<UserResponseModel>> GetUsersAsync()
        {
            return await _context.Users.Select(u => new UserResponseModel() 
            {
                Id = u.Id,
                EmailAddress = u.EmailAddress,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                UserType = u.UserType,
                ProfileImage = u.UserImage,
            }).ToListAsync();
        }

        public async Task<bool> RegisterUserAsync(AddUserRequestModel model)
        {
            var userInDb = _context.Users.Where(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower()).FirstOrDefault();

            if (userInDb != null)
            {
                return false;
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                EmailAddress= model.EmailAddress,
                LastName= model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserType = model.UserType,
                Password = model.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserResponseModel?> GetLoginUserDetailById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return null;

            return new UserResponseModel()
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ProfileImage = user.UserImage,
                UserType = user.UserType
            };
        }

        public async Task<(bool response, string message)> UpdateUserAsync(UpdateUserRequestModel model)
        {
            var userInDb = _context.Users.Where(u => model.Id != u.Id && u.EmailAddress.ToLower() == model.EmailAddress.ToLower()).FirstOrDefault();

            if (userInDb != null)
            {
                return (false, "User already exist with same email address");
            }

            var user = _context.Users.Find(model.Id);

            if (user == null)
            {
                return (false, "User not found");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.EmailAddress = model.EmailAddress;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return (true, "User Update Successfully");
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
