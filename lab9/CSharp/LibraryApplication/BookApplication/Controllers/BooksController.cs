using System;
using System.Collections.Generic;
using BookApplication.Bll.IServices;
using BookApplication.Models;
using BookApplication.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    [Route("api/books")]
    [Authorize]
    public class BooksController
    {
        private IBookService _iBookService;

        public BooksController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin, Reader")]
        public IEnumerable<BookModel> GetAll()
        {
            var bookModelList = _iBookService.GetAll();

            return bookModelList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Reader")]
        public IActionResult GetById(int id)
        {
            var bookModel = _iBookService.GetById(id);

            if (bookModel == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(bookModel);
        }

        // POST api/values
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] BookApiModel bookApiModel)
        {
            if (bookApiModel == null)
            {
                return new BadRequestResult();
            }

            var bookModel = new BookModel
            {
                Author = bookApiModel.Author,
                Title = bookApiModel.Title
            };

            _iBookService.AddBook(bookModel);

            return new ObjectResult(bookModel);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]BookModel bookModel)
        {
            if (bookModel == null)
            {
                return new BadRequestResult();
            }

            _iBookService.UpdateBook(bookModel);

            return new OkObjectResult(bookModel);
        }

        // DELETE api/books/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var book = _iBookService.GetById(id);

            if (book == null)
            {
                return new BadRequestResult();
            }

            _iBookService.DeleteBook(book);
            return new NoContentResult();
        }
    }
}
