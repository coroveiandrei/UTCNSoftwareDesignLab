using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class RegisterUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
    public class LoginUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public List<RoleModel> Roles { get; set; }

    }
}
