using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateUser
{
    public class CreateUserCommand : Command<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public override void Validate()
        {
            AddNotifications(new Contract<CreateUserCommand>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Name is required")
                .IsNotNullOrEmpty(Email, "Email", "Email is required")
                .IsNotNullOrEmpty(Password, "Password", "Password is required")
                .IsGreaterOrEqualsThan(Password.Length, 6, "Password", "Password must have at least 6 characters")
            );
        }
    }
}
