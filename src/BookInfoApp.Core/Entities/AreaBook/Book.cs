using System;
using System.Collections.Generic;
using System.Text;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaPublisher;

namespace BookInfoApp.Core.Entities.AreaBook
{
    public class Book : IEntity<Guid>
    {
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
            BookGenras = new List<BookGenra>();
            BookPublishers = new List<BookPublisher>();
            InputWorks = new List<InputWork>();
            BookForConnectInputWorks = new List<InputWork>();
    }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public int YearOfWriting { get; set; }

        public string Description { get; set; }

        public AgeCategory AgeCategory { get; set; }
        public Guid AgeCategoryId { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookGenra> BookGenras { get; set; }
        public List<BookPublisher> BookPublishers { get; set; }

        public List<InputWork> InputWorks { get; set; }
        public List<InputWork> BookForConnectInputWorks { get; set; }
    }
}
