using System.Data.Entity;
using System.Linq;
using LibraryApplicationWithAuth.Dao.IRepositories;
using LibraryApplicationWithAuth.Dao.Models;

namespace LibraryApplicationWithAuth.Dao.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected BookDbContext _dbContext;
        protected DbSet<User> _dbSet;

        public UserRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<User>();
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            User user = _dbContext.Users.FirstOrDefault(un => un.Name == userName && un.UserPassword == password);
            return user;
        }

    }
}
