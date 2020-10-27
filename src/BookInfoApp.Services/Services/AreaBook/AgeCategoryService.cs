using System;
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
        public AgeCategoryService(IMapper mapper, IAgeCategoryRepository repository) : base(mapper, repository)
        {
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
