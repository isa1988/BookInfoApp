using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IBookRepository bookRepository;
        public BookService(IMapper mapper, IBookRepository repository) : base(mapper, repository)
        {
            bookRepository = repository;
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

        public override async Task<List<BookDto>> GetAllDeteilsAsync()
        {
            var entities = await bookRepository.GetAllAsync(GetOptionsForDeteils());
            var dtos = mapper.Map<List<BookDto>>(entities);
            return dtos;
        }

        public override async Task<List<BookDto>> GetPageAsync(int numPage, int pageSize)
        {
            var entities = await bookRepository.GetPageAsync(numPage, pageSize, GetOptionsForDeteils());
            var dtos = mapper.Map<List<BookDto>>(entities);
            return dtos;
        }
        
        public override async Task<EntityOperationResult<BookDto>> GetByIdDeteilsAsync(Guid id)
        {
            try
            {
                var entity = await bookRepository.GetByIdAsync(id, GetOptionsForDeteils());
                var dto = mapper.Map<BookDto>(entity);
                return EntityOperationResult<BookDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return EntityOperationResult<BookDto>.Failure().AddError(ex.Message);
            }
        }

    }
}
