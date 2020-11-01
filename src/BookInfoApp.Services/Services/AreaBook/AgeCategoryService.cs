using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Services.AreaBook
{
    public class AgeCategoryService : GeneralService<AgeCategory, AgeCategoryDto, Guid>, IAgeCategoryService
    {
        private readonly IAgeCategoryRepository ageCategoryRepository;
        public AgeCategoryService(IMapper mapper, IAgeCategoryRepository repository) : base(mapper, repository)
        {
            ageCategoryRepository = repository;
        }

        protected override string CheckBeforeModification(AgeCategoryDto value, bool isNew = true)
        {
            return string.Empty;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions {IsBook = true};
        }

        protected override string CkeckBeforeDelete(AgeCategory entity)
        {
            return string.Empty;
        }

        public override async Task<List<AgeCategoryDto>> GetAllDeteilsAsync()
        {
            var entities = await ageCategoryRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<AgeCategoryDto>>(entities);
            return dtos;
        }

        public override async Task<List<AgeCategoryDto>> GetPageAsync(int numPage, int pageSize)
        {
            var entities = await ageCategoryRepository.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            var dtos = mapper.Map<List<AgeCategoryDto>>(entities);
            return dtos;
        }

        public override async Task<EntityOperationResult<AgeCategoryDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await ageCategoryRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<AgeCategoryDto>(entity);
                return EntityOperationResult<AgeCategoryDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<AgeCategoryDto>.Failure().AddError(ex.Message);
            }
        }

        public async Task<EntityOperationResult<AgeCategory>> EditAsync(AgeCategoryDto editDto)
        {
            string errors = CheckBeforeModification(editDto, false);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<AgeCategory>.Failure().AddError(errors);
            }

            try
            {
                var value = await repositoryBaseId.GetByIdAsync(editDto.Id);
                value.AgeBegin = editDto.AgeBegin;
                value.AgeEnd = editDto.AgeEnd;
                repositoryBaseId.Update(value);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<AgeCategory>.Success(value);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<AgeCategory>.Failure().AddError(ex.Message);
            }
        }
    }
}
