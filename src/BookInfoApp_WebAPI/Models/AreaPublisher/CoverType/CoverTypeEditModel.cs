using System;
using System.Collections.Generic;
using BookInfo_WebAPI.Models.AreaPublisher.BookPublisher;

namespace BookInfo_WebAPI.Models.AreaPublisher.CoverType
{
    public class CoverTypeEditModel
    {
        public CoverTypeEditModel()
        {
            BookPublishers = new List<BookPublisherModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisherModel> BookPublishers { get; set; }
    }
}
