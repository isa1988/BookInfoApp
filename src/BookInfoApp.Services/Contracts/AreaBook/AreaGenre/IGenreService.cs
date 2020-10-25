using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;

namespace BookInfoApp.Services.Contracts.AreaBook.AreaGenre
{
    public interface IGenreService : IGeneralService<Genre, GenreDto>
    {
    }
}
