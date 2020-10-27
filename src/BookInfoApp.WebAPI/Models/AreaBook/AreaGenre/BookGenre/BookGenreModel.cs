using System;
using BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.Genre;
using BookInfoApp.WebAPI.Models.AreaBook.Book;
using BookInfoApp.WebAPI.Models.Helper;

namespace BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.BookGenre
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
