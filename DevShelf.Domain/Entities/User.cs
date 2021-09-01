using DevShelf.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password, string role)
        {
            Name = new UserName(name);
            Email = new Email(email);
            AddNotifications(Name, Email);
            if (!IsValid) return;

            Password = password;
            Role = role;
            CreatedAt = DateTime.Now;
            UserBooks = new List<UserBook>();
        }

        protected User () 
        {
            
        }

        public UserName Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserBook> UserBooks { get; private set; }

        public void AddBook(Book book)
        {
            if(UserBooks is not null)
            {
                var userAlreadyContainsBook = UserBooks.Exists(ub => ub.Book.Id == book.Id);
                if (userAlreadyContainsBook)
                {
                    AddNotification("UserBook", "User Already Contains the book");

                    return;
                }
                var userBook = new UserBook(this, book);
                UserBooks.Add(userBook);
            }
            
        }
    }
}
