using System;
using AutoMapper;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Services.AreaBook
{
    public class BookService : GeneralService<Book, BookDto, Guid>, IBookService
    {
        public BookService(IMapper mapper, IBookRepository repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(BookDto value, bool isNew = true)
        {
            return string.Empty;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions
            {
                IsAgeCategory = true,
                IsBookPublisher = true,
                IsPublisher = true,
                IsCoverType = true,
                IsBookAuthor = true,
                IsAuthor = true,
                IsBookGenre = true,
                IsGenre = true,
                IsInputWork = true,
                IsBook = true
            };
        }

        protected override string CkeckBeforeDelete(Book entity)
        {
            return string.Empty;
        }
    }
}
