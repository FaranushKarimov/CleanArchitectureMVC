using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repository.UserLogin;

namespace CleanArchitectureMVC.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IUserService _userService;

        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(nameof(GetUserRoles))]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                var result = await _userService.GetUserRoleAsync();
                if (result is not null) return Ok(result); else return BadRequest("No Data Found");
            } catch(Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
