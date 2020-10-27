using System;
using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaAuthor
{
    public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        protected override IQueryable<Author> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Author> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBookAuthor)
            {
                query = query.Include(x => x.BookAuthors);
                if (resolveOptions.IsBook)
                {
                    var includable = (IIncludableQueryable<Author, BookAuthor>)query;
                    query = includable.ThenInclude(x => x.Book);
                }
            }

            return query;
        }
    }
}
