using System;
using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaAuthor
{
    public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
