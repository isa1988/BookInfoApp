using System;
using System.Collections.Generic;
using BookInfo_WebAPI.Models.AreaPublisher.BookPublisher;

namespace BookInfo_WebAPI.Models.AreaPublisher.CoverType
{
    public class CoverTypeCreateModel
    {
        public CoverTypeCreateModel()
        {
            BookPublishers = new List<BookPublisherModel>();
        }
        public string Name { get; set; }
        public List<BookPublisherModel> BookPublishers { get; set; }
    }
}
