using System;
using System.Collections.Generic;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Dto.AreaBook
{
    public class BookDto : IServiceDto<Guid>
    {
        public BookDto()
        {
            BookAuthors = new List<BookAuthorDto>();
            BookGenres = new List<BookGenreDto>();
            BookPublishers = new List<BookPublisherDto>();
            InputWorks = new List<InputWorkDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public int YearOfWriting { get; set; }

        public string Description { get; set; }

        public AgeCategoryDto AgeCategory { get; set; }
        public Guid AgeCategoryId { get; set; }

        public List<BookAuthorDto> BookAuthors { get; set; }
        public List<BookGenreDto> BookGenres { get; set; }
        public List<BookPublisherDto> BookPublishers { get; set; }

        public List<InputWorkDto> InputWorks { get; set; }
    }
}
