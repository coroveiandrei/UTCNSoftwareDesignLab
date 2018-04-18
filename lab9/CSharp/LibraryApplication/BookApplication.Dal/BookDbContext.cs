using System;
using System.Collections.Generic;
using System.Text;
using BookApplication.Dao.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Dao
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
