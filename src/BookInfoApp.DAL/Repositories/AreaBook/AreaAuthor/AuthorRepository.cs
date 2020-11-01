using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public override async Task<List<Author>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearAuthor(entities);

            return entities;
        }

        public override async Task<List<Author>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearAuthor(entities);

            return entities;
        }

        private void ClearAuthor(List<Author> entities)
        {
            foreach (var item in entities)
            {
                if (item.BookAuthors == null)
                {
                    continue;
                }
                foreach (var item2 in item.BookAuthors)
                {
                    item2.Author = null;
                }
            }
        }

        public override async Task<Author> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.BookAuthors != null)
            {
                foreach (var item2 in entity.BookAuthors)
                {
                    item2.Author = null;
                }
            }

            return entity;
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
                    query = query.Include(x => x.BookAuthors).ThenInclude(x => x.Book);
                }
            }

            return query;
        }
    }
}
