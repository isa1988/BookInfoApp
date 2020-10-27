using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Services.Dto;
using BookInfoApp.Services.Dto.AreaBook;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaGenre;
using BookInfoApp.Services.Dto.AreaPublisher;
using BookInfoApp.WebAPI.Models.AreaBook.AgeCategory;
using BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.Author;
using BookInfoApp.WebAPI.Models.AreaBook.AreaAuthor.BookAuthor;
using BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.BookGenre;
using BookInfoApp.WebAPI.Models.AreaBook.AreaGenre.Genre;
using BookInfoApp.WebAPI.Models.AreaBook.Book;
using BookInfoApp.WebAPI.Models.AreaBook.InputWork;
using BookInfoApp.WebAPI.Models.AreaPublisher.BookPublisher;
using BookInfoApp.WebAPI.Models.AreaPublisher.CoverType;
using BookInfoApp.WebAPI.Models.AreaPublisher.Publisher;
using BookInfoApp.WebAPI.Models.Helper;

namespace BookInfoApp.WebAPI
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
