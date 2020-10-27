using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Helper;
using BookInfoApp.Services.Contracts.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;

namespace BookInfoApp.Services.Services.AreaBook
{
    public class AgeCategoryService : GeneralService<AgeCategory, AgeCategoryDto, Guid>, IAgeCategoryService
    {
        public AgeCategoryService(IMapper mapper, IRepository<AgeCategory, Guid> repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(AgeCategoryDto value, bool isNew = true)
        {
            return string.Empty;
        }

        public override ResolveOptions GetOptionsForDeteils()
        {
            return new ResolveOptions {IsBook = true};
        }

        protected override string CkeckBeforeDelete(AgeCategory entity)
        {
            return string.Empty;
        }
    }
}
