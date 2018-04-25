using System.Linq;
using LibraryApplicationWithAuth.Dao.Models;

namespace LibraryApplicationWithAuth.Dao.IRepositories
{
    public interface IUserRepository
    {
        User GetUserByUserNameAndPassword(string userName, string password);
    }
}
