using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Contracts.AreaBook
{
    public interface IAgeCategoryService : IGeneralService<AgeCategory, AgeCategoryDto>
    {
    }
}
