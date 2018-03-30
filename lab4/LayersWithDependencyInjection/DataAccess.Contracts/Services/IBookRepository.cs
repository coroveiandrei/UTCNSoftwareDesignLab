using DataAccess.Contracts.Models;

namespace DataAccess.Contracts.Services
{
    public interface IBookRepository
    {
        BookDto GetById(int id);
        BookDto[] GetAll();

        bool Add(BookDto book);
        void Update(BookDto book);

        void Delete(int id);
    }
}
