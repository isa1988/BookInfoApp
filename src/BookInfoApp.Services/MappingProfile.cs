using AutoMapper;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using System;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Services.Dto.AreaBook;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AuthorMapper();
            GenreMapper();
            PublisherMapper();
            BookMapper();
        }

        private void AuthorMapper()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<BookAuthor, BookAuthorDto>();
            CreateMap<BookAuthorDto, BookAuthor>();
        }
        private void GenreMapper()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<BookGenre, BookGenreDto>();
            CreateMap<BookGenreDto, BookGenre>();
        }
        private void PublisherMapper()
        {
            CreateMap<Publisher, PublisherDto>();
            CreateMap<PublisherDto, Publisher>();

            CreateMap<CoverType, CoverTypeDto>();
            CreateMap<CoverTypeDto, CoverType>();

            CreateMap<BookPublisher, BookPublisherDto>();
            CreateMap<BookPublisherDto, BookPublisher>();
        }

        private void BookMapper()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<AgeCategory, AgeCategoryDto>();
            CreateMap<AgeCategoryDto, AgeCategory>();

            CreateMap<InputWork, InputWorkDto>();
            CreateMap<InputWorkDto, InputWork>();
        }

    }
}
