using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaBook.Book;

namespace BookInfoApp.WebAPI.Models.AreaBook.AgeCategory
{
    public class AgeCategoryEditModel
    {
        public AgeCategoryEditModel()
        {
            Books = new List<BookModel>();
        }
        public Guid Id { get; set; }
        public int AgeBegin { get; set; }
        public int? AgeEnd { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
