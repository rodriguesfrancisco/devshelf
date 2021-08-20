using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using DevShelf.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(command.Password);
            var user = new User(command.Name, command.Email, passwordHash, "USER");

            command.AddNotifications(user);
            if (!command.IsValid) return Unit.Value;

            await _userRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
