using System;
using System.Threading.Tasks;
using BookInfo_Core.Entities.AreaBook;
using BookInfo_Services.Dto.AreaBook;

namespace BookInfo_Services.Contracts.AreaBook
{
    public interface IAgeCategoryService : IGeneralService<AgeCategory, AgeCategoryDto, Guid>
    {
        Task<EntityOperationResult<AgeCategory>> EditAsync(AgeCategoryDto editDto);
    }
}
