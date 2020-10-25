using System;
using System.Collections.Generic;

namespace BookInfoApp.Services.Dto.AreaBook
{
    public class AgeCategoryDto : IServiceDto<Guid>
    {
        public AgeCategoryDto()
        {
            Books = new List<BookDto>();
        }
        public Guid Id { get; set; }
        public int AgeBegin { get; set; }
        public int? AgeEnd { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
