using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Contracts.AreaBook
{
    public interface IBookService : IGeneralService<Book, BookDto>
    {
    }
}
