using System.Linq;
using LibraryApplicationWithAuth.Dao.Models;

namespace LibraryApplicationWithAuth.Dao.IRepositories
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
