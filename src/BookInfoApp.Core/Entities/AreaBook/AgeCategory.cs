using System;
using System.Collections.Generic;

namespace BookInfoApp.Core.Entities.AreaBook
{
    public class AgeCategory : IEntity<Guid>
    {
        public AgeCategory()
        {
            Books = new List<Book>();
        }
        public Guid Id { get; set; }
        public int AgeBegin { get; set; }
        public int? AgeEnd { get; set; }

        public List<Book> Books { get; set; }
    }
}
