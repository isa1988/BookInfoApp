using System;
using BookInfo_Core.Entities.AreaPublisher;

namespace BookInfo_Core.Contracts.AreaPublisher
{
    public interface IPublisherRepository : IRepository<Publisher, Guid>
    {
    }
}
