using System;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Services.AreaPublisher
{
    public class PublisherService : GeneralService<Publisher, PublisherDto, Guid>, IPublisherService
    {
        public PublisherService(IMapper mapper, IPublisherRepository repository) : base(mapper, repository)
        {
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions
            {
                IsBookPublisher = true,
                IsCoverType = true,
                IsBook = true,
            };
        }

        protected override string CheckBeforeModification(PublisherDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Publisher entity)
        {
            return string.Empty;
        }

        public async Task<EntityOperationResult<Publisher>> EditAsync(PublisherDto editDto)
        {
            string errors = CheckBeforeModification(editDto, false);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<Publisher>.Failure().AddError(errors);
            }

            try
            {
                var value = await repositoryBaseId.GetByIdAsync(editDto.Id);
                value.Name = editDto.Name;
                repositoryBaseId.Update(value);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<Publisher>.Success(value);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<Publisher>.Failure().AddError(ex.Message);
            }
        }
    }
}
