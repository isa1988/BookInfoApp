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
                query = query.Include(x => x.BookPublishers);
                if (resolveOptions.IsPublisher)
                {
                    var includable = (IIncludableQueryable<Book, BookPublisher>)query;
                    query = includable.ThenInclude(x => x.Publisher);
                }
                if (resolveOptions.IsCoverType)
                {
                    var includable = (IIncludableQueryable<Book, BookPublisher>)query;
                    query = includable.ThenInclude(x => x.CoverType);
                }
            }

            if (resolveOptions.IsBookAuthor)
            {
                query = query.Include(x => x.BookAuthors);
                if (resolveOptions.IsAuthor)
                {
                    var includable = (IIncludableQueryable<Book, BookAuthor>)query;
                    query = includable.ThenInclude(x => x.Author);
                }
            }

            if (resolveOptions.IsBookGenre)
            {
                query = query.Include(x => x.BookGenres);
                if (resolveOptions.IsGenre)
                {
                    var includable = (IIncludableQueryable<Book, BookGenre>)query;
                    query = includable.ThenInclude(x => x.Genre);
                }
            }

            if (resolveOptions.IsInputWork)
            {
                query = query.Include(x => x.InputWorks);
                if (resolveOptions.IsBook)
                {
                    var includable = (IIncludableQueryable<Book, InputWork>)query;
                    query = includable.ThenInclude(x => x.Work);
                }
            }
            return query;
        }
    }
}
