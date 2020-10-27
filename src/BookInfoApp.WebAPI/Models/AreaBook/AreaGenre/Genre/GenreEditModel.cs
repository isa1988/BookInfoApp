using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.BookGenre;

namespace BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.Genre
{
    public class GenreEditModel
    {
        public GenreEditModel()
        {
            BookGenras = new List<BookGenreModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<BookGenreModel> BookGenras { get; set; }
    }
}
