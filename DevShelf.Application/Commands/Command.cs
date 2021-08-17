using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands
{
    public abstract class Command<T> : Notifiable<Notification>, IRequest<T>
    {
        public abstract void Validate();
    }
}
