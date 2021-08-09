using System;
using System.Threading.Tasks;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Services.Dto.AreaBook.AreaGenre;

namespace BookInfo_Services.Contracts.AreaBook.AreaGenre
{
    public interface IGenreService : IGeneralService<Genre, GenreDto, Guid>
    {
        Task<EntityOperationResult<Genre>> EditAsync(GenreDto editDto);
    }
}
