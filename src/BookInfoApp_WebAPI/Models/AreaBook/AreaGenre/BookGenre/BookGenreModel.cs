using System;
using BookInfo_WebAPI.Models.AreaBook.AreaGenre.Genre;
using BookInfo_WebAPI.Models.AreaBook.Book;
using BookInfo_WebAPI.Models.Helper;

namespace BookInfo_WebAPI.Models.AreaBook.AreaGenre.BookGenre
{
    public class BookGenreModel
    {
        public GenreModel Genre { get; set; }
        public Guid GuidId { get; set; }
        public BookModel Book { get; set; }
        public Guid BookId { get; set; }
        public TypeOperationModel TypeOperation { get; set; }
    }
}
