using System;
using System.Linq;
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
                    var includable = (IIncludableQueryable<CoverType, BookPublisher>)query;
                    query = includable.ThenInclude(x => x.Publisher);
                }
                if (resolveOptions.IsBook)
                {
                    var includable = (IIncludableQueryable<CoverType, BookPublisher>)query;
                    query = includable.ThenInclude(x => x.Book);
                }
            }

            return query;
        }
    }
}
