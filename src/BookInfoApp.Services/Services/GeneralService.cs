using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts;
using BookInfoApp.Services.Dto;

namespace BookInfoApp.Services.Services
{
    public abstract class GeneralService<TEntity, TDto> : IGeneralService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class, IServiceDto
    {
        public GeneralService(
            IMapper mapper,
            IRepository<TEntity> repository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            repositoryBase = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        protected readonly IMapper mapper;
        protected readonly IRepository<TEntity> repositoryBase;

        protected abstract string CheckBeforeModification(TDto value, bool isNew = true);
        public virtual async Task<EntityOperationResult<TEntity>> CreateAsync(TDto createDto)
        {
            string errors = CheckBeforeModification(createDto);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<TEntity>.Failure().AddError(errors);
            }

            try
            {
                TEntity value = mapper.Map<TEntity>(createDto);
                var entity = await repositoryBase.CreateAsync(value);
                await repositoryBase.SaveAsync();

                return EntityOperationResult<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<TEntity>.Failure().AddError(ex.Message);
            }
        }

        public abstract ResolveOptions GetOptionsForDeteils();
        public virtual async Task<List<TDto>> GetAllAsync()
        {
            var dtoList = await repositoryBase.GetAllAsync();
            return mapper.Map<List<TDto>>(dtoList);
        }

        public virtual async Task<List<TDto>> GetAllDeteilsAsync()
        {
            var dtoList = await repositoryBase.GetAllAsync(GetOptionsForDeteils());
            return mapper.Map<List<TDto>>(dtoList);
        }

        public virtual async Task<List<TDto>> GetPageAsync(int numPage, int pageSize)
        {
            var dtoList = await repositoryBase.GetPageAsync(numPage, pageSize);
            return mapper.Map<List<TDto>>(dtoList);
        }

        public virtual async Task<List<TDto>> GetPageDeteilsAsync(int numPage, int pageSize)
        {
            var dtoList = await repositoryBase.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            return mapper.Map<List<TDto>>(dtoList);
        }
    }

    public abstract class GeneralService<TEntity, TDto, TId> : GeneralService<TEntity, TDto>, IGeneralService<TEntity, TDto, TId>
        where TEntity : class, IEntity<TId>
        where TDto : class, IServiceDto<TId>
        where TId : IEquatable<TId>
    {
        public GeneralService(
            IMapper mapper,
            IRepository<TEntity, TId> repository) 
        : base(mapper, repository)
        {
            repositoryBaseId = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        protected readonly IRepository<TEntity, TId> repositoryBaseId;

        public virtual async Task<EntityOperationResult<TDto>> GetByIdAsync(TId id)
        {
            try
            {
                TEntity entity = await repositoryBaseId.GetByIdAsync(id);
                var dto = mapper.Map<TDto>(entity);
                return EntityOperationResult<TDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<TDto>.Failure().AddError(ex.Message);
            }
        }

        public virtual async Task<EntityOperationResult<TDto>> GetByIdDeteilsAsync(TId id)
        {
            try
            {
                TEntity entity = await repositoryBaseId.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<TDto>(entity);
                return EntityOperationResult<TDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<TDto>.Failure().AddError(ex.Message);
            }
        }

        public virtual async Task<EntityOperationResult<TEntity>> DeleteItemAsync(TId id)
        {
            try
            {
                TEntity entity = await repositoryBaseId.GetByIdAsync(id);

                string error = CkeckBeforeDelete(entity);
                if (!string.IsNullOrEmpty(error))
                {
                    return EntityOperationResult<TEntity>.Failure().AddError(error);
                }

                repositoryBaseId.Delete(entity);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<TEntity>.Failure().AddError(ex.Message);
            }
        }

        protected abstract string CkeckBeforeDelete(TEntity entity);
    }
}
