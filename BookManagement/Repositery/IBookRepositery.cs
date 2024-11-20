using BookManagement.Models;

namespace BookManagement.Repositery
{
    public interface IBookRepositery : IGenericRepositery<Book>
    {
       Book GetBookByTitle(string  Title);
    }
}
