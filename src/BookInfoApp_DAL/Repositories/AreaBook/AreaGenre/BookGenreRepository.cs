using System.Linq;
using BookInfo_Core.Contracts.AreaBook.AreaGenre;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BookInfo_DAL.Repositories.AreaBook.AreaGenre
{
    public class BookGenreRepository : Repository<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override IQueryable<BookGenre> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<BookGenre> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBook)
            {
                query = query.Include(x => x.Book);
            }

            if (resolveOptions.IsGenre)
            {
                query = query.Include(x => x.Genre);
            }

            return query;
        }
    }
}
