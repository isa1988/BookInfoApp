using System;
using System.Threading.Tasks;
using BookInfo_Core.Entities.AreaBook.AreaAuthor;
using BookInfo_Services.Dto.AreaBook.AreaAuthor;

namespace BookInfo_Services.Contracts.AreaBook.AreaAuthor
{
    public interface IAuthorService : IGeneralService<Author, AuthorDto, Guid>
    {
        Task<EntityOperationResult<Author>> EditAsync(AuthorDto editDto);
        
    }
}
