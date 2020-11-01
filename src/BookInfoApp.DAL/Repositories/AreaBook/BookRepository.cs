using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;

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

        public override async Task<List<Book>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearBook(entities);

            return entities;
        }

        public override async Task<List<Book>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearBook(entities);

            return entities;
        }

        private void ClearBook(List<Book> entities)
        {
            foreach (var item in entities)
            {
                if (item.BookPublishers == null)
                {
                    foreach (var item2 in item.BookPublishers)
                    {
                        item2.Book = null;
                    }
                }
                if (item.BookAuthors != null)
                {
                    foreach (var item2 in item.BookAuthors)
                    {
                        item2.Book = null;
                    }
                }

                if (item.BookGenres != null)
                {
                    foreach (var item2 in item.BookGenres)
                    {
                        item2.Book = null;
                    }
                }

                if (item.InputWorks != null)
                {
                    foreach (var item2 in item.InputWorks)
                    {
                        item2.Book = null;
                    }
                }
            }
        }

        public override async Task<Book> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.BookPublishers != null)
            {
                foreach (var item2 in entity.BookPublishers)
                {
                    item2.Book = null;
                }
            }

            if (entity.BookAuthors != null)
            {
                foreach (var item2 in entity.BookAuthors)
                {
                    item2.Book = null;
                }
            }

            if (entity.BookGenres != null)
            {
                foreach (var item2 in entity.BookGenres)
                {
                    item2.Book = null;
                }
            }

            if (entity.InputWorks != null)
            {
                foreach (var item2 in entity.InputWorks)
                {
                    item2.Book = null;
                }
            }

            return entity;
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
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
                }

                if (resolveOptions.IsCoverType)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                }
            }

            if (resolveOptions.IsBookAuthor)
            {
                query = query.Include(x => x.BookAuthors);
                if (resolveOptions.IsAuthor)
                {
                    query = query.Include(x => x.BookAuthors).ThenInclude(x => x.Author);
                }
            }

            if (resolveOptions.IsBookGenre)
            {
                query = query.Include(x => x.BookGenres);
                if (resolveOptions.IsGenre)
                {
                    query = query.Include(x => x.BookGenres).ThenInclude(x => x.Genre);
                }
            }

            if (resolveOptions.IsInputWork)
            {
                query = query.Include(x => x.InputWorks);
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.InputWorks).ThenInclude(x => x.Work);
                }
            }
            return query;
        }
    }
}
