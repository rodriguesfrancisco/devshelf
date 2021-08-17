using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateBook
{
    public class CreateBookCommand : Command<Unit>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<CreateBookCommand>()
                .Requires()
                .IsNotNullOrEmpty(Title, "Title", "Title cannot be null or empty")
                .IsNotNullOrEmpty(Author, "Author", "Author cannot be null or empty")
                .IsGreaterThan(NumberOfPages, 0, "NumberOfPages", "Number of Pages must be greather than 0")
                .IsNotNullOrEmpty(Description, "Description", "Description cannot be null or empty")
            );
        }
    }
}
