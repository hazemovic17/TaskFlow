using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.UserProvisioning;

namespace TaskFlow.Application.UseCases.Tasks;

public class GetTaskByIdUseCase : IGetTaskByIdUseCase
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public GetTaskByIdUseCase(
        ITaskRepository taskRepository,
        ICurrentUserService currentUserService)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
    }

    public async Task<TaskDto> ExecuteAsync(Guid id)
    {
        // Get the current user's ID and role
        var currentUserId = _currentUserService.UserId;
        var currentUserRole = _currentUserService.Role;

       
        var task = await _taskRepository.GetByIdAsync(id);

       
        if (task is null) // Check if the task exists
        {
            throw new NotFoundException("Task was not found.");
        }

      
        if (currentUserRole == "Member" &&
            task.AssignedUserId != currentUserId)  // Members can only view their own tasks
        {
            throw new ForbiddenException(
                "You are not allowed to view this task.");
        }

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
