using System;
using System.Threading.Tasks;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Services.Dto.AreaPublisher;

namespace BookInfo_Services.Contracts.AreaPublisher
{
    public interface IPublisherService : IGeneralService<Publisher, PublisherDto, Guid>
    {
        Task<EntityOperationResult<Publisher>> EditAsync(PublisherDto editDto);
    }
}
