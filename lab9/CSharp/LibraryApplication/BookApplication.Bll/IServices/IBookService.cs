using BookApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApplication.Bll.IServices
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
