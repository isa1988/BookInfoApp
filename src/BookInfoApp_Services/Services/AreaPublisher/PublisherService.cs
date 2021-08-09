using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookInfo_Core.Contracts.AreaPublisher;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Core.Helper;
using BookInfo_Services.Contracts.AreaPublisher;
using BookInfo_Services.Dto.AreaPublisher;

namespace BookInfo_Services.Services.AreaPublisher
{
    public class PublisherService : GeneralService<Publisher, PublisherDto, Guid>, IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherService(IMapper mapper, IPublisherRepository repository) : base(mapper, repository)
        {
            publisherRepository = repository;
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

        public override async Task<List<PublisherDto>> GetAllDeteilsAsync()
        {
            var entities = await publisherRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<PublisherDto>>(entities);
            return dtos;
        }

        public override async Task<EntityOperationResult<PublisherDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await publisherRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<PublisherDto>(entity);
                return EntityOperationResult<PublisherDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<PublisherDto>.Failure().AddError(ex.Message);
            }
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
