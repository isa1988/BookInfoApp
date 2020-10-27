using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class InputWorkRepository : Repository<InputWork>, IInputWorkRepository
    {
        public InputWorkRepository(DbContextBookInfoApp context) : base(context)
        {
        }

        protected override IQueryable<InputWork> ResolveInclude(ResolveOptions resolveOptions)
        {
            IQueryable<InputWork> query = dbSet;
            if (resolveOptions == null)
            {
                return query;
            }

            if (resolveOptions.IsBook)
            {
                query = query.Include(x => x.Book);
            }
            
            if (resolveOptions.IsInputWork)
            {
                query = query.Include(x => x.Work);
            }

            return query;
        }
    }
}
