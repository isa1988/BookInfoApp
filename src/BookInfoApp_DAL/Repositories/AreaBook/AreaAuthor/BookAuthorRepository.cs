using BookInfo_Core.Contracts.AreaBook.AreaAuthor;
using BookInfo_Core.Entities.AreaBook.AreaAuthor;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookInfo_DAL.Repositories.AreaBook.AreaAuthor
{
    public class BookAuthorRepository : Repository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override IQueryable<BookAuthor> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<BookAuthor> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBook)
            {
                query = query.Include(x => x.Book);
            }

            if (resolveOptions.IsAuthor)
            {
                query = query.Include(x => x.Author);
            }

            return query;
        }
    }
}
