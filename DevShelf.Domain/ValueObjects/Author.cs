using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class Author : Notifiable<Notification>
    {
        public Author(string name)
        {
            AddNotifications(new Contract<Author>()
                .Requires()
                .IsGreaterOrEqualsThan(name.Length, 2, "AuthorName", "Author Name length must be greather than or equals 2")
                .IsLowerOrEqualsThan(name.Length, 120, "AuthorName", "Author Name length must be lower than or equals 120")
            );
            if (!IsValid) return;

            Name = name;
        }

        protected Author() { }

        public string Name { get; protected set; }

    }
}
