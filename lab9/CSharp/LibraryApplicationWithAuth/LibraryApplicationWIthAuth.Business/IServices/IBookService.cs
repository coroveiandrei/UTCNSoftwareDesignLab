using System.Collections.Generic;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWithAuth.Bll.IServices
{
    public interface IBookService
    {
        void AddBook(BookModel bookModel);

        void DeleteBook(BookModel bookModel);

        List<BookModel> GetAll();

        BookModel GetById(int id);

        void UpdateBook(BookModel bookModel);
    }
}
