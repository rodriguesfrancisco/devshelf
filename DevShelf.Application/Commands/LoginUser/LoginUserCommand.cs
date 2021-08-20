using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.LoginUser
{
    public class LoginUserCommand : Command<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public override void Validate()
        {
            AddNotifications(new Contract<LoginUserCommand>()
                .Requires()
                .IsEmail(Email, "Email", "Invalid e-mail")
                .IsNotNullOrEmpty(Password, "Password", "Password is required")
            );
        }
    }
}
