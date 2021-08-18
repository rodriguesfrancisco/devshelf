using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class BookDescription : Notifiable<Notification>
    {
        public BookDescription(string value)
        {
            AddNotifications(new Contract<BookDescription>()
                .Requires()
                .IsGreaterOrEqualsThan(value.Length, 10, "BookDescription", "Book Description length must be greater than or equals 10")
                .IsLowerOrEqualsThan(value.Length, 1000, "BookDescription", "Book Description length must be lower than or equals 1000")
            );
            if (!IsValid) return;

            Value = value;
        }

        protected BookDescription() { }

        public string Value { get; protected set; }

    }
}
