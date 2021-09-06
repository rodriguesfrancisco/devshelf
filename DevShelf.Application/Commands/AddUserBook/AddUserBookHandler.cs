using DevShelf.Domain.Repositories;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.AddUserBook
{
    public class AddUserBookHandler : IRequestHandler<AddUserBookCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddUserBookHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(AddUserBookCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByEmailAsync(command.UserEmail);
            var book = await _bookRepository.FindBookByIdAsync(command.BookId);

            command.AddNotifications(new Contract<AddUserBookCommand>()
                .Requires()
                .IsNotNull(user, "User", "User not found")
                .IsNotNull(book, "Book", "Book not found")
            );
            if (!command.IsValid) return Unit.Value;

            user.AddBook(book, command.ReadingStatus);
            command.AddNotifications(user);
            if (!command.IsValid) return Unit.Value;

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
