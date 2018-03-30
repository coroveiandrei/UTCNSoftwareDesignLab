using BookApplication.Dao.IRepositories;
using BookApplication.Dao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookApplication.Dao.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected BookDbContext _dbContext;
        protected DbSet<Book> _dbSet;

        public BookRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Book>();
        }

        public void Add(Book book)
        {
            _dbSet.Add(book);
        }

        public virtual void Delete(object id)
        {
            Book bookToDelete = _dbSet.Find(id);
            Delete(bookToDelete);
        }

        public void Delete(Book book)
        {
            if (_dbContext.Entry(book).State == EntityState.Detached)
            {
                _dbSet.Attach(book);
            }

            _dbSet.Remove(book);
        }

        public IQueryable<Book> GetAll()
        {
            return _dbSet;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges(true);
        }

        public Book Update(Book book)
        {
            return _dbSet.Update(book).Entity;
        }

        public Book GetById(int id)
        {
            var book = _dbSet.Where(b => b.Id == id).FirstOrDefault();

            return book;
        }
    }
}
