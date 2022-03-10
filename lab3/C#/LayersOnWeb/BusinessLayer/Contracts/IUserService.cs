using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IUserService
    {
        Task<UserModel> Register(RegisterUserModel user);
        Task<UserModel> Login(LoginUserModel user);
        Task<List<UserModel>> GetUsers();
        bool ExistsUser(Guid id);
        string GetUserName(Guid id);
    }
}
