using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaAuthor
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
