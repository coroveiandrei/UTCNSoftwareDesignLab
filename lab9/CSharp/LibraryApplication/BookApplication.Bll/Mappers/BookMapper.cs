using BookApplication.Dao.Models;
using BookApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApplication.Bll.Mappers
{
    public static class BookMapper
    {
        public static BookModel ToBookModel(this Book book)
        {
            if (book == null)
            {
                return null;
            }

            BookModel bookModel = new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };

            return bookModel;
        }

        public static Book ToBook(this BookModel bookModel)
        {
            if (bookModel == null)
            {
                return null;
            }

            Book book = new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author
            };

            return book;
        }
    }
}
