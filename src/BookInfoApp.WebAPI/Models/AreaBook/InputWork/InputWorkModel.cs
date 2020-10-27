﻿using System;
using BookInfoApp.WebAPI.Models.AreaBook.Book;
using BookInfoApp.WebAPI.Models.Helper;

namespace BookInfoApp.WebAPI.Models.AreaBook.InputWork
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
