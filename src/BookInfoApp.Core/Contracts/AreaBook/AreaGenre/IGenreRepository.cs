using System;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;

namespace BookInfoApp.Core.Contracts.AreaBook.AreaGenre
{
    public interface IGenreRepository : IRepository<Genre, Guid>
    {
    }
}
