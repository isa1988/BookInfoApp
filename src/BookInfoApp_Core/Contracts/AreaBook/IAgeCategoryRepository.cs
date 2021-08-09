using System;
using BookInfo_Core.Entities.AreaBook;

namespace BookInfo_Core.Contracts.AreaBook
{
    public interface IAgeCategoryRepository : IRepository<AgeCategory, Guid>
    {
    }
}
