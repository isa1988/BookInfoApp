using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_Core.Contracts.AreaBook;
using BookInfo_Core.Entities.AreaBook;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BookInfo_DAL.Repositories.AreaBook
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
        
        public override async Task<List<AgeCategory>> GetAllAsync(ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetAllAsync(resolveOptions);

            ClearAgeCategory(entities);

            return entities;
        }

        public override async Task<List<AgeCategory>> GetPageAsync(int pageNumber, int rowCount, ResolveOptions resolveOptions = null)
        {
            var entities = await base.GetPageAsync(pageNumber, rowCount, resolveOptions);

            ClearAgeCategory(entities);

            return entities;
        }

        private void ClearAgeCategory(List<AgeCategory> entities)
        {
            foreach (var item in entities)
            {
                if (item.Books == null)
                {
                    continue;
                }
                foreach (var item2 in item.Books)
                {
                    item2.AgeCategory = null;
                }
            }
        }

        public override async Task<AgeCategory> GetByIdAsync(Guid id, ResolveOptions resolveOptions = null)
        {
            var entity = await base.GetByIdAsync(id, resolveOptions);

            if (entity.Books != null)
            {
                foreach (var item2 in entity.Books)
                {
                    item2.AgeCategory = null;
                }
            }

            return entity;
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
