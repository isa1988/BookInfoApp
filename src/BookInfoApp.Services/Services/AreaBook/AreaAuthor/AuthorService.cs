using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Services.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Services.Dto.AreaBook.AreaAuthor;

namespace BookInfoApp.Services.Services.AreaBook.AreaAuthor
{
    public class AuthorService : GeneralService<Author, AuthorDto, Guid>, IAuthorService
    {
        public AuthorService(IMapper mapper, IRepository<Author, Guid> repository) : base(mapper, repository)
        {

        }

        protected override string CheckBeforeModification(AuthorDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Author entity)
        {
            return string.Empty;
        }
    }
}
