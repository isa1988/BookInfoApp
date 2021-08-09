using System;
using System.Collections.Generic;
using BookInfo_WebAPI.Models.AreaBook.AreaGenre.BookGenre;

namespace BookInfo_WebAPI.Models.AreaBook.AreaGenre.Genre
{
    public class GenreCreateModel
    {
        public GenreCreateModel()
        {
            BookGenras = new List<BookGenreModel>();
        }
        public string Name { get; set; }

        public List<BookGenreModel> BookGenras { get; set; }
    }
}
