using System;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.DAL.DataBase;

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
    }
}
