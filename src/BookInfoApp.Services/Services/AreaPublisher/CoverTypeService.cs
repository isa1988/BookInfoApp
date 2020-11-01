using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Services.AreaPublisher
{
    public class CoverTypeService : GeneralService<CoverType, CoverTypeDto, Guid>, ICoverTypeService
    {
        private readonly ICoverTypeRepository coverTypeRepository;
        public CoverTypeService(IMapper mapper, ICoverTypeRepository repository) : base(mapper, repository)
        {
            coverTypeRepository = repository;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions
            {
                IsBookPublisher = true,
                IsPublisher = true,
                IsBook = true,
            };
        }

        protected override string CheckBeforeModification(CoverTypeDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(CoverType entity)
        {
            return string.Empty;
        }

        public override async Task<List<CoverTypeDto>> GetAllDeteilsAsync()
        {
            var entities = await coverTypeRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<CoverTypeDto>>(entities);
            return dtos;
        }

        public override async Task<EntityOperationResult<CoverTypeDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await coverTypeRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<CoverTypeDto>(entity);
                return EntityOperationResult<CoverTypeDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<CoverTypeDto>.Failure().AddError(ex.Message);
            }
        }
        
        public override async Task<List<CoverTypeDto>> GetPageAsync(int numPage, int pageSize)
        {
            var entities = await coverTypeRepository.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            var dtos = mapper.Map<List<CoverTypeDto>>(entities);
            return dtos;
        }

        public async Task<EntityOperationResult<CoverType>> EditAsync(CoverTypeDto editDto)
        {
            string errors = CheckBeforeModification(editDto, false);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<CoverType>.Failure().AddError(errors);
            }

            try
            {
                var value = await repositoryBaseId.GetByIdAsync(editDto.Id);
                value.Name = editDto.Name;
                repositoryBaseId.Update(value);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<CoverType>.Success(value);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<CoverType>.Failure().AddError(ex.Message);
            }
        }
    }
}
