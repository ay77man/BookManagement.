using BookManagement.Models;

namespace BookManagement.Repositery
{
    public class BookRepositery : GenericRepositery<Book> ,IBookRepositery
    {
       // private readonly BookManagementDbContext _Context;
        public BookRepositery(BookManagementDbContext Context) : base(Context)
        {
          //  this._Context = _Context;
        }
        public Book GetBookByTitle(string Title)
        {
          return _Context.Books.FirstOrDefault(b=>b.Title == Title);
        }
    }
}
