using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.UserProvisioning;

namespace TaskFlow.Application.UseCases.Tasks;

public class UpdateTaskUseCase : IUpdateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateTaskUseCase(
        ITaskRepository taskRepository,
        ICurrentUserService currentUserService)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
    }

    public async Task<TaskDto> ExecuteAsync(
        Guid id,
        UpdateTaskDto updateTaskDto)
    {
        // Get the current user's ID and role
        var currentUserId = _currentUserService.UserId;
        var currentUserRole = _currentUserService.Role;

        var task = await _taskRepository.GetByIdAsync(id);

        
        if (task is null)// Check if the task exists
        {
            throw new NotFoundException("Task was not found.");
        }

        
        if (currentUserRole == "Member" &&
            task.AssignedUserId != currentUserId)// Members can only update their own tasks
        {
            throw new ForbiddenException(
                "You are not allowed to update this task.");
        }

        
        if (currentUserRole == "Member" &&
            updateTaskDto.AssignedUserId != currentUserId)// Members cannot assign the task to another user
        {
            throw new ForbiddenException(
                "Members cannot assign tasks to other users.");
        }

        task.Title = updateTaskDto.Title;
        task.Description = updateTaskDto.Description;
        task.DueDate = updateTaskDto.DueDate;
        task.AssignedUserId = updateTaskDto.AssignedUserId;
        task.Status = (Domain.Enums.TaskStatus)updateTaskDto.Status;

        await _taskRepository.UpdateAsync(task);

       
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