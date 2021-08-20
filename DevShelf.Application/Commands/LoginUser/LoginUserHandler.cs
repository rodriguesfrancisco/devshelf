using DevShelf.Domain.Repositories;
using DevShelf.Domain.Services;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(command.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(command.Email, passwordHash);

            command.AddNotifications(new Contract<LoginUserCommand>()
                .Requires()
                .IsNotNull(user, "User", "Failed to login")
            );
            if (!command.IsValid) return null;

            var token = _authService.GenerateJwtToken(user.Email.Value, user.Role);

            return new LoginUserViewModel(user.Email.Value, token);
        }
    }
}
