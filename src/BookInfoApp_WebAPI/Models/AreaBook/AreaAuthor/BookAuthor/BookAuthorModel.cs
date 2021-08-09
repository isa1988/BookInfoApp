using System;
using BookInfo_WebAPI.Models.AreaBook.AreaAuthor.Author;
using BookInfo_WebAPI.Models.AreaBook.Book;
using BookInfo_WebAPI.Models.Helper;

namespace BookInfo_WebAPI.Models.AreaBook.AreaAuthor.BookAuthor
{
    public class BookAuthorModel
    {
        public Guid BookId { get; set; }
        public BookModel Book { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorModel Author { get; set; }
        public bool IsMain { get; set; }
        public TypeOperationModel TypeOperation { get; set; }
    }
}
