using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_Core.Contracts.AreaPublisher;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookInfo_DAL.Repositories.AreaPublisher
{
    public class PublisherRepository : Repository<Publisher, Guid>, IPublisherRepository
    {
        public PublisherRepository(DbContextBookInfoApp context) : base(context)
        {
        }
        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        public override async Task<List<Publisher>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearPublisher(entities);

            return entities;
        }

        public override async Task<List<Publisher>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearPublisher(entities);

            return entities;
        }

        private void ClearPublisher(List<Publisher> entities)
        {
            foreach (var item in entities)
            {
                if (item.BookPublishers == null)
                {
                    continue;
                }
                foreach (var item2 in item.BookPublishers)
                {
                    item2.Publisher = null;
                }
            }
        }

        public override async Task<Publisher> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.BookPublishers != null)
            {
                foreach (var item2 in entity.BookPublishers)
                {
                    item2.Publisher = null;
                }
            }

            return entity;
        }

        protected override IQueryable<Publisher> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Publisher> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBookPublisher)
            {
                query = query.Include(x => x.BookPublishers);
                if (resolveOptions.IsCoverType)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                }
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Book);
                }
            }

            return query;
        }
    }
}
