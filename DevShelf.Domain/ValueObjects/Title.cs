using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class Title : Notifiable<Notification>
    {
        public Title(string value)
        {
            AddNotifications(new Contract<Title>()
                .Requires()
                .IsGreaterOrEqualsThan(value.Length, 3, "Title", "Title length must be greater than or equals 3")
                .IsLowerOrEqualsThan(value.Length, 150, "Title", "Title length must be lower than or equals 150")
            );
            if (!IsValid) return;

            Value = value;
        }

        public string Value { get; private set; }
    }
}
