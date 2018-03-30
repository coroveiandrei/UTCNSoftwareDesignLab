using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;

namespace BusinessLogic.Contracts
{
    internal interface IBookMapper
    {
        BookModel Map(BookDto bookDto);
        BookDto Map(BookModel bookModel); 
    }
}
