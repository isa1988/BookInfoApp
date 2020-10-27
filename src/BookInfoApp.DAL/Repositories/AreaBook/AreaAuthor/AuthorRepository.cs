using System;
using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;

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

            //dbSet = dbSet.If(resolveOptions.IsBookAuthor, q => q.Include(e => e.BookAuthors)
                //.If(resolveOptions.IsBookAuthor && resolveOptions.IsBook, q2 => q2.ThenInclude(e => e.BookAuthor)));

            if (resolveOptions.IsBookAuthor)
            {
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookAuthors).ThenInclude(x => x.Book);
                }
                else
                {
                    query = query.Include(x => x.BookAuthors);
                }
            }

            return query;
        }
    }
}
