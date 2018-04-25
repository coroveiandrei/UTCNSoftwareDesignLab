using System.Collections.Generic;
using System.Linq;
using LibraryApplicationWithAuth.Bll.IServices;
using LibraryApplicationWithAuth.Bll.Mappers;
using LibraryApplicationWithAuth.Dao;
using LibraryApplicationWithAuth.Dao.IRepositories;
using LibraryApplicationWithAuth.Dao.Repositories;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWithAuth.Bll.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;

        public BookService()
        {
            _iBookRepository = new BookRepository(new BookDbContext());
        }

        public void AddBook(BookModel bookModel)
        {
            var book = bookModel.ToBook();
            _iBookRepository.Add(book);
            _iBookRepository.SaveChanges();
        }

        public void DeleteBook(BookModel bookModel)
        {
            var book = bookModel.ToBook();
            _iBookRepository.Delete(book.Id);
            _iBookRepository.SaveChanges();
        }

        public List<BookModel> GetAll()
        {
            var bookModelList = _iBookRepository.GetAll().ToList()
                .Select(b => b.ToBookModel())
                .OrderBy(t => t.Title)
                .ToList();

            return bookModelList;
        }

        public BookModel GetById(int id)
        {
            var bookModel =_iBookRepository.GetById(id).ToBookModel();

            return bookModel;
        }

        public void UpdateBook(BookModel bookModel)
        {
            var book = bookModel.ToBook();
            _iBookRepository.Update(book);
            _iBookRepository.SaveChanges();
        }
    }
}
