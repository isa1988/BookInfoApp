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
    public class CoverTypeService : GeneralService<CoverType, CoverTypeDto, Guid>, ICoverTypeService
    {
        public CoverTypeService(IMapper mapper, ICoverTypeRepository repository) : base(mapper, repository)
        {
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
