using System;
using System.Threading.Tasks;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Contracts.AreaPublisher
{
    public interface IPublisherService : IGeneralService<Publisher, PublisherDto, Guid>
    {
        Task<EntityOperationResult<Publisher>> EditAsync(PublisherDto editDto);
    }
}
