using DevShelf.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, int numberOfPages, string description, string publisher, Category category)
        {
            Title = new Title(title);
            Author = new Author(author);
            NumberOfPages = numberOfPages;
            Description = new BookDescription(description);
            Publisher = new Publisher(publisher);
            Category = category;

            AddNotifications(
                Title,
                Author,
                Description,
                Publisher
            );
        }

        protected Book () {}

        public Title Title { get; private set; }
        public Author Author { get; private set; }
        public int NumberOfPages { get; private set; }
        public BookDescription Description { get; private set; }
        public Publisher Publisher { get; private set; }
        public Category Category { get; private set; }
    }
}
