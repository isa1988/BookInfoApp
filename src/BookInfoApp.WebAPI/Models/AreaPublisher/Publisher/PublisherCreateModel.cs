using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaPublisher.BookPublisher;

namespace BookInfoApp.WebAPI.Models.AreaPublisher.Publisher
{
    public class PublisherCreateModel
    {
        public PublisherCreateModel()
        {
            BookPublishers = new List<BookPublisherModel>();
        }
        public string Name { get; set; }
        public List<BookPublisherModel> BookPublishers { get; set; }
    }
}
