using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class Publisher : Notifiable<Notification>
    {
        public Publisher(string value)
        {
            AddNotifications(new Contract<Publisher>()
                .Requires()
                .IsGreaterOrEqualsThan(value.Length, 2, "Publisher", "Publisher length must be greater than or equals 2")
                .IsLowerOrEqualsThan(value.Length, 100, "Publisher", "Publisher length must be lower than or equals 100")
            );
            if (!IsValid) return;

            Value = value;
        }

        protected Publisher() { }

        public string Value { get; protected set; }
    }
}
