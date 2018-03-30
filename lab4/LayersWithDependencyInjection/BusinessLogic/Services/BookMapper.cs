using BusinessLogic.Contracts;
using BusinessLogic.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Models;

namespace BusinessLogic.Services
{
    class BookMapper: IBookMapper
    {
        public BookModel Map(BookDto bookDto)
        {
            return new BookModel
            {
                Id = bookDto.Id,
                YearOfPublishing = bookDto.YearOfPublishing,
                Name = bookDto.Name,
                Author =  bookDto.Author
            };
        }

        public BookDto Map(BookModel bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                YearOfPublishing = bookModel.YearOfPublishing,
                Name = bookModel.Name,
                Author = bookModel.Author
            };
        }
    }
}
