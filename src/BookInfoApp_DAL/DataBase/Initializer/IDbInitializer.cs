using System.Threading.Tasks;

namespace BookInfo_DAL.DataBase.Initializer
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
    }
}
