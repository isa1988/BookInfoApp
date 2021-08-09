using AutoMapper;
using BookInfo_Core.Entities.AreaBook.AreaAuthor;
using System;
using BookInfo_Core.Entities.AreaBook;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_Services.Dto.AreaBook;
using BookInfo_Services.Dto.AreaBook.AreaAuthor;
using BookInfo_Services.Dto.AreaBook.AreaGenre;
using BookInfo_Services.Dto.AreaPublisher;

namespace BookInfo_Services
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
