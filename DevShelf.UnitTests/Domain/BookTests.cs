using DevShelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevShelf.UnitTests.Domain
{
    public class BookTests
    {
        [Fact]
        public void NewBook_Created_ValidBook()
        {
            // Arrange
            var title = "Livro de Teste";
            var author = "Autor Teste";
            var numberOfPages = 300;
            var description = "Descrição do livro de teste";
            var publisher = "Publisher de teste";
            var category = new Category("Categoria de Teste");

            var okBook = new Book(
                title, 
                author, 
                numberOfPages, 
                description,
                publisher,
                category
            );

            // Act

            // Assert
            Assert.Equal(okBook.Title.Value, title);
            Assert.Equal(okBook.Author.Name, author);
            Assert.Equal(okBook.NumberOfPages, numberOfPages);
            Assert.Equal(okBook.Description.Value, description);
            Assert.Equal(okBook.Publisher.Value, publisher);
            Assert.Equal(okBook.Category.Description, category.Description);
            Assert.Empty(okBook.Notifications);
            Assert.True(okBook.IsValid);
        }

        [Fact]
        public void NewBookInvalidFields_Created_InvalidBook()
        {
            // Arrange
            var invalidTitle = "IT";
            var invalidAuthor = "I";
            var numberOfPages = 300;
            var invalidDescription = "ID";
            var invalidPublisher = "I";
            var category = new Category("Categoria de Teste");

            var invalidTitleMessage = "Title length must be greater than or equals 3";
            var invalidAuthorMessage = "Author Name length must be greather than or equals 2";
            var invalidDescriptionMessage = "Book Description length must be greater than or equals 10";
            var invalidPublisherMessage = "Publisher length must be greater than or equals 2";
            var expectedErrorMessagesList = new List<string>()
            {
                invalidTitleMessage,
                invalidAuthorMessage,
                invalidDescriptionMessage,
                invalidPublisherMessage
            };

            var invalidBook = new Book(
                invalidTitle,
                invalidAuthor,
                numberOfPages,
                invalidDescription,
                invalidPublisher,
                category
            );

            // Act

            // Assert
            Assert.False(invalidBook.IsValid);
            foreach(var message in expectedErrorMessagesList)
            {
                Assert.Contains(message, invalidBook.Notifications.Select(x => x.Message).ToList());
            }
        }
    }
}
