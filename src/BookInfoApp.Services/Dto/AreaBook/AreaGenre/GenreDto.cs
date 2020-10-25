using System;
using System.Collections.Generic;

namespace BookInfoApp.Services.Dto.AreaBook.AreaGenre
{
    public class GenreDto : IServiceDto<Guid>
    {
        public GenreDto()
        {
            BookGenras = new List<BookGenreDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<BookGenreDto> BookGenras { get; set; }
    }
}
