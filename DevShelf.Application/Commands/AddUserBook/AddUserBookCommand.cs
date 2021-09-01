using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.AddUserBook
{
    public class AddUserBookCommand : Command<Unit>
    {
        public string UserEmail { get; set; }
        public int BookId { get; set; }
        public override void Validate()
        {
            AddNotifications(new Contract<AddUserBookCommand>()
                .Requires()
                .IsNotNull(UserEmail, "UserEmail", "User Email should not be empty")
            );
        }
    }
}
