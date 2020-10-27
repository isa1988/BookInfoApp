using System;
using BookInfoApp.WebAPI.Models.AreaBook.Book;
using BookInfoApp.WebAPI.Models.AreaPublisher.CoverType;
using BookInfoApp.WebAPI.Models.AreaPublisher.Publisher;

namespace BookInfoApp.WebAPI.Models.AreaPublisher.BookPublisher
{
    public class BookPublisherModel
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
