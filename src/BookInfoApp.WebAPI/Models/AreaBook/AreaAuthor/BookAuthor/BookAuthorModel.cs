using System;
using BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.Author;
using BookInfoApp.WebAPI.Models.AreaBook.Book;
using BookInfoApp.WebAPI.Models.Helper;

namespace BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.BookAuthor
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
