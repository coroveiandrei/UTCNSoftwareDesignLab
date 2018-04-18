using BookApplication.Bll.IServices;
using BookApplication.Dao.IRepositories;
using BookApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookApplication.Bll.Mappers;
using System.Linq;

namespace BookApplication.Bll.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;

        public BookService(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
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
            var bookModelList = _iBookRepository.GetAll()
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
