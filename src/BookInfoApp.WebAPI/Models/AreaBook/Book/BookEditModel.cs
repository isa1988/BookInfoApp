﻿using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaBook.AgeCategory;
using BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.BookAuthor;
using BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.BookGenre;
using BookInfoApp.WebAPI.Models.AreaBook.InputWork;
using BookInfoApp.WebAPI.Models.AreaPublisher.BookPublisher;

namespace BookInfoApp.WebAPI.Models.AreaBook.Book
{
    public class BookEditModel
    {
        public BookEditModel()
        {
            BookAuthors = new List<BookAuthorModel>();
            BookGenres = new List<BookGenreModel>();
            BookPublishers = new List<BookPublisherModel>();
            InputWorks = new List<InputWorkModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public int YearOfWriting { get; set; }

        public string Description { get; set; }

        public AgeCategoryModel AgeCategory { get; set; }
        public Guid AgeCategoryId { get; set; }

        public List<BookAuthorModel> BookAuthors { get; set; }
        public List<BookGenreModel> BookGenres { get; set; }
        public List<BookPublisherModel> BookPublishers { get; set; }

        public List<InputWorkModel> InputWorks { get; set; }
    }
}
