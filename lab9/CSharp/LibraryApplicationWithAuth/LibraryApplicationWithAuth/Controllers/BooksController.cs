using System.Collections.Generic;
using System.Web.Http;
using BookApplication.Models;
using LibraryApplicationWithAuth.Bll.IServices;
using LibraryApplicationWithAuth.Models.Models;

namespace LibraryApplicationWithAuth.Controllers
{
    [System.Web.Http.Route("api/books")]
    
    public class BooksController: ApiController
    {
        private IBookService _iBookService;

        public BooksController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize(Roles = "Admin, Student")]
        public IEnumerable<BookModel> GetAll()
        {
            var bookModelList = _iBookService.GetAll();

            return bookModelList;
        }

        // GET api/values/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id:int}")]
        [System.Web.Http.Authorize(Roles = "Admin, Student")]
        public IHttpActionResult GetById(int id)
        {
            var bookModel = _iBookService.GetById(id);

            if (bookModel == null)
            {
                return NotFound();
            }

            return Ok(bookModel);
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize(Roles = "Admin")]
        public IHttpActionResult Create([FromBody] BookApiModel bookApiModel)
        {
            if (bookApiModel == null)
            {
                return BadRequest();
            }

            var bookModel = new BookModel
            {
                Author = bookApiModel.Author,
                Title = bookApiModel.Title
            };

            _iBookService.AddBook(bookModel);

            return Ok(bookModel);
        }

        // PUT api/books/5
        [System.Web.Http.HttpPut]
        [System.Web.Http.Authorize(Roles = "Admin")]
        public IHttpActionResult Update([FromBody]BookModel bookModel)
        {
            if (bookModel == null)
            {
                return BadRequest();
            }

            _iBookService.UpdateBook(bookModel);

            return Ok(bookModel);

        }

        // DELETE api/books/id
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            var book = _iBookService.GetById(id);

            if (book == null)
            {
                return BadRequest();
            }

            _iBookService.DeleteBook(book);
            return Ok();

        }
    }
}
