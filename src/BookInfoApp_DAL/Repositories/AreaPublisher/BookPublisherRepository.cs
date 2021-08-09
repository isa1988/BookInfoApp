using System.Linq;
using BookInfo_Core.Contracts.AreaPublisher;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BookInfo_DAL.Repositories.AreaPublisher
{
    public class BookPublisherRepository : Repository<BookPublisher>, IBookPublisherRepository
    {
        public BookPublisherRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override IQueryable<BookPublisher> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<BookPublisher> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBook)
            {
                query = query.Include(x => x.Book);
            }

            if (resolveOptions.IsPublisher)
            {
                query = query.Include(x => x.Publisher);
            }

            if (resolveOptions.IsCoverType)
            {
                query = query.Include(x => x.CoverType);
            }

            return query;
        }
    }
}
