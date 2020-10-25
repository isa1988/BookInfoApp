using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Services.Contracts.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Services.AreaBook
{
    public class BookService : GeneralService<Book, BookDto, Guid>, IBookService
    {
        public BookService(IMapper mapper, IRepository<Book, Guid> repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(BookDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Book entity)
        {
            return string.Empty;
        }
    }
}
