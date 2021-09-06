using DevShelf.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Entities
{
    public class UserBook
    {
        public UserBook(User user, Book book, ReadingStatusEnum readingStatus)
        {
            User = user;
            UserId = user.Id;
            Book = book;
            BookId = book.Id;
            ReadingStatus = readingStatus;
            CreatedAt = DateTime.Now;
        }
        protected UserBook()
        {

        }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public Book Book { get; private set; }
        public int BookId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ReadingStatusEnum ReadingStatus { get; private set; }
    }
}
