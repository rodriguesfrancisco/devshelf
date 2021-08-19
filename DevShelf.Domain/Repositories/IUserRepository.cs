using DevShelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
