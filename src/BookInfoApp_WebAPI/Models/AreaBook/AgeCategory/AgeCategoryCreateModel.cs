using System;
using System.Collections.Generic;
using BookInfo_WebAPI.Models.AreaBook.Book;

namespace BookInfo_WebAPI.Models.AreaBook.AgeCategory
{
    public class AgeCategoryCreateModel
    {
        public AgeCategoryCreateModel()
        {
            Books = new List<BookModel>();
        }
        public int AgeBegin { get; set; }
        public int? AgeEnd { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
