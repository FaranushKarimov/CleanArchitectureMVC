using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using static Services.Models.CommonModel;
using Newtonsoft.Json;
namespace Services.Repository.UserLogin
{
    public interface IUserService
    {
        Task<List<RolesModel>> GetUserRoleAsync();
        Task<string> CreateUserAsync(UserModel userModel);
        Task<bool> UserLoginAsync(LoginModel loginModel);

    }
}
