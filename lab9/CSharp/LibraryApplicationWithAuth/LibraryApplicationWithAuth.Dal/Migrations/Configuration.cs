using LibraryApplicationWithAuth.Dao.Models;

namespace LibraryApplicationWithAuth.Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryApplicationWithAuth.Dao.BookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryApplicationWithAuth.Dao.BookDbContext context)
        {
            context.Users.Add(new User { Name = "admin", UserPassword = "admin", UserRoles = "admin" });
            context.Users.Add(new User { Name = "student", UserPassword = "student", UserRoles = "student" });
            context.Users.Add(new User { Name = "both", UserPassword = "both", UserRoles = "admin,student" });

            context.Books.Add(new Book() { Author = "J.K. Rowling", Title = "Harry Potter" });
            context.Books.Add(new Book() { Author = "George R.R. Martin", Title = "Game of thrones" });
        }
    }
}
