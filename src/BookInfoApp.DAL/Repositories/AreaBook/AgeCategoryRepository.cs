using System;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class AgeCategoryRepository : Repository<AgeCategory, Guid>, IAgeCategoryRepository
    {
        public AgeCategoryRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
