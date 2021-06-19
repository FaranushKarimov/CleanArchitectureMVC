using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;
using DataAccessLayer.ApplicationDbContext;
using AutoMapper;
using System.Threading.Tasks;
using static Services.Models.CommonModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Repository.UserLogin
{
    public class UserService: IUserService
    {
        private readonly CFCDbContext _cFCDbContext;
        private readonly IMapper _mapper;

        public UserService(CFCDbContext cFCDbContext,IMapper mapper)
        {
            _cFCDbContext = cFCDbContext;
            _mapper = mapper;
        }

        public async Task<string> CreateUserAsync (UserModel userModel)
        {
            try
            {
                var userExists = await _cFCDbContext.users.Where(c => c.isActive.Equals(true)).ToListAsync();
                if(userExists.Count == 0)
                {
                    User result = new User
                    {
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        PhoneNumber = userModel.PhoneNumber,
                        Password = userModel.Password,
                        Email = userModel.Email,
                        RoleId = await _cFCDbContext.userRoles.Where(c => c.IsActive.Equals(true) && c.RoleName.Equals(userModel.RoleName)).Select(x => x.RoleId).FirstOrDefaultAsync(),
                        isActive = true,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };
                    await _cFCDbContext.users.AddAsync(result);
                    await _cFCDbContext.SaveChangesAsync();
                    return "User Created Success";
                }
                else return "Email already exists";
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UserLoginAsync(LoginModel loginModel)
        {
            try
            {
                var response = await _cFCDbContext.users.Where(c => c.Email.Equals(loginModel.UserName) && c.Password.Equals(loginModel.Password) && c.isActive).AnyAsync();
                if (response is true) return true; else return false;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RolesModel>> GetUserRoleAsync()
        {
            try
            {
                var userRoles = await _cFCDbContext.userRoles.Where(c => c.IsActive).ToListAsync();
                return _mapper.Map<List<RolesModel>>(userRoles);
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
