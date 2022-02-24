using Microsoft.EntityFrameworkCore;

namespace ConnectToDatabaseV2
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=lab2ORMv2;Trusted_Connection=True;");
        }
    }

}
