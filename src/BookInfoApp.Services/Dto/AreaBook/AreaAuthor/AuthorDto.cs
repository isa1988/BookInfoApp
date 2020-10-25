using System;
using System.Collections.Generic;

namespace BookInfoApp.Services.Dto.AreaBook.AreaAuthor
{
    public class AuthorDto : IServiceDto<Guid>
    {
        public AuthorDto()
        {
            BookAuthors = new List<BookAuthorDto>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public List<BookAuthorDto> BookAuthors { get; set; }
    }
}
