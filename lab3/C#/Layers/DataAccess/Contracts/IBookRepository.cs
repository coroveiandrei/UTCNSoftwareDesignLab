using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;

namespace BusinessLogic.Contracts
{
    public interface IBookRepository
    {
        BookDto GetById(int id);
        BookDto[] GetAll();

        bool Add(BookDto book);
        void Update(BookDto book);

        void Delete(int id);
    }
}
