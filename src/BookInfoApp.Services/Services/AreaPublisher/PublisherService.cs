using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;

namespace BookInfoApp.Services.Services.AreaPublisher
{
    public class PublisherService : GeneralService<Publisher, PublisherDto, Guid>
    {
        public PublisherService(IMapper mapper, IRepository<Publisher, Guid> repository) : base(mapper, repository)
        {
        }

        protected override string CheckBeforeModification(PublisherDto value, bool isNew = true)
        {
            return string.Empty;
        }

        protected override string CkeckBeforeDelete(Publisher entity)
        {
            return string.Empty;
        }
    }
}
