using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class UserName : Notifiable<Notification>
    {
        public UserName(string value)
        {
            AddNotifications(new Contract<UserName>()
                .Requires()
                .IsNotNullOrEmpty(value, "UserNameValue", "UserNameValue is required")
                .IsGreaterOrEqualsThan(value.Length, 3, "UserNameValue", "UserNameValue length should be greater than or equals 3")
                .IsLowerOrEqualsThan(value.Length, 240, "UserNameValue", "UserNameValue length should be lower than or equals 240")
            );
            if (!IsValid) return;

            Value = value;
        }

        public string Value { get; private set; }
    }
}
