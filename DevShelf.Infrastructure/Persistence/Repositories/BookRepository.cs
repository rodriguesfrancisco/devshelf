using Dapper;
using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using DevShelf.Domain.ValueObjects;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task Add(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> FindCategory(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }
    }
}
