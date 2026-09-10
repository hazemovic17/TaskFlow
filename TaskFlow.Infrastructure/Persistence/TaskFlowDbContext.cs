using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence
{
    public class TaskFlowDbContext : DbContext
    {
        public TaskFlowDbContext(
            DbContextOptions<TaskFlowDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
