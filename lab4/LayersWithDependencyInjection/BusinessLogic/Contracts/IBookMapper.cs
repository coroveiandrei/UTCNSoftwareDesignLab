using BusinessLogic.Contracts.Models;
using DataAccess.Contracts.Models;

namespace BusinessLogic.Contracts
{
    public interface IBookMapper
    {
        BookModel Map(BookDto bookDto);
        BookDto Map(BookModel bookModel);
    }
}
