using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfoApp.Core.Entities.AreaPublisher
{
    public class CoverType : IEntity<Guid>
    {
        public CoverType()
        {
            BookPublishers = new List<BookPublisher>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisher> BookPublishers { get; set; }
    }
}
