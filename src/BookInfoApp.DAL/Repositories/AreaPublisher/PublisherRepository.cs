using System;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaPublisher
{
    public class PublisherRepository : Repository<Publisher, Guid>, IPublisherRepository
    {
        public PublisherRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
