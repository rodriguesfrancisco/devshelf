using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using Flunt.Validations;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            Category category;
            if(HasCategoryId(command))
            {
                category = await _bookRepository.FindCategoryAsync(command.CategoryId.Value);

                command.AddNotifications(new Contract<CreateBookCommand>()
                    .Requires()
                    .IsNotNull(category, "Category", "Category not found")
                );
                if (!command.IsValid) return Unit.Value;
            } else
            {
                category = new Category(command.Category);
            }

            var book = new Book(command.Title, command.Author, command.NumberOfPages, command.Description, command.Publisher, category);

            command.AddNotifications(book);
            if (!command.IsValid) return Unit.Value;

            await _bookRepository.AddAsync(book);

            return Unit.Value;
        }

        private bool HasCategoryId(CreateBookCommand command)
        {
            return command.CategoryId != null;
        }
    }
}
