using DevShelf.Application.Commands.CreateBook;
using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevShelf.UnitTests.Application.Commands
{
    public class CreateBookTests
    {
        [Fact]
        public async Task ValidCreateBookCommand_Executed_ValidCommandReturned()
        {
            // Arrange
            var createBookCommand = new CreateBookCommand
            {
                Title = "Book Test",
                Author = "Author Test",
                Category = "Test Category",
                Description = "Test Book Description",
                NumberOfPages = 300,
                Publisher = "Test Publisher"
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            var createBookCommandHandler = new CreateBookHandler(bookRepositoryMock.Object);

            // Act
            await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            // Assert
            Assert.True(createBookCommand.IsValid);
        }

        [Fact]
        public async Task CreateBookCategoryNotFound_Executed_CommandInvalid()
        {
            // Arrange
            var createBookCommand = new CreateBookCommand
            {
                Title = "Book Test",
                Author = "Author Test",
                CategoryId = 100,
                Description = "Test Book Description",
                NumberOfPages = 300,
                Publisher = "Test Publisher"
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(br => br.FindCategoryAsync(createBookCommand.CategoryId.Value)).Returns(Task.FromResult<Category>(null));
            var createBookCommandHandler = new CreateBookHandler(bookRepositoryMock.Object);
            var categoryNotFoundErrorMessage = "Category not found";

            // Act
            await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            // Assert
            Assert.False(createBookCommand.IsValid);
            Assert.Contains(categoryNotFoundErrorMessage, createBookCommand.Notifications.Select(n => n.Message).ToList());
        }
    }
}
