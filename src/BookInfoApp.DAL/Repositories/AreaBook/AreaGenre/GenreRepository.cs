using System;
using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook.AreaGenre
{
    public class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override Guid GetNewId()
        {
            var retVal = Guid.NewGuid();
            return retVal;
        }
    }
}
