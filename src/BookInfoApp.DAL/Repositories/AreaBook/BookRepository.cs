using System;
using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(DbContextBookInfoApp context) : base(context)
        {
        }
        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        protected override IQueryable<Book> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Book> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsAgeCategory)
            {
                query = query.Include(x => x.AgeCategory);
            }

            if (resolveOptions.IsBookPublisher)
            {
                if (resolveOptions.IsPublisher && resolveOptions.IsCoverType)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                }
                else if (resolveOptions.IsPublisher && !resolveOptions.IsCoverType)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
                }

                else if (!resolveOptions.IsPublisher && resolveOptions.IsCoverType)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                }
                else
                {
                    query = query.Include(x => x.BookPublishers);
                }
            }

            if (resolveOptions.IsBookAuthor)
            {
                if (resolveOptions.IsAuthor)
                {
                    query = query.Include(x => x.BookAuthors).ThenInclude(x => x.Author);
                }
                else
                {
                    query = query.Include(x => x.BookAuthors);
                }
            }

            if (resolveOptions.IsBookGenre)
            {
                if (resolveOptions.IsGenre)
                {
                    query = query.Include(x => x.BookGenres).ThenInclude(x => x.Genre);
                }
                else
                {
                    query = query.Include(x => x.BookGenres);
                }
            }

            if (resolveOptions.IsInputWork)
            {
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.InputWorks).ThenInclude(x => x.Work);
                }
                else
                {
                    query = query.Include(x => x.InputWorks);
                }
            }
            return query;
        }
    }
}
