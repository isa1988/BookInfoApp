using System;
using BookInfo_Services.Dto.AreaBook;

namespace BookInfo_Services.Dto.AreaPublisher
{
    public class BookPublisherDto : IServiceDto
    {
        public PublisherDto Publisher { get; set; }
        public Guid PublisherId { get; set; }

        public BookDto Book { get; set; }
        public Guid BookId { get; set; }

        public CoverTypeDto CoverType { get; set; }
        public Guid CoverTypeId { get; set; }

        public int YearOfPublishing { get; set; }
    }
}
