using System;

namespace BookInfoApp.Services.Dto.AreaBook.AreaAuthor
{
    public class BookAuthorDto : IServiceDto
    {
        public Guid BookId { get; set; }
        public BookDto Book { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorDto Author { get; set; }
        public bool IsMain { get; set; }
        public TypeOperationDto TypeOperation { get; set; }
    }
}
