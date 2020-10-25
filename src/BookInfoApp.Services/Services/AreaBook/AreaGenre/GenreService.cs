using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Services.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;

namespace BookInfoApp.Services.Services.AreaBook.AreaGenre
{
    public class GenreService : GeneralService<Genre, GenreDto, Guid>, IGenreService
    {
        public GenreService(IMapper mapper, IRepository<Genre, Guid> repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(GenreDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Genre entity)
        {
            return string.Empty;
        }
    }
}
