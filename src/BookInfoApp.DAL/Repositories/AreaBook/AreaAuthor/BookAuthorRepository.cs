using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaAuthor
{
    public class BookAuthorRepository : Repository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
