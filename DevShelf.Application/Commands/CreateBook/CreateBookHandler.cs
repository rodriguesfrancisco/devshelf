using DevShelf.Domain.Entities;
using DevShelf.Infrastructure.Persistence;
using Flunt.Validations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private DevShelfDbContext _dbContext;
        public CreateBookHandler(DevShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            Category category;
            if(HasCategoryId(command))
            {
                category = await _dbContext.Categories.FindAsync(command.CategoryId);

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

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }

        private bool HasCategoryId(CreateBookCommand command)
        {
            return command.CategoryId != null;
        }
    }
}
