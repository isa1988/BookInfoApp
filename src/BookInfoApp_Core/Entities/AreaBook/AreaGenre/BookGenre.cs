using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo_Core.Entities.AreaBook.AreaGenre
{
    public class BookGenre : IEntity
    {
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
    }
}
