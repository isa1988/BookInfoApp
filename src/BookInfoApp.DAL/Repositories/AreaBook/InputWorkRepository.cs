using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.DAL.DataBase;

namespace BookInfoApp.DAL.Repositories.AreaBook
{
    public class InputWorkRepository : Repository<InputWork>, IInputWorkRepository
    {
        public InputWorkRepository(DbContextBookInfoApp context) : base(context)
        {
        }
    }
}
