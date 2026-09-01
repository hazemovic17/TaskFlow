using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;
using TaskFlow.Application.Interfaces.Iservices;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;// TaskServie depends on ITaskRepository to access user data.
                                                         // The repository is injected through the constructor using Dependency Injection, 
                                                         // so TaskService does not need to create the repository itself.


        public TaskService(ITaskRepository taskRepository) // The constructor receives the required ITaskRepository from the DI container 
                                                           // and stores it in _taskRepository so it can be used throughout the service.
        {
            _taskRepository = taskRepository;
        }

        public Task<IEnumerable<TaskDto>> GetTasksAsync(
            int page,
            int pageSize,
            TaskStatus? status,
            string? sortBy)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> GetTaskByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> UpdateTaskAsync(
            Guid id,
            UpdateTaskDto updateTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> UpdateTaskStatusAsync(
            Guid id,
            UpdateTaskStatusDto updateTaskStatusDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
