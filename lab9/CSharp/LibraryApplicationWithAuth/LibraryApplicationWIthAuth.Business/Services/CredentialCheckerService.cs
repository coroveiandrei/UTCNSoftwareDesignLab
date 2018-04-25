using LibraryApplicationWithAuth.Bll.Mappers;
using LibraryApplicationWithAuth.Dao;
using LibraryApplicationWithAuth.Dao.IRepositories;
using LibraryApplicationWithAuth.Models.Models;
using LibraryApplicationWIthAuth.Business.IServices;

namespace LibraryApplicationWIthAuth.Business.Services
{
    public class CredentialCheckerService: ICredentialCheckerService
    {
        private readonly IUserRepository userRepository;
        public CredentialCheckerService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserModel CheckCredential(string username, string password)
        {
            using (var ctx = new BookDbContext())
            {
                var user = userRepository.GetUserByUserNameAndPassword(username, password);
                UserModel userModel = user.ToUserModel();
                return userModel;
            }
        }
    }

}
