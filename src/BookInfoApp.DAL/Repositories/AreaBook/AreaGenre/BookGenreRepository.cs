using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaGenre
{
    public class BookGenreRepository : Repository<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
