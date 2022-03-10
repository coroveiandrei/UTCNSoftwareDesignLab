using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        public UsersController(SignInManager<IdentityUser> signInManager,
                               RoleManager<IdentityRole> roleManager,
                               IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
            _roleManager = roleManager;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<UserModel> Login([FromBody] LoginUserModel user)
        {
            var result = await _userService.Login(user);
            return result;
        }

        [HttpPost("Logout")]
        [Authorize]
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost("Register")]
        [Authorize(Roles="admin")]
        public async Task<UserModel> Register([FromBody] RegisterUserModel user)
        {

            var result = await _userService.Register(user);
            return result;
        }

        [HttpGet("Users")]
        [Authorize(Roles = "admin")]
        public async Task<List<UserModel>> GetUsers()
        {
            var result = await _userService.GetUsers();
            return result;
        }

        [HttpPost("CreateRole")]
        [Authorize(Roles = "admin")]
        public async Task<bool> CreateRole([FromBody] RoleModel roleModel)
        {
            var newRole = new IdentityRole(roleModel.RoleName);
            
            var result = await _roleManager.CreateAsync(newRole);
            return (result != null);
        }

        [HttpGet("Roles")]
        [Authorize]
        public async Task<List<RoleModel>> GetRoles()
        {
            var rolesList = new List<RoleModel>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var roleModel = new RoleModel
                {
                    Id = role.Id,
                    RoleName = role.Name
                };
                rolesList.Add(roleModel);
            }
            return rolesList;
        }
    }
}
