using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo_WebAPI.Models.AreaBook.AreaAuthor.Author;

namespace BookInfo_WebAPI.Models
{
    public class PageListModel
    {
        public PageListModel()
        {
            Authors = new List<AuthorModel>();
        }
        public List<AuthorModel> Authors { get; set; }
    }
}
