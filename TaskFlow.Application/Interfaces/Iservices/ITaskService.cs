using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Tasks;
using TaskFlow.Application.DTOs.Tasks;


namespace TaskFlow.Application.Interfaces.Iservices;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetTasksAsync(
        int page,
        int pageSize,
        TaskStatus? status,
        string? sortBy);

    Task<TaskDto> GetTaskByIdAsync(Guid id);

    Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto);

    Task<TaskDto> UpdateTaskAsync(
        Guid id,
        UpdateTaskDto updateTaskDto);

    Task<TaskDto> UpdateTaskStatusAsync(
        Guid id,
        UpdateTaskStatusDto updateTaskStatusDto);

    Task DeleteTaskAsync(Guid id);
}
