using System;
using System.Collections.Generic;
using BookInfoApp.WebAPI.Models.AreaPublisher.BookPublisher;

namespace BookInfoApp.WebAPI.Models.AreaPublisher.Publisher
{
    public class PublisherEditModel
    {
        public PublisherEditModel()
        {
            BookPublishers = new List<BookPublisherModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisherModel> BookPublishers { get; set; }
    }
}
