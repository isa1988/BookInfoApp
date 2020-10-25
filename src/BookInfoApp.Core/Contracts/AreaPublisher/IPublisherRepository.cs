using System;
using BookInfoApp.Core.Entities.AreaPublisher;

namespace BookInfoApp.Core.Contracts.AreaPublisher
{
    public interface IPublisherRepository : IRepository<Publisher, Guid>
    {
    }
}
