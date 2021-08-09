using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookInfo_Core.Contracts.AreaBook.AreaGenre;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Core.Helper;
using BookInfo_Services.Contracts.AreaBook.AreaGenre;
using BookInfo_Services.Dto.AreaBook.AreaGenre;

namespace BookInfo_Services.Services.AreaBook.AreaGenre
{
    public class GenreService : GeneralService<Genre, GenreDto, Guid>, IGenreService
    {
        private readonly IGenreRepository genreRepository;
        public GenreService(IMapper mapper, IGenreRepository repository) : base(mapper, repository)
        {
            genreRepository = repository;
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

        public override async Task<List<GenreDto>> GetAllDeteilsAsync()
        {
            var entities = await genreRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<GenreDto>>(entities);
            return dtos;
        }

        public override async Task<List<GenreDto>> GetPageAsync(int numPage, int pageSize)
        {
            var entities = await genreRepository.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            var dtos = mapper.Map<List<GenreDto>>(entities);
            return dtos;
        }

        public override async Task<EntityOperationResult<GenreDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await genreRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<GenreDto>(entity);
                return EntityOperationResult<GenreDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<GenreDto>.Failure().AddError(ex.Message);
            }
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
