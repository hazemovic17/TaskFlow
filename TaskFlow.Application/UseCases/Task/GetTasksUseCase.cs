using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.UserProvisioning;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.UseCases.Task
{
    public class GetTasksUseCase : IGetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetTasksUseCase(
    ITaskRepository taskRepository,
    ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<TaskDto>> ExecuteAsync()
        {
            var currentUserId = _currentUserService.UserId;
            var currentUserRole = _currentUserService.Role;

            IEnumerable<TaskItem> tasks;

            if (currentUserRole == "Admin")
            {
                tasks = await _taskRepository.GetAllAsync();
            }
            else
            {
                tasks = await _taskRepository
                    .GetByUserIdAsync(currentUserId);
            }

            return tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                AssignedUserId = task.AssignedUserId,
                Status = task.Status
            });
        }
    }
}
