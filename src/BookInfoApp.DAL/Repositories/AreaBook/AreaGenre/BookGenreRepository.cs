using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaGenre
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
