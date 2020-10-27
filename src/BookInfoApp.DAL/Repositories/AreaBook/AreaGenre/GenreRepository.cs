using System;
using System.Linq;
using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        protected override IQueryable<Genre> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<Genre> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBookGenre)
            {
                if (resolveOptions.IsBook)
                {
                    query = query.Include(x => x.BookGenras).ThenInclude(x => x.Book);
                }
                else
                {
                    query = query.Include(x => x.BookGenras);
                }
            }

            return query;
        }
    }
}
