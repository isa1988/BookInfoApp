using BookInfo_Core.Contracts.AreaBook;
using BookInfo_Core.Entities.AreaBook;
using BookInfo_Core.Helper;
using BookInfo_DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookInfo_DAL.Repositories.AreaBook
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
