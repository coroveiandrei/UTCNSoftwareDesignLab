using System.Data.Entity;
using LibraryApplicationWithAuth.Dao.Models;


namespace LibraryApplicationWithAuth.Dao
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
