using System;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;

namespace BookInfoApp.Core.Contracts.AreaBook.AreaAuthor
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
    }
}
