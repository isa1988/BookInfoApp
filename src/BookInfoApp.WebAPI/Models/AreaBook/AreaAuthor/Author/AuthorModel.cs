﻿using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.BookAuthor;

namespace BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.Author
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            BookAuthors = new List<BookAuthorModel>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public List<BookAuthorModel> BookAuthors { get; set; }
    }
}
