using DevShelf.Domain.Entities;
using DevShelf.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevShelf.UnitTests.Domain
{
    public class UserTests
    {
        [Fact]
        public void NewBookToUser_AddBook_UserBooksContainsInstanceOfBook()
        {
            // Arrange
            var user = new User("Test User", "user@test.com", "passwordtest", UserRoleEnum.USER.ToString());
            var book = new Book(
                "Test book", 
                "Test author", 
                200, 
                "That's a test book description", 
                "Test publisher", 
                new Category("Test Category")
            );

            // Act
            user.AddBook(book);

            // Assert
            Assert.True(user.UserBooks.Count > 0);
            Assert.True(user.UserBooks.Exists(ub => ub.User.Equals(user) && ub.Book.Equals(book)));
        }

        [Fact]
        public void TwoBooksWithSameId_AddBookToUser_InvalidUserWithNotification()
        {
            // Arrange
            var user = new User("Test User", "user@test.com", "passwordtest", UserRoleEnum.USER.ToString());
            var bookMock = new Mock<Book>();
            bookMock.SetupGet(b => b.Id).Returns(1);
            var repeatedBookMessage = "User Already Contains the book";

            // Act
            user.AddBook(bookMock.Object);
            user.AddBook(bookMock.Object);

            // Assert
            Assert.True(user.Notifications.Count == 1);
            Assert.Contains(repeatedBookMessage, user.Notifications.Select(x => x.Message).ToList());
        }
    }
}
