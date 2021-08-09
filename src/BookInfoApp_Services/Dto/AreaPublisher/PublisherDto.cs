using System;
using System.Collections.Generic;

namespace BookInfo_Services.Dto.AreaPublisher
{
    public class PublisherDto : IServiceDto<Guid>
    {
        public PublisherDto()
        {
            BookPublishers = new List<BookPublisherDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisherDto> BookPublishers { get; set; }
    }
}
