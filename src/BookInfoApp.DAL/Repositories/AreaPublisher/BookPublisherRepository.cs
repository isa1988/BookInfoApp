using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaPublisher
{
    public class BookPublisherRepository : Repository<BookPublisher>, IBookPublisherRepository
    {
        public BookPublisherRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
