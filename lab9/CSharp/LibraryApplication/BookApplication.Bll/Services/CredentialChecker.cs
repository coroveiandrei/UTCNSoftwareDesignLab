using System.Linq;
using BookApplication.Bll.Mappers;
using BookApplication.Dao;
using BookApplication.Dao.Models;

namespace BookApplication.Bll.Services
{
    public class CredentialChecker
    {
        public UserModel CheckCredential(string username, string password)
        {
            using (var ctx = new BookDbContext(null))
            {
                User user = ctx.Users.FirstOrDefault(un => un.Name == username && un.UserPassword == password);
                UserModel userModel = user.ToUserModel();
                return userModel;
            }
        }
    }
}
