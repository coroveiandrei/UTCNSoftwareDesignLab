using BusinessLogic.Model;

namespace BusinessLogic.Contracts
{
    public interface IBookService
    {
        BookModel GetById(int id);
        BookModel[] GetAll();

        bool Add(BookModel book);
        void Update(BookModel book);
        void Delete(int id);

        int GetAgeOfBook(int id);
    }
}
