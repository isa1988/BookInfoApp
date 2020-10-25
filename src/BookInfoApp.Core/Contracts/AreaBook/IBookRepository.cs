using System;
using BookInfoApp.Core.Entities.AreaBook;

namespace BookInfoApp.Core.Contracts.AreaBook
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}
