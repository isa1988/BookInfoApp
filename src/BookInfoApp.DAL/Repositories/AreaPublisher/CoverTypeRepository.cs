using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookInfoApp.DAL.Repositories.AreaPublisher
{
    public class CoverTypeRepository : Repository<CoverType, Guid>, ICoverTypeRepository
    {
        public CoverTypeRepository(DbContextBookInfoApp context) : base(context)
        {
        }
        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        public override async Task<List<CoverType>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearCoverType(entities);

            return entities;
        }

        public override async Task<List<CoverType>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearCoverType(entities);

            return entities;
        }

        private void ClearCoverType(List<CoverType> entities)
        {
            foreach (var item in entities)
            {
                if (item.BookPublishers == null)
                {
                    continue;
                }
                foreach (var item2 in item.BookPublishers)
                {
                    item2.CoverType = null;
                }
            }
        }
        public override async Task<CoverType> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.BookPublishers != null)
            {
                foreach (var item2 in entity.BookPublishers)
                {
                    item2.CoverType = null;
                }
            }

            return entity;
        }

        protected override IQueryable<CoverType> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<CoverType> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }
            
            if (resolveOptions.IsBookPublisher)
            {
                query = query.Include(x => x.BookPublishers);

                if (resolveOptions.IsPublisher)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
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
