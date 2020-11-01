using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;

namespace BookInfoApp.Services.Services.AreaBook.AreaAuthor
{
    public class AuthorService : GeneralService<Author, AuthorDto, Guid>, IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IMapper mapper, IAuthorRepository repository) : base(mapper, repository)
        {
            authorRepository = repository;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions{IsBook = true, IsBookAuthor = true};
        }

        protected override string CheckBeforeModification(AuthorDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Author entity)
        {
            return string.Empty;
        }


        public override async Task<List<AuthorDto>> GetAllDeteilsAsync()
        {
            var entities = await authorRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<AuthorDto>>(entities);
            return dtos;
        }

        public override async Task<List<AuthorDto>> GetPageAsync(int numPage, int pageSize)
        {
            var entities = await authorRepository.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            var dtos = mapper.Map<List<AuthorDto>>(entities);
            return dtos;
        }

        public override async Task<EntityOperationResult<AuthorDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await authorRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<AuthorDto>(entity);
                return EntityOperationResult<AuthorDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<AuthorDto>.Failure().AddError(ex.Message);
            }
        }

        public async Task<EntityOperationResult<Author>> EditAsync(AuthorDto editDto)
        {
            string errors = CheckBeforeModification(editDto, false);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<Author>.Failure().AddError(errors);
            }

            try
            {
                var value = await repositoryBaseId.GetByIdAsync(editDto.Id);
                value.FirstName = editDto.FirstName;
                value.MiddleName = editDto.MiddleName;
                value.SurName = editDto.SurName;
                repositoryBaseId.Update(value);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<Author>.Success(value);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<Author>.Failure().AddError(ex.Message);
            }
        }
    }
}
