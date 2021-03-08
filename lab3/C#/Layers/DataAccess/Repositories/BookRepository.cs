using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusinessLogic.Contracts;
using BusinessLogic.Model;


namespace DataAccess.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly IList<BookDto> inMemoryBooks = new List<BookDto>();
        private string connectionString = "Data source=.\\SQLEXPRESS; Initial Catalog =hw1; Trusted_Connection=Yes;";
        private SqlConnection sqlConnection;
        public BookRepository()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public BookDto GetById(int id)
        {
            return null;
        }

        public BookDto[] GetAll()
        {
            var result = new List<BookDto>();
            using (SqlCommand cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = "select * from Book";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new BookDto()
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Author = (string)reader[2],
                        YearOfPublishing = (int)reader[3]
                    });
                }

            }

            return result.ToArray();
        }

        public bool Add(BookDto book)
        {
           inMemoryBooks.Add(book);
            return true;
        }

        public void Update(BookDto book)
        {
           inMemoryBooks[inMemoryBooks.IndexOf(inMemoryBooks.First(x=> x.Id == book.Id))] = book;
        }

        public void Delete(int id)
        {
            inMemoryBooks.RemoveAt(inMemoryBooks.IndexOf(inMemoryBooks.First(x => x.Id == id)));
        }
    }
}
