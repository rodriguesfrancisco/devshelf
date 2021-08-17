using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        protected BaseEntity () {}
        public int Id { get; private set; }
    }
}
