using System;
using System.Collections.Generic;

namespace BookInfoApp.Core.Entities.AreaBook.AreaGenre
{
    public class Genre : IEntity<Guid>
    {
        public Genre()
        {
            BookGenras = new List<BookGenra>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<BookGenra> BookGenras { get; set; }
    }
}
