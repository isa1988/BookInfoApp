using System;
using System.Threading.Tasks;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Contracts.AreaPublisher
{
    public interface ICoverTypeService : IGeneralService<CoverType, CoverTypeDto, Guid>
    {
        Task<EntityOperationResult<CoverType>> EditAsync(CoverTypeDto editDto);
    }
}
