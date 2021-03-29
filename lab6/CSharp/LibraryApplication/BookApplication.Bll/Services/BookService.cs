using BookApplication.Bll.IServices;
using BookApplication.Dao.IRepositories;
using BookApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookApplication.Bll.Mappers;
using System.Linq;
using BookApplication.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApplication.Bll.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;
        private readonly IConfiguration _configuration;

        public BookService(IBookRepository iBookRepository, IConfiguration configuration)
        {
            _iBookRepository = iBookRepository;
            _configuration = configuration;
        }


        // If edit book is not correct then you cannot call delete
        public void AddBook(BookModel bookModel)
        {
            var book = bookModel.ToBook();
            // example of magic string / magic int
            int numberOfBooksAddedToday = 100; // get value from repository
            //iBookRepository.GetBooksAddedToday(); // 100

            if (ValidConditionForAddingBooks(numberOfBooksAddedToday))
            {
                _iBookRepository.Add(book);
                _iBookRepository.SaveChanges();
            }
        }

        private bool ValidConditionForAddingBooks(int numberOfBooksAddedToday)
        {
            //return numberOfBooksAddedToday < Constants.MAXNUMBEROFBOOKSPERDAY;
            return numberOfBooksAddedToday < Int32.Parse(_configuration.GetSection("MaxNumberOfBooks").Value);
            //return numberOfBooksAddedToday < _configuration.GetSection("General").Value;
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
