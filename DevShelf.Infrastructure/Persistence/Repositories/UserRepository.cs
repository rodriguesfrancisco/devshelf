using DevShelf.Domain.Entities;
using DevShelf.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevShelfDbContext _dbContext;
        public UserRepository(DevShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email.Value == email && u.Password == passwordHash);
        }

        public Task<User> FindUserByEmailAsync(string email)
        {
            return _dbContext
                .Users
                .Include(u => u.UserBooks)
                    .ThenInclude(ub => ub.Book)
                .SingleOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
