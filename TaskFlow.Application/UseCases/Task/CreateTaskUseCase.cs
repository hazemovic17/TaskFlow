using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.UserProvisioning;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;


namespace TaskFlow.Application.UseCases.Task
{


    public class CreateTaskUseCase : ICreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateTaskUseCase(
    ITaskRepository taskRepository,
    IUserRepository userRepository,
    ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<TaskDto> ExecuteAsync(CreateTaskDto createTaskDto)
        {
            var currentUserId = _currentUserService.UserId;
            var currentUserRole = _currentUserService.Role;

            // Members can only assign tasks to themselves
            if (currentUserRole == "Member" &&
                createTaskDto.AssignedUserId != currentUserId)
            {
                throw new ForbiddenException(
                    "Members can only assign tasks to themselves.");
            }

            var assignedUser = await _userRepository
                .GetByIdAsync(createTaskDto.AssignedUserId);

            if (assignedUser is null)// Check if the assigned user exists
            {
                throw new NotFoundException(
                    "Assigned user was not found.");
            }

          
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                DueDate = createTaskDto.DueDate,
                AssignedUserId = createTaskDto.AssignedUserId,
                Status = Domain.Enums.TaskStatus.Pending
            };

            
            await _taskRepository.AddAsync(task);

            // Return DTO instead of entity for security purposes
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                AssignedUserId = task.AssignedUserId,
                Status = task.Status
            };
        }
    }
}
