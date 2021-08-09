using System;
using BookInfo_WebAPI.Models.AreaBook.Book;
using BookInfo_WebAPI.Models.Helper;

namespace BookInfo_WebAPI.Models.AreaBook.InputWork
{
    public class InputWorkModel
    {
        public BookModel Book { get; set; }
        public Guid BookId { get; set; }

        public BookModel Work { get; set; }
        public Guid WorkId { get; set; }
        public TypeOperationModel TypeOperation { get; set; }
    }
}
