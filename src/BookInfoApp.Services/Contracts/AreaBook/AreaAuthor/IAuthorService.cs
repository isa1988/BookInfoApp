using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;

namespace BookInfoApp.Services.Contracts.AreaBook.AreaAuthor
{
    public interface IAuthorService : IGeneralService<Author, AuthorDto>
    {
    }
}
