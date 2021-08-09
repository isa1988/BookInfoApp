using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_Core.Contracts.AreaBook.AreaGenre;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookInfo_DAL.Repositories.AreaBook.AreaGenre
{
    public class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        public override async Task<List<Genre>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearGenre(entities);

            return entities;
        }

        public override async Task<List<Genre>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearGenre(entities);

            return entities;
        }

        private void ClearGenre(List<Genre> entities)
        {
            foreach (var item in entities)
            {
                if (item.BookGenras == null)
                {
                    continue;
                }
                foreach (var item2 in item.BookGenras)
                {
                    item2.Genre = null;
                }
            }
        }

        public override async Task<Genre> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.BookGenras != null)
            {
                foreach (var item2 in entity.BookGenras)
                {
                    item2.Genre = null;
                }
            }

            return entity;
        }

        protected override IQueryable<Genre> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Genre> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBookGenre)
            {
                query = query.Include(x => x.BookGenras);
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookGenras).ThenInclude(x => x.Book);
                }
            }

            return query;
        }
    }
}
