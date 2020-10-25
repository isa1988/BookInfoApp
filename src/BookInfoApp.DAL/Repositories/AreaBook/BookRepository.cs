using System;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
