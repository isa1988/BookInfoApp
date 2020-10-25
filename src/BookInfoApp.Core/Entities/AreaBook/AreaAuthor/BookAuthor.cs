using System;

namespace BookInfoApp.Core.Entities.AreaBook.AreaAuthor
{
    public class BookAuthor : IEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public bool IsMain { get; set; }
    }
}
