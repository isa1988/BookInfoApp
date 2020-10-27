using System;
using System.Threading.Tasks;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;

namespace BookInfoApp.Services.Contracts.AreaBook.AreaGenre
{
    public interface IGenreService : IGeneralService<Genre, GenreDto, Guid>
    {
        Task<EntityOperationResult<Genre>> EditAsync(GenreDto editDto);
    }
}
