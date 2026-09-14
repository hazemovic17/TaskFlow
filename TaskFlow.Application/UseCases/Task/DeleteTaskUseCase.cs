using TaskFlow.Application.Exceptions;
using TaskFlow.Application.Interfaces.IUseCases;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.UserProvisioning;

namespace TaskFlow.Application.UseCases.Tasks;

public class DeleteTaskUseCase : IDeleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public DeleteTaskUseCase(
        ITaskRepository taskRepository,
        ICurrentUserService currentUserService)
    {
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
    }

    public async System.Threading.Tasks.Task ExecuteAsync(Guid id)
    {
        var currentUserRole = _currentUserService.Role;

        // Only admins can delete tasks
        if (currentUserRole != "Admin")
        {
            throw new ForbiddenException(
                "Only admins can delete tasks.");
        }

        
        var task = await _taskRepository.GetByIdAsync(id);

        // Check if the task exists
        if (task is null)
        {
            throw new NotFoundException("Task was not found.");
        }

        
        await _taskRepository.DeleteAsync(task);
    }
}