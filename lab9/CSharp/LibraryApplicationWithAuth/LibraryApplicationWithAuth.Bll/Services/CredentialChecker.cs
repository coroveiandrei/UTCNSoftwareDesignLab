using System.Linq;
using LibraryApplicationWithAuth.Bll.Mappers;
using LibraryApplicationWithAuth.Dao;
using LibraryApplicationWithAuth.Dao.Models;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWithAuth.Bll.Services
{
    public class CredentialChecker
    {
        public UserModel CheckCredential(string username, string password)
        {
            using (var ctx = new BookDbContext())
            {
                User user = ctx.Users.FirstOrDefault(un => un.Name == username && un.UserPassword == password);
                UserModel userModel = user.ToUserModel();
                return userModel;
            }
        }
    }
}
