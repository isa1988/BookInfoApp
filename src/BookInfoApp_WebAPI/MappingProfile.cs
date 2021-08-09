using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookInfo_Services.Dto;
using BookInfo_Services.Dto.AreaBook;
using BookInfo_Services.Dto.AreaBook.AreaAuthor;
using BookInfo_Services.Dto.AreaBook.AreaGenre;
using BookInfo_Services.Dto.AreaPublisher;
using BookInfo_WebAPI.Models.AreaBook.AgeCategory;
using BookInfo_WebAPI.Models.AreaBook.AreaAuthor.Author;
using BookInfo_WebAPI.Models.AreaBook.AreaAuthor.BookAuthor;
using BookInfo_WebAPI.Models.AreaBook.AreaGenre.BookGenre;
using BookInfo_WebAPI.Models.AreaBook.AreaGenre.Genre;
using BookInfo_WebAPI.Models.AreaBook.Book;
using BookInfo_WebAPI.Models.AreaBook.InputWork;
using BookInfo_WebAPI.Models.AreaPublisher.BookPublisher;
using BookInfo_WebAPI.Models.AreaPublisher.CoverType;
using BookInfo_WebAPI.Models.AreaPublisher.Publisher;
using BookInfo_WebAPI.Models.Helper;

namespace BookInfo_WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AgeCategoryMapping();
            AuthorMapping();
            BookAuthorMapping();
            BookGenreMapping();
            GenreMapping();
            BookMapping();
            InputWorkMapping();
            BookPublisherMapping();
            CoverTypeMapping();
            PublisherMapping();
            TypeOperationMapping();
        }

        private void AgeCategoryMapping()
        {
            CreateMap<AgeCategoryCreateModel, AgeCategoryDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<AgeCategoryEditModel, AgeCategoryDto>();
            CreateMap<AgeCategoryDto, AgeCategoryModel>();
            CreateMap<AgeCategoryModel, AgeCategoryDto>();
        }

        private void AuthorMapping()
        {
            CreateMap<AuthorCreateModel, AuthorDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<AuthorEditModel, AuthorDto>();
            CreateMap<AuthorDto, AuthorModel>();
            CreateMap<AuthorModel, AuthorDto>();
        }
        
        private void BookAuthorMapping()
        {
            CreateMap<BookAuthorDto, BookAuthorModel>();
            CreateMap<BookAuthorModel, BookAuthorDto>();
        }

        private void GenreMapping()
        {
            CreateMap<GenreCreateModel, GenreDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<GenreEditModel, GenreDto>();
            CreateMap<GenreDto, GenreModel>();
            CreateMap<GenreModel, GenreDto>();
        }
        private void BookGenreMapping()
        {
            CreateMap<BookGenreDto, BookGenreModel>();
            CreateMap<BookGenreModel, BookGenreDto>();
        }

        private void BookMapping()
        {
            CreateMap<BookCreateModel, BookDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<BookEditModel, BookDto>();
            CreateMap<BookDto, BookModel>();
            CreateMap<BookModel, BookDto>();
        }
        private void InputWorkMapping()
        {
            CreateMap<InputWorkDto, InputWorkModel>();
            CreateMap<InputWorkModel, InputWorkDto>();
        }

        private void BookPublisherMapping()
        {
            CreateMap<BookPublisheCreaterModel, BookPublisherDto>();
                //.ForMember(p => p.Id, n => n.Ignore());

            CreateMap<BookPublisherEditModel, BookPublisherDto>();
            CreateMap<BookPublisherDto, BookPublisherModel>();
            CreateMap<BookPublisherModel, BookPublisherDto>();
        }
        private void CoverTypeMapping()
        {
            CreateMap<CoverTypeModel, CoverTypeDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<CoverTypeEditModel, CoverTypeDto>();
            CreateMap<CoverTypeDto, CoverTypeModel>();
            CreateMap<CoverTypeModel, CoverTypeDto>();
        }
        private void PublisherMapping()
        {
            CreateMap<PublisherCreateModel, PublisherDto>()
                .ForMember(p => p.Id, n => n.Ignore());

            CreateMap<PublisherEditModel, PublisherDto>();
            CreateMap<PublisherDto, PublisherModel>();
            CreateMap<PublisherModel, PublisherDto>();
        }

        private void TypeOperationMapping()
        {
            CreateMap<TypeOperationDto, TypeOperationModel>();
            CreateMap<TypeOperationModel, TypeOperationDto>();
        }
        
    }
}
