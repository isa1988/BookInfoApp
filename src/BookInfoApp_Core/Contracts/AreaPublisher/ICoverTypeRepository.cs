using System;
using BookInfo_Core.Entities.AreaPublisher;

namespace BookInfo_Core.Contracts.AreaPublisher
{
    public interface ICoverTypeRepository : IRepository<CoverType, Guid>
    {
    }
}
