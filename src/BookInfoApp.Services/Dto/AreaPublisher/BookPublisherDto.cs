using System;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Dto.AreaPublisher
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
