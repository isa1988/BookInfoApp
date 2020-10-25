using System;
using System.Collections.Generic;
using System.Text;
using BookInfoApp.Core.Entities.AreaBook;

namespace BookInfoApp.Core.Entities.AreaPublisher
{
    public class BookPublisher : IEntity
    {
        public Publisher Publisher { get; set; }
        public Guid PublisherId { get; set; }
        
        public Book Book { get; set; }
        public Guid BookId { get; set; }
        
        public CoverType CoverType { get; set; }
        public Guid CoverTypeId { get; set; }
        
        public int YearOfPublishing { get; set; }
    }
}
