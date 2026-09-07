using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Task
{
    public class GetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDto>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
