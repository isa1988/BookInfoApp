using System;
using BookInfo_Core.Entities.AreaBook;
using BookInfo_Services.Dto.AreaBook;

namespace BookInfo_Services.Contracts.AreaBook
{
    public interface IBookService : IGeneralService<Book, BookDto, Guid>
    {
    }
}
