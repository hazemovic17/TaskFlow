using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Task
{

    public class CreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> ExecuteAsync(CreateTaskDto createTaskDto)
        {
            throw new NotImplementedException();
        }
    }
}
