using BookApplication.Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookApplication.Dao.IRepositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();

        void SaveChanges();

        void Add(Book book);

        Book Update(Book book);

        void Delete(object id);

        void Delete(Book book);

        Book GetById(int id);
    }
}
