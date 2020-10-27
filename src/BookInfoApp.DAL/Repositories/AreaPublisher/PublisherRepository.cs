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

        protected override IQueryable<Publisher> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Publisher> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBookPublisher)
            {
                if (resolveOptions.IsCoverType && resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Book);
                }
                else if (resolveOptions.IsCoverType && !resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.CoverType);
                }
                else if (!resolveOptions.IsCoverType && resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Book);
                }
                else
                {
                    query = query.Include(x => x.BookPublishers);
                }
            }

            return query;
        }
    }
}
