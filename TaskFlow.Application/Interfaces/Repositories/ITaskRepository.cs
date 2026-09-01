using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id);

        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId);

        Task AddAsync(TaskItem task);

        void Update(TaskItem task);

        void Delete(TaskItem task);
    }
}
