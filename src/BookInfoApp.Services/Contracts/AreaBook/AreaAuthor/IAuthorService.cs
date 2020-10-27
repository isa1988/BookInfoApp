using System;
using System.Threading.Tasks;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;

namespace BookInfoApp.Services.Contracts.AreaBook.AreaAuthor
{
    public interface IAuthorService : IGeneralService<Author, AuthorDto, Guid>
    {
        Task<EntityOperationResult<Author>> EditAsync(AuthorDto editDto);
        
    }
}
