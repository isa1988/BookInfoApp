using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                if (resolveOptions.IsPublisher && resolveOptions.IsBook)
                {
                    //query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
                    //query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Book);
                    query = query.Include(x => x.BookPublishers);
                }
                else if (resolveOptions.IsPublisher && !resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookPublishers).ThenInclude(x => x.Publisher);
                }

                else if (!resolveOptions.IsPublisher && resolveOptions.IsBook)
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
