using System;

namespace BookInfo_Services.Dto.AreaBook.AreaGenre
{
    public class BookGenreDto : IServiceDto
    {
        public GenreDto Genre { get; set; }
        public Guid GuidId { get; set; }
        public BookDto Book { get; set; }
        public Guid BookId { get; set; }
        public TypeOperationDto TypeOperation { get; set; }
    }
}
