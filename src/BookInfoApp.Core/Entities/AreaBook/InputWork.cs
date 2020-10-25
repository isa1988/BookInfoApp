using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfoApp.Core.Entities.AreaBook
{
    public class InputWork : IEntity
    {
        public Book Book { get; set; }
        public Guid BookId { get; set; }

        public Book Work { get; set; }
        public Guid WorkId { get; set; }
    }
}
