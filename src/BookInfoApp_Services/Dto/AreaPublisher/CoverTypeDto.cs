using System;
using System.Collections.Generic;

namespace BookInfo_Services.Dto.AreaPublisher
{
    public class CoverTypeDto : IServiceDto<Guid>
    {
        public CoverTypeDto()
        {
            BookPublishers = new List<BookPublisherDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisherDto> BookPublishers { get; set; }
    }
}
