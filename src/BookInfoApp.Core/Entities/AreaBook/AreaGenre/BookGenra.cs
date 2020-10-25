using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfoApp.Core.Entities.AreaBook.AreaGenre
{
    public class BookGenra : IEntity
    {
        public Genre Genre { get; set; }
        public Guid GuidId { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
    }
}
