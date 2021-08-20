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

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email.Value == email && u.Password == passwordHash);
        }
    }
}
