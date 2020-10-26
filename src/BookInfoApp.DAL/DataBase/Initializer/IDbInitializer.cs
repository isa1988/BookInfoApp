using System.Threading.Tasks;

namespace BookInfoApp.DAL.DataBase.Initializer
{
    public interface IDbInitializer
    {
        void InitializeAsync();
    }
}
