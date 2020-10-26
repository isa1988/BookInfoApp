﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Services.Contracts.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Services.AreaPublisher
{
    public class CoverTypeService : GeneralService<CoverType, CoverTypeDto, Guid>, ICoverTypeService
    {
        public CoverTypeService(IMapper mapper, IRepository<CoverType, Guid> repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(CoverTypeDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(CoverType entity)
        {
            return string.Empty;
        }
    }
}