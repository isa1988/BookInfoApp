using System;
using BookInfo_WebAPI.Models.AreaBook.Book;
using BookInfo_WebAPI.Models.AreaPublisher.CoverType;
using BookInfo_WebAPI.Models.AreaPublisher.Publisher;

namespace BookInfo_WebAPI.Models.AreaPublisher.BookPublisher
{
    public class BookPublisherEditModel
    {
        public PublisherModel Publisher { get; set; }
        public Guid PublisherId { get; set; }

        public BookModel Book { get; set; }
        public Guid BookId { get; set; }

        public CoverTypeModel CoverType { get; set; }
        public Guid CoverTypeId { get; set; }

        public int YearOfPublishing { get; set; }
    }
}
