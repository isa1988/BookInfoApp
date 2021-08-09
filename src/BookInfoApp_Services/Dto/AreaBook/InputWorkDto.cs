using System;

namespace BookInfo_Services.Dto.AreaBook
{
    public class InputWorkDto : IServiceDto
    {
        public BookDto Book { get; set; }
        public Guid BookId { get; set; }

        public BookDto Work { get; set; }
        public Guid WorkId { get; set; }
        public TypeOperationDto TypeOperation { get; set; }
    }
}
