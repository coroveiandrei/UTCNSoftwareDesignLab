namespace LibraryApplicationWithAuth.Models.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserPassword { get; set; }
        public string UserRoles { get; set; }
    }
}
