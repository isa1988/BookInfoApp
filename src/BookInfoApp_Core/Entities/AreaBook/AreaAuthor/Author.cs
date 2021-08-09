using System;
using System.Collections.Generic;

namespace BookInfo_Core.Entities.AreaBook.AreaAuthor
{
    public class Author : IEntity<Guid>
    {
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
