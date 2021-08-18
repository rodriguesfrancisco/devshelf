using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        private readonly DevShelfDbContext _dbContext;
        public BookRepository(IConfiguration configuration, DevShelfDbContext dbContext)
        {
            _connectionString = configuration.GetConnectionString("DevShelfCs");
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

        public async Task<Category> FindCategoryAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }
    }
}
