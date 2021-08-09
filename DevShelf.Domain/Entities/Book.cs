using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, int numberOfPages, string synopsis, string publisher, int categoryId)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            Synopsis = synopsis;
            Publisher = publisher;
            CategoryId = categoryId;
        }

        protected Book () {}

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfPages { get; private set; }
        public string Synopsis { get; private set; }
        public string Publisher { get; private set; }
        public int CategoryId { get; private set; }
    }
}
