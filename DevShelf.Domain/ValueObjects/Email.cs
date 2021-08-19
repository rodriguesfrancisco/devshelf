using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.ValueObjects
{
    public class Email : Notifiable<Notification>
    {
        public Email(string value)
        {
            AddNotifications(new Contract<Email>()
                .Requires()
                .IsNotNullOrEmpty(value, "Email", "E-mail is required")
                .IsEmail(value, "Email", "Invalid e-mail")
            );
            if (!IsValid) return;

            Value = value;
        }

        public string Value { get; private set; }
    }
}
