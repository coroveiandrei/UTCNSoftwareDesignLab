using LibraryApplicationWithAuth.Dao.Models;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWithAuth.Bll.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToUserModel(this User user)
        {
            if (user == null)
            {
                return null;
            }

            UserModel bookModel = new UserModel
            {
                Id = user.Id,
                UserPassword = user.UserPassword,
                Name = user.Name,
                UserRoles = user.UserRoles
            };

            return bookModel;
        }
    }
}
