using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DevShelfDbContext _dbContext;
        public BookRepository(IConfiguration configuration, DevShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            var result = _dbContext.Books;

            return result;
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public ValueTask<Category> FindCategoryAsync(int id)
        {
            return _dbContext.Categories.FindAsync(id);
        }

        public ValueTask<Book> FindBookByIdAsync(int id)
        {
            return _dbContext.Books.FindAsync(id);
        }
    }
}
