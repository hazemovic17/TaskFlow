using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id); //get user by ID

        Task<User?> GetByEmailAsync(string email);//get uuser by their email

        Task AddAsync(User user); //adds a new user
    }
}
