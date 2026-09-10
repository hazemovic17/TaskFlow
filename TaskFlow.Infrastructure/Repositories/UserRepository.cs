using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

using TaskFlow.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskFlowDbContext _context;

        public UserRepository(TaskFlowDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
