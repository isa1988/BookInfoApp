using System;
using BookInfo_Core.Entities.AreaBook.AreaGenre;

namespace BookInfo_Core.Contracts.AreaBook.AreaGenre
{
    public interface IGenreRepository : IRepository<Genre, Guid>
    {
    }
}
