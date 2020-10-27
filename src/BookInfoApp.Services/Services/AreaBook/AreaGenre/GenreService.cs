using System;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;

namespace BookInfoApp.Services.Services.AreaBook.AreaGenre
{
    public class GenreService : GeneralService<Genre, GenreDto, Guid>, IGenreService
    {
        public GenreService(IMapper mapper, IGenreRepository repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(GenreDto value, bool isNew = true)
        {
            return string.Empty;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions{IsBook = true, IsBookGenre = true};
        }

        protected override string CkeckBeforeDelete(Genre entity)
        {
            return string.Empty;
        }

        public async Task<EntityOperationResult<Genre>> EditAsync(GenreDto editDto)
        {
            string errors = CheckBeforeModification(editDto, false);
            if (!string.IsNullOrEmpty(errors))
            {
                return EntityOperationResult<Genre>.Failure().AddError(errors);
            }

            try
            {
                var value = await repositoryBaseId.GetByIdAsync(editDto.Id);
                value.Name = editDto.Name;
                repositoryBaseId.Update(value);
                await repositoryBaseId.SaveAsync();
                return EntityOperationResult<Genre>.Success(value);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<Genre>.Failure().AddError(ex.Message);
            }
        }
    }
}
