using System;
using System.Threading.Tasks;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Services.Dto.AreaPublisher;

namespace BookInfo_Services.Contracts.AreaPublisher
{
    public interface ICoverTypeService : IGeneralService<CoverType, CoverTypeDto, Guid>
    {
        Task<EntityOperationResult<CoverType>> EditAsync(CoverTypeDto editDto);
    }
}
