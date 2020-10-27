using System;
using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class AgeCategoryRepository : Repository<AgeCategory, Guid>, IAgeCategoryRepository
    {
        public AgeCategoryRepository(DbContextBookInfoApp context) : base(context)
        {
        }
        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }

        protected override IQueryable<AgeCategory> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<AgeCategory> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBook)
            {
                query = query.Include(x => x.Books);
            }

            return query;
        }
    }
}
