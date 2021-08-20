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
    }
}
